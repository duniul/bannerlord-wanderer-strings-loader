using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace WandererStringsLoader
{
    public class SubModule : MBSubModuleBase
    {
        static bool isDefaultModuleDir(string dir)
        {
            HashSet<string> defaultModuleDirs = new HashSet<string> { "SandBox", "SandBoxCore", "StoryMode", "CustomBattle", "Native" };
            string dirname = Path.GetFileName(dir);
            return defaultModuleDirs.Contains(dirname);
        }

        private string[] FindWandererStringsXMLs()
        {
            string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string currentModuleDir = Path.Combine(assemblyDir, "..", "..");
            string modulesDir = Path.Combine(currentModuleDir, "..");
            string[] moduleDirs = Directory.GetDirectories(modulesDir, "*", SearchOption.TopDirectoryOnly);

            List<string> allWandererStringsList = new List<string>();

            foreach (string moduleDir in moduleDirs)
            {
                if (isDefaultModuleDir(moduleDir))
                {
                    continue;
                }

                string moduleDataDir = Path.Combine(moduleDir, "ModuleData");

                if (Directory.Exists(moduleDataDir))
                {
                    string[] wandererStringsFiles = Directory.GetFiles(moduleDataDir, "wanderer_strings_*.xml", SearchOption.TopDirectoryOnly);
                    allWandererStringsList.AddRange(wandererStringsFiles);
                }
            }

            return allWandererStringsList.ToArray();
        }

        private void LoadWandererStringsXMLs(CampaignGameStarter gameInitializer)
        {
            string[] wandererXMLFiles = this.FindWandererStringsXMLs();

            foreach (string filePath in wandererXMLFiles)
            {
                gameInitializer.LoadGameTexts(filePath);
            }
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);
            this.LoadWandererStringsXMLs((CampaignGameStarter)initializerObject);
        }

        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            base.OnNewGameCreated(game, initializerObject);
            this.LoadWandererStringsXMLs((CampaignGameStarter)initializerObject);
        }
    }
}