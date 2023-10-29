#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

using MyInfiniteBatterysAndCells.Items.Equipment;

namespace MyInfiniteBatterysAndCells
{
    #region[BepInPlugin]
    public static class MyInfo
    {
        public const string MY_PLUGIN_GUID = $"com.yukashy.{MyPluginInfo.PLUGIN_NAME}.ver.{MyPluginInfo.PLUGIN_VERSION}";
    }
    #endregion
    
    [BepInPlugin(MyInfo.MY_PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class Plugin : BaseUnityPlugin
    {
        //internal static ModOptions config { get; } = OptionsPanelHandler.RegisterModOptions<ModOptions>();

        public static new ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // plugin startup logic
            Logger = base.Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{MyInfo.MY_PLUGIN_GUID}");

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is loaded!");

            //CreateInfinityBattery.Register();

        }
    }
}