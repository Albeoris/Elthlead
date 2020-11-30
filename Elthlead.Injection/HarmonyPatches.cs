using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Elthlead.Framework;
using Elthlead.JSON;
using Elthlead.ResourceManager;
using GameCommon;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;
// ReSharper disable InconsistentNaming

namespace Elthlead.Injection
{
    public static class HarmonyPatches
    {
        public static void Patch()
        {
            try
            {
                Log.Message("[Harmony] Patching methods.");

                Harmony instance = new Harmony("Elthlead.Injection");
                instance.PatchAll(Assembly.GetExecutingAssembly());

                PatchTitleQuestionData(instance);

                Log.Message("[Harmony] Successfully patched.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "[Harmony] Failed to patch methods.");
            }
        }

        [HarmonyPatch(typeof(UnitManager))]
        [HarmonyPatch(nameof(UnitManager.ReadCSV_CharactorData))]
        private sealed class UnitManager_ReadCSV_CharactorData
        {
            public static void Postfix(UnitManager __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Characters");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(UnitManager_ReadCSV_CharactorData)}] File not found: Characters.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    CharactorData[] charList = __instance.charaData;

                    foreach (Reference<TransifexEntry> pair in PrepareTexts(filePath).Enumerate())
                    {
                        CharacterDataId reference = CharacterDataId.Parse(pair.Key);
                        CharactorData character = charList.First(ch => ch.charactorID == reference.Id);
                        character.name[language] = pair.Value.Text;
                    }

                    Log.Message($"[{nameof(UnitManager_ReadCSV_CharactorData)}] Loaded: Characters.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(UnitManager_ReadCSV_CharactorData)}] Failed to load Characters.json");
                }
            }
        }

        [HarmonyPatch(typeof(UnitManager))]
        [HarmonyPatch(nameof(UnitManager.ReadCSV_ClassData))]
        private sealed class UnitManager_ReadCSV_ClassData
        {
            public static void Postfix(UnitManager __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Classes");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(UnitManager_ReadCSV_ClassData)}] File not found: Classes.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    ClassData[] classList = __instance.classData;

                    foreach (Reference<TransifexEntry> pair in PrepareTexts(filePath).Enumerate())
                    {
                        String text = pair.Value.Text;
                        ClassDataId reference = ClassDataId.Parse(pair.Key);
                        ClassData cls = classList[reference.Id];
                        switch (reference.Property)
                        {
                            case "DisplayName":
                                cls.name[language] = text;
                                break;
                            case "Description":
                                cls.description[language] = text;
                                break;
                            default:
                                throw new NotSupportedException(reference.ToString());
                        }
                    }

                    Log.Message($"[{nameof(UnitManager_ReadCSV_ClassData)}] Loaded: Classes.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(UnitManager_ReadCSV_ClassData)}] Failed to load Classes.json");
                }
            }
        }

