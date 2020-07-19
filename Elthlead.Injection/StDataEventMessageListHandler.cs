using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Elthlead.Framework;
using Elthlead.JSON;
using Elthlead.ResourceManager;

namespace Elthlead.Injection
{
    public sealed class StDataEventMessageListHandler
    {
        private static readonly Regex __filter = new Regex(@"(?i)Text/RU/.*stage.*\.json$");

        private readonly Dictionary<EventMessageDataId, String> _dic = new Dictionary<EventMessageDataId, String>(32000);

        public StDataEventMessageListHandler()
        {
            LoadAll();

            StreamingAssetsWatcher watcher = The<StreamingAssetsWatcher>.Instance;
            watcher.FileChanged += WatcherOnFileChanged;
        }

        private void LoadAll()
        {
            String directoryPath = StreamingAssetsPath.Root.AbsolutePath + "/Text/RU/";
            var files = Directory.GetFiles(directoryPath, "*.json");

            Log.Message($"[{nameof(StDataEventMessageListHandler)}] Loading: {files.Length} files from {directoryPath}");

            foreach (String filePath in files)
            {
                if (!__filter.IsMatch(filePath))
                    continue;

                using (var input = File.OpenRead(filePath))
                        Load(filePath, input);
            }
        }

        private void WatcherOnFileChanged(String filePath, Stream stream)
        {
            if (__filter.IsMatch(filePath))
                Load(filePath, stream);
        }

        private void Load(String filePath, Stream input)
        {
            try
            {
                foreach (Reference<TransifexEntry> item in HarmonyPatches.PrepareTexts(StructuredJson.Read(input)).Enumerate())
                {
                    EventMessageDataId id = EventMessageDataId.Parse(item.Key);
                    _dic[id] = item.Value.Text;
                }

                Log.Message($"[{nameof(StDataEventMessageListHandler)}] Loaded: {filePath}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"[{nameof(StDataEventMessageListHandler)}] Failed to load {filePath}");
            }
        }

        private EventMessageList _eventMessageList;

        public void Update()
        {
            EventMessageList currentList = StDataProxy.EventMessageList;
            if (currentList == _eventMessageList)
                return;

            _eventMessageList = currentList;
            if (currentList is null)
            {
                Log.Message($"[{nameof(StDataEventMessageListHandler)}] Nullified");
                return;
            }

            try
            {
                Int32 language = StWorkProxy.CurrentLanguage;
                Int32 count = 0;

                foreach (var item in currentList.messageData)
                {
                    EventMessageDataId id = new EventMessageDataId(item.category, item.scenarioNumber, item.playNumber, item.messageNumber);
                    if (_dic.TryGetValue(id, out var text))
                    {
                        count++;
                        item.message[language] = text;
                    }
                }

                Log.Message($"[{nameof(StDataEventMessageListHandler)}] Changed: {count}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"[{nameof(StDataEventMessageListHandler)}] Error");
            }
        }
    }
}