﻿#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"
#pragma warning disable IDE0051 // Remove unused private members

using SeamothModules.Items.Equipment.DepthModules;
using static OVRHaptics;

namespace SeamothModules
{
    //[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class Plugin : BaseUnityPlugin
    {
        #region[BepInPlugin]
        private const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        private const string PLUGIN_NAME = "SeamothModules";
        private const string PLUGIN_VERSION = "1.0.0";
        #endregion

        public static ManualLogSource LogSource { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();


        private void Awake()
        {
            // plugin startup logic
            LogSource = base.Logger;

            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");
            LogSource.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {
            SeamothMK4.Register();
            SeamothMK5.Register();
        }
    }
}