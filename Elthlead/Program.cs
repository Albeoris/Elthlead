using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Elthlead.CSV;
using Elthlead.Framework;
using Elthlead.Injection;
using Elthlead.JSON;

/*
 * Here are the small utilities that are used to process game data.
 * They are not part of the modification and are very messy.
 * Never mind. :) 
 */
namespace Elthlead
{
    internal class Program
    {
        public static void Main_Tags(string[] args)
        {
             // HashSet<Char> chars = new HashSet<Char>();
             // foreach (var filePath in Directory.EnumerateFiles(@"C:\Steam\steamapps\common\Langrisser I & II\Langrisser I & II_Data\StreamingAssets\Text\RU", "*.json"))
             // {
             //     var entries = StructuredJson.Read(filePath);
             //     foreach (var entry in entries)
             //     {
             //         foreach (var ch in entry.Value.Text)
             //         {
             //             chars.Add(ch);
             //         }
             //     }
             // }
             //
             // foreach (var ch in "【】％２３：ＡＢＣＤＥＦＧＨＩＪＫＬＭ■!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~×‥…※ⅠⅡЁАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЬЭЯабвгдежзийклмнопрстуфхцчшщъыьэюяё")
             // {
             //     chars.Add(ch);
             // }
             //
             // var str = new String(chars.OrderBy(c => c).ToArray()).Trim();
            
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(String tag, String replacement)
            {
                String id = $"Tag {tag}";
                lines.Add(id, new TransifexEntry()
                {
                    Context = tag,
                    Text = replacement
                });
            }

            Add("{Blue}", "<#88aaff>");
            Add("{Yellow}", "<#ffdd00>");
            Add("{Green}", "<#5eff00>");
            Add("{White}", "<#ffffff>");
            Add("{LightYellow}", "<#ffffdd>");
            Add("{LightPurple}", "<#ddddff>");
            Add("{AGL}", "AGL");
            Add("{ATK}", "ATK");
            Add("{DEF}", "DEF");
            Add("{DEX}", "DEX");
            Add("{DMG}", "DMG");
            Add("{MAG}", "MAG");
            Add("{MGR}", "MGR");
            Add("{MOV}", "MOV");

            foreach (var tag in Tags)
            {
                var replacement = tag.Replace("�", "");
                var text = '{' + replacement + '}';

                Add(text, replacement);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Tags.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_EndingData(string[] args)
        {
            EndingData[] endingList = DB.ReadAll<EndingData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\EndingData.txt");

            Dictionary<String, EndingDataId> ids = new Dictionary<String, EndingDataId>();
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();
            
            void Add(EndingDataId id, String text)
            {
                if (ids.TryGetValue(text, out EndingDataId knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine)
                            .Replace("<#88aaff>", "{Blue}")
                            .Replace("<#ffdd00>", "{Yellow}")
                            .Replace("<#5eff00>", "{Green}")
                            .Replace("<#ffffff>", "{White}")
                            .Replace("<#ffffdd>", "{LightYellow}")
                            .Replace("<#ddddff>", "{LightPurple}")
                            .Replace("AGL", "{AGL}")
                            .Replace("ATK", "{ATK}")
                            .Replace("DEF", "{DEF}")
                            .Replace("DEX", "{DEX}")
                            .Replace("DMG", "{DMG}")
                            .Replace("MAG", "{MAG}")
                            .Replace("MGR", "{MGR}")
                            .Replace("MOV", "{MOV}"),
                    });
                    ids.Add(text, id);
                }
            }

            foreach (var data in endingList)
            {
                for (Int32 i = 0; i < 8; i++)
                {
                    EndingDataId sceneKey = new EndingDataId(data.Id, i + 1);
                    String english = data[i].English;

                    Add(sceneKey, english);
                }
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Ending.json";
            StructuredJson.Write(gp, lines);
        }
        
        public static void Main_GameWordList(string[] args)
        {
            GameWordData[] information = DB.ReadAll<GameWordData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\GameWordList.txt");

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();
            Dictionary<String, GameWordId> ids = new Dictionary<String, GameWordId>();

            void Add(GameWordId id, String text)
            {
                if (ids.TryGetValue(text, out GameWordId knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine)
                            .Replace("<#88aaff>", "{Blue}")
                            .Replace("<#ffdd00>", "{Yellow}")
                            .Replace("<#5eff00>", "{Green}")
                            .Replace("<#ffffff>", "{White}")
                            .Replace("<#ffffdd>", "{LightYellow}")
                            .Replace("<#ddddff>", "{LightPurple}")
                            .Replace("AGL", "{AGL}")
                            .Replace("ATK", "{ATK}")
                            .Replace("DEF", "{DEF}")
                            .Replace("DEX", "{DEX}")
                            .Replace("DMG", "{DMG}")
                            .Replace("MAG", "{MAG}")
                            .Replace("MGR", "{MGR}")
                            .Replace("MOV", "{MOV}"),
                    });
                    ids.Add(text, id);
                }
            }