        [HarmonyPatch(typeof(UnitManager))]
        [HarmonyPatch(nameof(UnitManager.ReadCSV_MagicData))]
        private sealed class UnitManager_ReadCSV_MagicData
        {
            public static void Postfix(UnitManager __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Magic");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(UnitManager_ReadCSV_MagicData)}] File not found: Magic.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    MagicData[] magicList = __instance.magicData;

                    foreach (Reference<TransifexEntry> pair in PrepareTexts(filePath).Enumerate())
                    {
                        String text = pair.Value.Text;
                        MagicDataId reference = MagicDataId.Parse(pair.Key);
                        MagicData magic = magicList[reference.Id];
                        switch (reference.Property)
                        {
                            case "Name":
                                magic.name[language] = text;
                                break;
                            case "Description":
                                magic.description[language] = text;
                                break;
                            default:
                                throw new NotSupportedException(reference.ToString());
                        }
                    }

                    Log.Message($"[{nameof(UnitManager_ReadCSV_MagicData)}] Loaded: Magic.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(UnitManager_ReadCSV_MagicData)}] Failed to load Magic.json");
                }
            }
        }

        [HarmonyPatch(typeof(UnitManager))]
        [HarmonyPatch(nameof(UnitManager.ReadCSV_ItemData))]
        private sealed class UnitManager_ReadCSV_ItemData
        {
            public static void Postfix(UnitManager __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Items");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(UnitManager_ReadCSV_ItemData)}] File not found: Items.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    ItemData[] itemList = __instance.itemData;

                    foreach (Reference<TransifexEntry> pair in PrepareTexts(filePath).Enumerate())
                    {
                        String text = pair.Value.Text;
                        ItemDataId reference = ItemDataId.Parse(pair.Key);
                        ItemData item = itemList[reference.Id];
                        switch (reference.Property)
                        {
                            case "Name":
                                item.name[language] = text;
                                break;
                            case "Description":
                                item.description[language] = text;
                                break;
                            case "ShortDescription":
                                item.descriptionShort[language] = text;
                                break;
                            default:
                                throw new NotSupportedException(reference.ToString());
                        }
                    }

                    Log.Message($"[{nameof(UnitManager_ReadCSV_ItemData)}] Loaded: Items.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(UnitManager_ReadCSV_ItemData)}] Failed to load Items.json");
                }
            }
        }

        [HarmonyPatch(typeof(UnitManager))]
        [HarmonyPatch(nameof(UnitManager.ReadCSV_SkillData))]
        private sealed class UnitManager_ReadCSV_SkillData
        {
            public static void Postfix(UnitManager __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Skills");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(UnitManager_ReadCSV_SkillData)}] File not found: Skills.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    SkillData[] skillList = __instance.skillData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        String text = item.Value.Text;
                        SkillDataId reference = SkillDataId.Parse(item.Key);
                        SkillData info = skillList[reference.Id];
                        switch (reference.Property)
                        {
                            case "Name":
                                info.name[language] = text;
                                break;
                            case "Description":
                                info.description[language] = text;
                                break;
                            case "ShortDescription":
                                info.descriptionShort[language] = text;
                                break;
                            default:
                                throw new NotSupportedException(reference.ToString());
                        }
                    }

                    Log.Message($"[{nameof(UnitManager_ReadCSV_SkillData)}] Loaded: Skills.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(UnitManager_ReadCSV_SkillData)}] Failed to load Skills.json");
                }
            }
        }

        [HarmonyPatch(typeof(GameMain))]
        [HarmonyPatch(nameof(GameMain.ReadCSVData_InfomationMessageData))]
        private sealed class GameMain_ReadCSVData_InfomationMessageData
        {
            public static void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("System");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(GameMain_ReadCSVData_InfomationMessageData)}] File not found: System.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    InfomationMessageData[] informationList = __instance.infomationMessageData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        SystemDataId reference = SystemDataId.Parse(item.Key);
                        InfomationMessageData info = informationList[reference.Message];
                        if (reference.Button == null)
                            info.messageText[language, 0] = item.Value.Text;
                        else
                            info.messageText[language, reference.Button.Value] = item.Value.Text;
                    }

                    Log.Message($"[{nameof(GameMain_ReadCSVData_InfomationMessageData)}] Loaded: System.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(GameMain_ReadCSVData_InfomationMessageData)}] Failed to load System.json");
                }
            }
        }

        [HarmonyPatch(typeof(GameMain))]
        [HarmonyPatch(nameof(GameMain.ReadCSVData_GameSystemWordData))]
        sealed class GameMain_ReadCSVData_GameSystemWordData
        {
            static void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("GameWords");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(GameMain_ReadCSVData_GameSystemWordData)}] File not found: GameWords.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    GameSystemWordData[] wordList = __instance.gameSystemWordData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        GameWordId reference = GameWordId.Parse(item.Key);
                        GameSystemWordData word = wordList[reference.Id];
                        word.worddata[language] = item.Value.Text;
                    }

                    Log.Message($"[{nameof(GameMain_ReadCSVData_GameSystemWordData)}] Loaded: GameWords.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(GameMain_ReadCSVData_GameSystemWordData)}] Failed to load GameWords.json");
                }
            }
        }
        
        [HarmonyPatch(typeof(GameMain))]
        [HarmonyPatch(nameof(GameMain.ReadCSVData_MapAttribute))]
        private sealed class GameMain_ReadCSVData_MapAttribute
        {
            public static void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("GroundTypes");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(GameMain_ReadCSVData_MapAttribute)}] File not found: GroundTypes.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    MapAttribute[] mapAttributes = StWorkProxy.MapAttribute;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        GroundTypeId reference = GroundTypeId.Parse(item.Key);
                        MapAttribute info = mapAttributes[reference.Id];
                        info.name[language] = item.Value.Text;
                    }

                    Log.Message($"[{nameof(GameMain_ReadCSVData_MapAttribute)}] Loaded: GroundTypes.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(GameMain_ReadCSVData_MapAttribute)}] Failed to load GroundTypes.json");
                }
            }
        }
        
        [HarmonyPatch(typeof(GameMain))]
        [HarmonyPatch(nameof(GameMain.ReadCSVData_EndingData))]
        private sealed class GameMain_ReadCSVData_EndingData
        {
            public static void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("Ending");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(GameMain_ReadCSVData_EndingData)}] File not found: Ending.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    EndingData[] engings = __instance.endingData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        EndingDataId reference = EndingDataId.Parse(item.Key);
                        EndingData info = engings[reference.Id];

                        Int32 sceneIndex = reference.Scene - 1;
                        String valueText = item.Value.Text;
                        
                        switch (language)
                        {
                            case 1:
                                info.endingText_En[0, sceneIndex] = valueText;
                                break;
                            case 2:
                                info.endingText_Ch[0, sceneIndex] = valueText;
                                break;
                            case 3:
                                info.endingText_Ko[0, sceneIndex] = valueText;
                                break;
                            default:
                                info.endingText_Jp[0, sceneIndex] = valueText;
                                break;
                        }
                    }

                    Log.Message($"[{nameof(GameMain_ReadCSVData_EndingData)}] Loaded: Ending.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(GameMain_ReadCSVData_EndingData)}] Failed to load Ending.json");
                }
            }
        }

        [HarmonyPatch(typeof(GameMain))]
        [HarmonyPatch(nameof(GameMain.ReadCSVData_ScenarioInfoData))]
        private sealed class GameMain_ReadCSVData_ScenarioInfoData
        {
            public static void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("ScenarioInfo");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(GameMain_ReadCSVData_ScenarioInfoData)}] File not found: ScenarioInfo.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    ScenarioInfoData[] scenarioList = __instance.scenarioInfoData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        ScenarioDataId reference = ScenarioDataId.Parse(item.Key);
                        ScenarioInfoData info = scenarioList[reference.Message];
                        String text = item.Value.Text;

                        switch (reference.Property)
                        {
                            case "StageTitle":
                                info.scenarioName[language] = text;
                                break;
                            case "StageProlog":
                                info.scenarioSummary[language] = text;
                                break;
                            case "StageHint":
                                info.mapEnemyInfo[language] = text;
                                break;
                            case "VictoryCondition1":
                                info.win[language, 0] = text;
                                break;
                            case "DefeatCondition1":
                                info.lose[language, 0] = text;
                                break;
                            case "VictoryCondition2":
                                info.win[language, 1] = text;
                                break;
                            case "DefeatCondition2":
                                info.lose[language, 1] = text;
                                break;
                            case "PlayerArmyName":
                                info.playerName[language] = text;
                                break;
                            case "EnemyArmyName":
                                info.enemyName[language] = text;
                                break;
                            case "FlagName1":
                                info.flagName[language, 0] = text;
                                break;
                            case "FlagName2":
                                info.flagName[language, 1] = text;
                                break;
                            case "FlagName3":
                                info.flagName[language, 2] = text;
                                break;
                            case "FlagName4":
                                info.flagName[language, 3] = text;
                                break;
                            default:
                                throw new NotSupportedException(reference.ToString());
                        }
                    }

                    Log.Message($"[{nameof(GameMain_ReadCSVData_ScenarioInfoData)}] Loaded: ScenarioInfo.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(GameMain_ReadCSVData_ScenarioInfoData)}] Failed to load ScenarioInfo.json");
                }
            }
        }

        private static void PatchTitleQuestionData(Harmony instance)
        {
            Type mainType = typeof(GameMain);
            MethodInfo originalMethod = mainType.RequireInstanceMethod("ReadCSVData_TitleQuestionData");

            HarmonyMethod postfix = new HarmonyMethod(((Action<GameMain>) Postfix).Method);
            instance.Patch(originalMethod, postfix: postfix);

            void Postfix(GameMain __instance)
            {
                try
                {
                    String filePath = FindOverridenFile("GoddessDialog");
                    if (filePath is null)
                    {
                        Log.Warning($"[{nameof(StDataEventMessageListHandler)}] File not found: GoddessDialog.json");
                        return;
                    }

                    Int32 language = StWorkProxy.CurrentLanguage;
                    TitleQuestionData[] questionList = __instance.titleQuestionData;

                    foreach (Reference<TransifexEntry> item in PrepareTexts(filePath).Enumerate())
                    {
                        GoddessDialogDataId id = GoddessDialogDataId.Parse(item.Key);
                        TitleQuestionData question = questionList[id.Question];

                        String text = item.Value.Text;
                        if (id.Answer == null)
                            question.message[language] = text;
                        else
                            question.@select[language * 3 + id.Answer.Value - 1] = text;
                    }

                    Log.Message($"[{nameof(StDataEventMessageListHandler)}] Loaded: GoddessDialog.json");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"[{nameof(StDataEventMessageListHandler)}] Failed to load GoddessDialog.json");
                }
            }
        }

        private static readonly Regex SpacingRegex = new Regex(@"<cspace=[^>]+>(.+?)<\/cspace>");

        public static OrderedDictionary<String, TransifexEntry> PrepareTexts(String filePath)
        {
            OrderedDictionary<String, TransifexEntry> dic = StructuredJson.Read(filePath);
            return PrepareTexts(dic);
        }

        private static Reference<TextReplacement>[] _tags;

        public static OrderedDictionary<String, TransifexEntry> PrepareTexts(OrderedDictionary<String, TransifexEntry> dic)
        {
            if (_tags == null)
                _tags = LoadTags();

            foreach (var entry in dic.Values)
            {
                String text = entry.Text;

                if (text.StartsWith("${") && text.EndsWith("}"))
                {
                    String reference = text.Region("${".Length, "}".Length);
                    if (dic.TryGetValue(reference, out var referenced))
                        entry.Text = referenced.Text;
                    else
                        Log.Warning($"[PrepareTexts] Cannot find reference {reference}.");

                    continue;
                }

                text = SpacingRegex.Replace(text, "$1");
                text = text.ReplaceAll(_tags);

                // text = text
                //     .Replace("{Blue}", "<#88aaff>")
                //     .Replace("{Yellow}", "<#ffdd00>")
                //     .Replace("{Green}", "<#5eff00>")
                //     .Replace("{White}", "<#ffffff>")
                //     .Replace("{LightYellow}", "<#ffffdd>")
                //     .Replace("{LightPurple}", "<#ddddff>")
                //     .Replace("{", String.Empty)
                //     .Replace("}", String.Empty);

                entry.Text = text;
            }

            return dic;
        }

        private static Reference<TextReplacement>[] LoadTags()
        {
            try
            {
                var result = new List<Reference<TextReplacement>>();
                String filePath = FindOverridenFile("Tags");
                if (filePath is null)
                {
                    Log.Warning($"[{nameof(StDataEventMessageListHandler)}] File not found: Tags.json");
                    return result.ToArray();
                }

                foreach (Reference<TransifexEntry> item in StructuredJson.Read(filePath).Enumerate())
                {
                    var tag = item.Value.Context;
                    var text = item.Value.Text;

                    result.Add(new Reference<TextReplacement>(tag, text));
                }

                Log.Message($"[{nameof(StDataEventMessageListHandler)}] Loaded: Tags.json");
                return result.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [CanBeNull]
        private static String FindOverridenFile(String name)
        {
            String directoryPath = StreamingAssetsPath.Root.AbsolutePath + "/Text/Override/";
            if (!Directory.Exists(directoryPath))
                return null;

            return Directory.GetFiles(directoryPath, "*" + name + "*.json").SingleOrDefault();
        }
    }
}