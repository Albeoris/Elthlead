using System;
using System.IO;
using System.Reflection;
using Elthlead.Framework;
using Elthlead.ResourceManager;
using UnityEngine;

namespace Elthlead.Injection
{
    public static class ContentLocator
    {
        static ContentLocator()
        {
            var instance = The<ElthleadEngine>.Instance;
        }
        
        public static Boolean TryReplace<T>(string path, ref T __result) where T : UnityEngine.Object
        {
            String directoryPath = $"{StreamingAssetsPath.Root.AbsolutePath}/Override";
            String filePath = $"{directoryPath}/{path}.*";
            directoryPath = Path.GetDirectoryName(filePath);
            String fileName = Path.GetFileName(filePath);

            try
            {
                if (!Directory.Exists(directoryPath))
                    return false;

                String[] files = Directory.GetFiles(directoryPath, fileName);
                if (files.Length == 0)
                    return false;

                if (files.Length > 1)
                {
                    Log.Warning($"[{nameof(ContentLocator)}] Found {files.Length} files. Unable to determine the correct one: {filePath}");
                    return false;
                }

                filePath = files[0];

                Type type = typeof(T);
                
                if (type == typeof(TextAsset))
                {
                    return TryLoadTextAsset(filePath, out var textAsset)
                           && ReplaceResult(out __result, textAsset, filePath);
                }
                
                Log.Warning($"[{nameof(ContentLocator)}] Not supported asset type {type.FullName} ({filePath})");
                return false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"[{nameof(ContentLocator)}] Failed to load {filePath}");
                return false;
            }
        }

        private static Boolean TryLoadTextAsset(String filePath, out TextAsset result)
        {
            String text = File.ReadAllText(filePath);
            result = new TextAsset(text);
            return true;
        }

        private static Boolean ReplaceResult<T>(out T result, UnityEngine.Object textAsset, String filePath) where T : UnityEngine.Object
        {
            result = (T) textAsset;
            Log.Message($"[{nameof(ContentLocator)}] Loaded: {filePath}");
            return true;
        }
    }
}