            Int32 index = 0;
            foreach (var item in information)
            {
                Add(new GameWordId(index++), item.Text.English);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\GameWords.json";
            StructuredJson.Write(gp, lines);
        }
        
        public static void Main_GroundTypes(string[] args)
        {
            GroundType[] information = DB.ReadAll<GroundType>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\mapAttribute.txt");

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();
            Dictionary<String, GroundTypeId> ids = new Dictionary<String, GroundTypeId>();

            void Add(GroundTypeId id, String text)
            {
                if (ids.TryGetValue(text, out GroundTypeId knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine)
                            .Replace("<#88aaff>", "{Blue}")
                            .Replace("<#ffdd00>", "{Yellow}")
                            .Replace("<#5eff00>", "{Green}")
                            .Replace("<#ffffff>", "{White}")
                            .Replace("<#ffffdd>", "{LightYellow}")
                            .Replace("<#ddddff>", "{LightPurple}")
                            .Replace("AGL", "{AGL}")
                            .Replace("ATK", "{ATK}")
                            .Replace("DEF", "{DEF}")
                            .Replace("DEX", "{DEX}")
                            .Replace("DMG", "{DMG}")
                            .Replace("MAG", "{MAG}")
                            .Replace("MGR", "{MGR}")
                            .Replace("MOV", "{MOV}"),
                    });
                    ids.Add(text, id);
                }
            }

            foreach (var item in information)
            {
                Add(new GroundTypeId(item.Id), item.Name.English);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\GroundTypes.json";
            StructuredJson.Write(gp, lines);
        }
        
        public static void Main_Magic(string[] args)
        {
            MagicData[] information = DB.ReadAll<MagicData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\magicData.txt");

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(MagicDataId id, String text)
            {
                lines.Add(id.ToString(), new TransifexEntry()
                {
                    Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine)
                        .Replace("<#88aaff>", "{Blue}")
                        .Replace("<#ffdd00>", "{Yellow}")
                        .Replace("<#5eff00>", "{Green}")
                        .Replace("<#ffffff>", "{White}")
                        .Replace("<#ffffdd>", "{LightYellow}")
                        .Replace("<#ddddff>", "{LightPurple}")
                        .Replace("AGL", "{AGL}")
                        .Replace("ATK", "{ATK}")
                        .Replace("DEF", "{DEF}")
                        .Replace("DEX", "{DEX}")
                        .Replace("DMG", "{DMG}")
                        .Replace("MAG", "{MAG}")
                        .Replace("MGR", "{MGR}")
                        .Replace("MOV", "{MOV}"),
                });
            }

