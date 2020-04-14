using System.IO;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace WandererStringsLoader
{
	public class Main : MBSubModuleBase
	{
		private string[] FindWandererStringsXMLs()
		{
			string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string currentModuleDir = Path.Combine(assemblyDir, "..", "..");
			string moduleDataDir = Path.Combine(currentModuleDir, "ModuleData");
			string[] wandererXMLFiles = Directory.GetFiles(moduleDataDir, "wanderer_strings*.xml");
			return wandererXMLFiles;
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
			CampaignGameStarter gameInitializer = (CampaignGameStarter)initializerObject;
			this.LoadWandererStringsXMLs(gameInitializer);
		}

		public override void OnNewGameCreated(Game game, object initializerObject)
		{
			CampaignGameStarter gameInitializer = (CampaignGameStarter)initializerObject;
			this.LoadWandererStringsXMLs(gameInitializer);
		}
	}
}