            foreach (var item in information)
            {
                Add(new MagicDataId(item.Id, nameof(item.Name)), item.Name.English);
                Add(new MagicDataId(item.Id, nameof(item.Description)), item.Description.English);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Magic.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_Classes(string[] args)
        {
            ClassData[] information = DB.ReadAll<ClassData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\classData.txt");

            // Dictionary<String, CharacterDataId> ids = new Dictionary<String, CharacterDataId>();
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(ClassDataId id, String text)
            {
                lines.Add(id.ToString(), new TransifexEntry()
                {
                    Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine),
                });
            }

            foreach (var item in information)
            {
                Add(new ClassDataId(item.Id, nameof(item.DisplayName)), item.DisplayName.English);
                Add(new ClassDataId(item.Id, nameof(item.Description)), item.Description.English);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Classes.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main1(string[] args)
        {
            CharacterData[] information = DB.ReadAll<CharacterData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\charactorData.txt");

            Dictionary<String, CharacterDataId> ids = new Dictionary<String, CharacterDataId>();
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(CharacterDataId id, String text)
            {
                if (ids.TryGetValue(text, out CharacterDataId knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine),
                    });
                    ids.Add(text, id);
                }
            }

            for (var index = 0; index < information.Length; index++)
            {
                var item = information[index];
                Add(new CharacterDataId(index), item.DisplayName.English);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Characters.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_Items(string[] args)
        {
            ItemData[] information = DB.ReadAll<ItemData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\itemData.txt");

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(ItemDataId id, String text, String comment)
            {
                lines.Add(id.ToString(), new TransifexEntry()
                {
                    Text = text
                        .Replace('，', ',')
                        .Replace("⏎", Environment.NewLine)
                        .Replace("<#88aaff>", "{Blue}")
                        .Replace("<#ffdd00>", "{Yellow}")
                        .Replace("<#ffffff>", "{White}")
                        .Replace("AGL", "{AGL}")
                        .Replace("ATK", "{ATK}")
                        .Replace("DEF", "{DEF}")
                        .Replace("DEX", "{DEX}")
                        .Replace("DMG", "{DMG}")
                        .Replace("MAG", "{MAG}")
                        .Replace("MGR", "{MGR}")
                        .Replace("MOV", "{MOV}"),

                    Comment = comment
                });
            }

            foreach (var item in information)
            {
                var context = item.Name.English;

                Add(new ItemDataId(item.Id, nameof(item.Name)), item.Name.English, context);
                Add(new ItemDataId(item.Id, nameof(item.Description)), item.Description.English, context);
                Add(new ItemDataId(item.Id, nameof(item.ShortDescription)), item.ShortDescription.English, context);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Items.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_Skills(string[] args)
        {
            SkillData[] information = DB.ReadAll<SkillData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\skillData.txt");

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(SkillDataId id, String text, String comment)
            {
                lines.Add(id.ToString(), new TransifexEntry()
                {
                    Text = text.Replace('，', ',')
                        .Replace("⏎", Environment.NewLine)
                        .Replace("<#88aaff>", "{Blue}")
                        .Replace("<#ffdd00>", "{Yellow}")
                        .Replace("<#ffffff>", "{White}")
                        .Replace("AGL", "{AGL}")
                        .Replace("ATK", "{ATK}")
                        .Replace("DEF", "{DEF}")
                        .Replace("DEX", "{DEX}")
                        .Replace("DMG", "{DMG}")
                        .Replace("MAG", "{MAG}")
                        .Replace("MGR", "{MGR}")
                        .Replace("MOV", "{MOV}"),
                    Comment = comment
                });
            }

            foreach (var item in information)
            {
                var context = item.Name.English;

                Add(new SkillDataId(item.Id, nameof(item.Name)), item.Name.English, context);
                Add(new SkillDataId(item.Id, nameof(item.Description)), item.Description.English, context);
                Add(new SkillDataId(item.Id, nameof(item.ShortDescription)), item.ShortDescription.English, context);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\Skills.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_ScenarioInfo(string[] args)
        {
            ScenarioData[] information = DB.ReadAll<ScenarioData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\scenarioInfoData.txt");

            Dictionary<String, ScenarioDataId> ids = new Dictionary<String, ScenarioDataId>();
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(ScenarioDataId id, String text, String comment)
            {
                if (ids.TryGetValue(text, out ScenarioDataId knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                        Comment = comment
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text.Replace('，', ',').Replace("⏎", Environment.NewLine),
                        Comment = comment
                    });
                    ids.Add(text, id);
                }
            }

            foreach (var item in information)
            {
                var context = $"{item.StageTitle.English} (Stage {item.StageNumber}, Chapter: {item.ChapterNumber})";

                Add(new ScenarioDataId(item.Id, nameof(item.StageTitle)), item.StageTitle.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.StageProlog)), item.StageProlog.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.StageHint)), item.StageHint.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.VictoryCondition1)), item.VictoryCondition1.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.DefeatCondition1)), item.DefeatCondition1.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.VictoryCondition2)), item.VictoryCondition2.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.DefeatCondition2)), item.DefeatCondition2.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.PlayerArmyName)), item.PlayerArmyName.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.EnemyArmyName)), item.EnemyArmyName.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.FlagName1)), item.FlagName1.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.FlagName2)), item.FlagName2.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.FlagName3)), item.FlagName3.English, context);
                Add(new ScenarioDataId(item.Id, nameof(item.FlagName4)), item.FlagName4.English, context);
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\ScenarioInfo.json";
            StructuredJson.Write(gp, lines);
        }

        public static void Main_InformationList(string[] args)
        {
            InfomationData[] information = DB.ReadAll<InfomationData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\InfomationList.txt");

            Dictionary<String, SystemDataId> ids = new Dictionary<String, SystemDataId>();
            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();

            foreach (var item in information)
            {
                SystemDataId id = new SystemDataId(item.Id, null);

                var messageId = id.ToString();
                if (ids.TryGetValue(item.MessageEnglish, out var knownId))
                {
                    lines.Add(messageId, new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                        Context = SceneTranlsations[item.Scene]
                    });
                }
                else
                {
                    lines.Add(messageId, new TransifexEntry()
                    {
                        Text = item.MessageEnglish.Replace('，', ',').Replace("⏎", Environment.NewLine),
                        Context = SceneTranlsations[item.Scene]
                    });
                    ids.Add(item.MessageEnglish, id);
                }

                for (Int32 i = 0; i < 4; i++)
                {
                    SystemDataId buttonId = new SystemDataId(item.Id, i + 1);
                    String english = item[i].English;

                    var buttonKey = buttonId.ToString();
                    if (ids.TryGetValue(english, out knownId))
                    {
                        lines.Add(buttonKey, new TransifexEntry()
                        {
                            Text = "${" + knownId + "}",
                            Context = SceneTranlsations[item.Scene]
                        });
                    }
                    else
                    {
                        lines.Add(buttonKey, new TransifexEntry()
                        {
                            Text = english.Replace('，', ',').Replace("⏎", Environment.NewLine),
                            Context = SceneTranlsations[item.Scene]
                        });

                        ids.Add(english, buttonId);
                    }
                }
            }

            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\System.json";
            StructuredJson.Write(gp, lines);
        }
        
        public static void Main_GoddessDialog_00(string[] args)
        {
            var questions = DB.ReadAll<QuestionData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\question.txt");
            var rewards = DB.ReadAll<QuestionReward>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\questionReward.txt");
            var skills = DB.ReadAll<SkillData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\skillData.txt");
            var items = DB.ReadAll<ItemData>(@"C:\Steam\steamapps\common\Langrisser I & II\csv\itemData.txt");

            var questionsDic = questions.ToDictionary(d => d.Id);
            var skillsDic = skills.ToDictionary(s => s.ClassName);
            var itemsDic = items.ToLastKeyDictionary(s => s.NameJapanese);

            String[,] skillRewardA = new String[4, 4];
            String[,] skillRewardB = new String[4, 4];
            String[,] itemRewardA = new String[4, 4];
            String[,] itemRewardB = new String[4, 4];
            String[,] itemRewardC = new String[4, 4];
            Int32 index = 0;
            foreach (var item in rewards)
            {
                if (item.Type.StartsWith("スキル"))
                {
                    String[,] list = (item.Type.EndsWith("Ａ")) ? skillRewardA : skillRewardB;

                    for (Int32 i = 0; i < 4; i++)
                    {
                        var skillData = skillsDic[item[i]];
                        list[index % 4, i] = $"{skillData.NameEnglish}: {skillData.ShortDescriptionEnglish.Replace("<#ffdd00>", "").Replace("<#ffffff>", "")}";
                    }

                    index++;
                }
                else if (item.Type.StartsWith("アイテム"))
                {
                    // Not an error: A => A, C => B, E => C
                    String[,] list = (item.Type.EndsWith("Ａ")) ? itemRewardA : item.Type.EndsWith("Ｃ") ? itemRewardB : itemRewardC;

                    for (Int32 i = 0; i < 4; i++)
                    {
                        var itemData = itemsDic[item[i]];
                        list[index % 4, i] = $"{itemData.NameEnglish}: {itemData.ShortDescriptionEnglish.Replace("<#ffdd00>", "").Replace("<#ffffff>", "")}";
                    }

                    index++;
                }
            }

            var l1 = questionsDic[questionsDic[4].NextQuestion1];
            var l2 = questionsDic[questions[5].NextQuestion1];

            OrderedDictionary<String, TransifexEntry> lines = new OrderedDictionary<String, TransifexEntry>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < questions.Length; i++)
            {
                var q = questions[i];
                sb.AppendLine("|-");
                sb.Append($"| colspan=\"3\" | [{q.Id:D2}] '''");
                sb.Append(q.QuestionEnglish).AppendLine("'''");
                sb.AppendLine("|-");

                TransifexEntry goddessEntry = new TransifexEntry()
                {
                    Text = q.QuestionEnglish.Replace('，', ',').Replace("⏎", Environment.NewLine),
                    Comment = "Lucilis (Goddess)"
                };

                var goddessKey = $"GoddessDialog_{q.Id:D2}";
                lines.Add(goddessKey, goddessEntry);

                Int32 aIndex = 0;
                foreach (var a in q.Answers)
                {
                    aIndex++;
                    sb.Append("|| ");
                    sb.Append(aIndex).Append(". ").Append(a.Answer.English).Append(' ');
                }

                sb.AppendLine();
                sb.AppendLine("|-");

                aIndex = 0;
                foreach (var a in q.Answers)
                {
                    aIndex++;

                    if (a.Answer.English == "-")
                        continue;


                    StringBuilder sb1 = new StringBuilder();
                    TransifexEntry answerEntry = new TransifexEntry()
                    {
                        Text = a.Answer.English.Replace('，', ',').Replace("⏎", Environment.NewLine)
                    };

                    var answerKey = $"GoddessDialog_{q.Id:D2}_A{aIndex}";
                    lines.Add(answerKey, answerEntry);

                    sb.Append("|| ");

                    if (a.SkillA != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Skill 1 ↓");
                    if (a.SkillB != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Skill 1 →");
                    if (a.SkillC != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Skill 2 ↓");
                    if (a.SkillD != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Skill 2 →");
                    if (a.ItemA != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Weapon: Rank Up");
                    if (a.ItemB != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Weapon: Magic Wand");
                    if (a.ItemC != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Armor: Rank Up");
                    if (a.ItemE == 1) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Accessory: Rank Up");
                    if (a.ItemE > 1) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Accessory: Boots of Wind");
                    if (a.ItemF != 0) (sb1.Length == 0 ? sb1 : sb1.Append("; ")).Append($"Accessory: Chunk of Gold");

                    if (sb1.Length == 0)
                        sb1.Append("None");

                    answerEntry.Comment = $"Reward: {sb1}";
                    sb.Append(sb1.ToString());
                    sb.Append(' ');
                }

                sb.AppendLine();
            }


            var gp = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\GoddessDialog.json";
            StructuredJson.Write(gp, lines);

            Int32 SkillA = 0;
            Int32 SkillB = 0;
            Int32 SkillC = 0;
            Int32 SkillD = 0;
            Int32 ItemA = 0;
            Int32 ItemB = 0;
            Int32 ItemC = 0;
            Int32 ItemD = 0;
            Int32 ItemE = 0;
            Int32 ItemF = 0;

            Int32 Get(Int32 value)
            {
                if (value < 0)
                    return 0;
                if (value > 3)
                    return 3;
                return value;
            }

            StringBuilder line = new StringBuilder();
            StringBuilder result = new StringBuilder();

            HashSet<String> uniqueSkills = new HashSet<String>();
            HashSet<String> uniqueItems = new HashSet<String>();
            HashSet<String> unique = new HashSet<String>();
            Traverse(questionsDic[10]);

            void Traverse(QuestionData q)
            {
                line.AppendLine(q.QuestionEnglish);

                Int32 aIndex = 0;
                foreach (var a in q.Answers)
                {
                    aIndex++;
                    if (a.Next == 0)
                        continue;

                    line.Append('\t');
                    line.AppendLine(a.Answer.English);

                    SkillA += a.SkillA;
                    SkillB += a.SkillB;
                    SkillC += a.SkillC;
                    SkillD += a.SkillD;
                    ItemA += a.ItemA;
                    ItemB += a.ItemB;
                    ItemC += a.ItemC;
                    ItemD += a.ItemD;
                    ItemE += a.ItemE;
                    ItemF += a.ItemF;

                    if (a.Next == -1)
                    {
                        var s1 = skillRewardA[Get(SkillA), Get(SkillB)];
                        var s2 = skillRewardB[Get(SkillC), Get(SkillD)];
                        var i1 = itemRewardA[Get(ItemA), Get(ItemB)];
                        var i2 = itemRewardB[Get(ItemC), Get(ItemD)];
                        var i3 = itemRewardC[Get(ItemE), Get(ItemF)];

                        uniqueSkills.Add(s1);
                        uniqueSkills.Add(s2);

                        uniqueItems.Add(i1);
                        uniqueItems.Add(i2);
                        uniqueItems.Add(i3);

                        List<String> tmp = new List<String> {s1, s2, i1, i2, i3};
                        tmp.Sort();
                        var reward = String.Join("", tmp);

                        if (unique.Add(reward))
                        {
                            result.AppendLine(Environment.NewLine);
                            result.AppendLine("-----------------------------------------");
                            var value = line.ToString();
                            result.AppendLine(value);
                            result.AppendLine(s1);
                            result.AppendLine(s2);
                            result.AppendLine(i1);
                            result.AppendLine(i2);
                            result.AppendLine(i3);
                        }
                    }
                    else
                    {
                        Traverse(questionsDic[a.Next]);
                    }

                    line.Length -= a.Answer.English.Length + Environment.NewLine.Length + 1;

                    SkillA -= a.SkillA;
                    SkillB -= a.SkillB;
                    SkillC -= a.SkillC;
                    SkillD -= a.SkillD;
                    ItemA -= a.ItemA;
                    ItemB -= a.ItemB;
                    ItemC -= a.ItemC;
                    ItemD -= a.ItemD;
                    ItemE -= a.ItemE;
                    ItemF -= a.ItemF;
                }

                line.Length -= q.QuestionEnglish.Length + Environment.NewLine.Length;
            }


            String skills1 = String.Join(Environment.NewLine + "|-" + Environment.NewLine + "| ", uniqueSkills.OrderBy(s => s).Select(s => s.Replace(": ", " || ")));
            String items1 = String.Join(Environment.NewLine + "|-" + Environment.NewLine + "| ", uniqueItems.OrderBy(s => s).Select(s => s.Replace(": ", " || ")));
        }

        public static void Main(string[] args)
        {
            Dictionary<String, String> ids = new Dictionary<String, String>();
            var lines = new OrderedDictionary<String, TransifexEntry>();

            void Add(String id, String text, String comment)
            {
                String key = text + comment;
                if (ids.TryGetValue(key, out String knownId))
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = "${" + knownId + "}",
                        Comment =  comment
                    });
                }
                else
                {
                    lines.Add(id.ToString(), new TransifexEntry()
                    {
                        Text = text,
                        Comment =  comment
                    });
                    ids.Add(key, id);
                }
            }
            
            Dictionary<String, String> names = new Dictionary<String, String>();
            foreach (var item in ReadCharacterData())
            {
                names[item.Name] = item.DisplayNameEnglish;
                names[item.DisplayNameJapanese] = item.DisplayNameEnglish;
            }

            var regexes = Tags.OrderByDescending(t => t.Length).Select(t => new KeyValuePair<String, String>(t.Replace("�", ""), t)).ToArray();

            names.Add("一般兵", "Soldier");
            names.Add("一般兵Ａ", "Soldier A");
            names.Add("侍女", "Maid");
            names.Add("リアナ＆ラーナ", "Liana & Lana");
            names.Add("指揮官（ナイトマスター）", "Commander (Knight Master)");
            names.Add("モンスター", "Monster");
            names.Add("システムメッセージ", "System Message");
            names.Add("0", "System");

            // Langrisser I
            var path = @"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\eventMessage.txt";
            foreach (var group in DB.EnumerateAll<EventMessage>(path).GroupBy(m => m.ScenarioNumber))
            {
                lines.Clear();
                ids.Clear();
                foreach (var message in group)
                {
                    Add(message.GetKey(), PrepareMessage(message, regexes), $"{names[message.CharacterName]} ({message.VoiceFile})");
                }

                path = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\L1\L1_Stage_{group.Key:D3}.json";
                StructuredJson.Write(path, lines);
            }
            
            // Langrisser II
            path = @"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\eventMessage2.txt";
            foreach (var group in DB.EnumerateAll<EventMessage>(path).GroupBy(m => m.ScenarioNumber))
            {
                lines.Clear();
                ids.Clear();
                foreach (var message in group)
                {
                    Add(message.GetKey(), PrepareMessage(message, regexes), $"{names[message.CharacterName]} ({message.VoiceFile})");
                }

                path = $@"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\L2\L2_Stage_{group.Key:D3}.json";
                StructuredJson.Write(path, lines);
            }
        }

        private static readonly Dictionary<String, Int32> dic = new Dictionary<String, Int32>();

        private static String PrepareMessage(EventMessage message, KeyValuePair<String, String>[] regexes)
        {
            var prepareMessage = message.MessageEn.Replace('，', ',').Replace("⏎", Environment.NewLine);

            foreach (var regex in regexes)
            {
                var m = prepareMessage.Replace(regex.Key, '{' + regex.Value + '}');
                if (m != prepareMessage)
                {
                    dic.TryGetValue(regex.Key, out var count);
                    dic[regex.Key] = count + 1;
                    prepareMessage = m;
                }
            }

            prepareMessage = prepareMessage.Replace("�", "");
            return prepareMessage;
        }

        public static CharacterData[] ReadCharacterData()
        {
            var path = @"C:\Steam\steamapps\common\Langrisser I & II\csv\csv\Resources\csv\charactorData.txt";
            return DB.ReadAll<CharacterData>(path);
        }


        public static String[] Tags =
        {
            "A�lbert",
            "B�aldea",
            "B�aldean",
            "B�etty",
            "B�oser",
            "C�aptain",
            "C�haos",
            "C�hris",
            "D�alsis",
            "D�ark Prince",
            "D�igos",
            "G�alious",
            "G�orgh",
            "H�awking",
            "I�llzach",
            "J�essica",
            "K�aiser",
            "L�aetitia",
            "L�aias",
            "L�ance",
            "L�angrisser",
            "L�edin",
            "L�ord",
            "N�agya",
            "N�arm",
            "N�icolis",
            "S�alrath",
            "S�HIKA",
            "T�aylor",
            "T�horn",
            "V�elzeria",
            "V�olkoff",
            "X�eld",
            "Y�our Highness",
            "Y�our Majesty",
        };

        public static IEnumerable<String> Check(Regex regex, String value)
        {
            Queue<String> values = new Queue<String>();
            values.Enqueue(value);

            StringBuilder sb = new StringBuilder();

            while (values.Count > 0)
            {
                var mm = regex.Matches(values.Dequeue());
                foreach (Match m in mm)
                {
                    if (m.Success)
                    {
                        var ss = m.Value;
                        yield return ss;

                        var items = ss.Split(' ');
                        if (items.Length > 1)
                        {
                            for (int i = 0; i < items.Length; i++)
                            {
                                var startItem = items[i];
                                if (startItem.Length < 2 || !Char.IsUpper(startItem[0]))
                                    continue;

                                yield return startItem;
                                sb.Append(startItem);
                                for (int n = i + 1; n < items.Length; n++)
                                {
                                    sb.Append(' ');
                                    sb.Append(items[n]);
                                    yield return sb.ToString();
                                }

                                sb.Length = 0;
                            }

                            //values.Enqueue(ss.Substring(1));
                        }
                    }
                }
            }
        }

        private static readonly Dictionary<String, String> SceneTranlsations = new Dictionary<String, String>
        {
            {"ＣＰ獲得", "CP acquisition"},
            {"アイテムショップ中", "In the item shop"},
            {"アイテムショップ入口メニュー", "Item shop entrance menu"},
            {"アイテムスロット選択", "Item slot selection"},
            {"アイテムでスキル習得", "Skill acquisition with items"},
            {"アイテムで傭兵獲得", "Get mercenaries with items"},
            {"アイテムで魔法習得", "Master magic with items"},
            {"アイテム取得", "Get item"},
            {"インターミッションメイン", "Intermission main"},
            {"エンドセーブ警告", "End save warning"},
            {"キーアサイン", "Key assignment"},
            {"クラスツリー", "Class tree"},
            {"クラス警告", "Class warning"},
            {"クリアボーナス", "Clear bonus"},
            {"ゲーム選択", "Game selection"},
            {"コンフィグ", "Config"},
            {"コンフィグ確認", "Configuration check"},
            {"シナリオツリー", "Scenario tree"},
            {"シナリオツリー体験版", "Scenario tree trial version"},
            {"スキルスロット選択", "Skill slot selection"},
            {"スキル取得", "Skill acquisition"},
            {"セーブロード入口メニュー", "Save Road Entrance Menu"},
            {"セーブ確認", "Save confirmation"},
            {"セーブ確認画面", "Save confirmation screen"},
            {"その他１", "Other 1"},
            {"その他２", "Other 2"},
            {"その他３", "Other 3"},
            {"その他４", "Other 4"},
            {"タイトルorメインメニューへ戻る", "Return to title or main menu"},
            {"タイトル画面に戻る", "Return to title screen"},
            {"チャレンジモード", "Challenge mode"},
            {"バックログ", "Back log"},
            {"バックログ用再生ボタン", "Play button for backlog"},
            {"マニュアル表示時", "Manual display"},
            {"メインメニューのストーリー表示", "Main menu story display"},
            {"メインメニューのミニマップ表示", "Mini-map display of main menu"},
            {"メインメニューへ戻る", "Return to main menu"},
            {"メッセージウィンドウ", "Message window"},
            {"ラング１開始選択", "Rung 1 start selection"},
            {"ラング２開始選択", "Rung 2 start selection"},
            {"ルシリスの質問後", "After Luciris's question"},
            {"ロード確認", "Load confirmation"},
            {"ロード確認画面", "Load confirmation screen"},
            {"中断セーブ体験版", "Suspended save trial version"},
            {"体験版特典", "Trial benefits"},
            {"個別コマンド：指示操作", "Individual command: Directed operation"},
            {"傭兵取得", "Mercenary acquisition"},
            {"傭兵選択メニュー（戦闘準備）", "Mercenary selection menu (battle preparation)"},
            {"傭兵選択メニュー（閲覧）", "Mercenary selection menu (view)"},
            {"傭兵雇用メニュー", "Mercenary employment menu"},
            {"全体コマンド", "Whole command"},
            {"再確認", "reconfirmation"},
            {"再開確認", "Confirmation of restart"},
            {"出撃確認", "Sortie confirmation"},
            {"初回特典ＤＬＣ", "First time benefits DLC"},
            {"周回セーブ", "Lap save"},
            {"売却確認", "Sale confirmation"},
            {"戦闘準備メニュー", "Battle preparation menu"},
            {"戦闘開始確認", "Battle start confirmation"},
            {"戻り確認画面１", "Return confirmation screen 1"},
            {"戻り確認画面２", "Return confirmation screen 2"},
            {"指揮官メニュー", "Commander menu"},
            {"指揮官入れ替えメニュー", "Commander replacement menu"},
            {"指揮官詳細", "Commander details"},
            {"指揮官詳細（マップ）", "Commander details (map)"},
            {"指揮官選択メニュー", "Commander selection menu"},
            {"特典ＤＬＣ警告", "Privilege DLC warning"},
            {"終了確認", "Finish confirmation"},
            {"縮小マップ表示時", "When the reduced map is displayed"},
            {"装備アイテム選択", "Equipment item selection"},
            {"装備スキル選択", "Equipment skill selection"},
            {"資金獲得", "Fund acquisition"},
            {"購入確認", "Purchase confirmation"},
            {"追加コンテンツ権利無し", "No additional content rights"},
            {"部隊表", "Unit table"},
            {"魔法リスト選択（マップ）", "Magic list selection (map)"},
            {"魔法リスト選択（閲覧）", "Magic list selection (browsing)"},
            {"魔法リスト選択（魔法選択）", "Magic list selection (magic selection)"},
            {"魔法取得", "Magic acquisition"},
            {"魔法選択関係", "Magic selection relationship"},
            {"-", "None"},
        };

    }
}