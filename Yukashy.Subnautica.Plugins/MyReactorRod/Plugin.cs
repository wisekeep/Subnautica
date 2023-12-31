﻿namespace MyReactorRod
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class MyReactorRod : BaseUnityPlugin
    {
        #region[BepInPlugin]
        private const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        private const string PLUGIN_NAME = "MyReactorRod";
        private const string PLUGIN_VERSION = "1.0.0";
        #endregion

        internal static PluginConfig MyConfig { get; set; } = OptionsPanelHandler.RegisterModOptions<PluginConfig>();
        internal static ManualLogSource LogSource { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // plugin startup logic
            LogSource = Logger;

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

            InitializePrefabs();

        }

        private void InitializePrefabs()
        {
            Dictionary<TechType, float> chargeDict = AccessTools.StaticFieldRefAccess<BaseNuclearReactor, Dictionary<TechType, float>>("charge");

            if (chargeDict != null)
            {
                if (chargeDict.TryGetValue(TechType.ReactorRod, out float oldValue))
                {
                    float mySet = MyConfig.multiply;
                    float newValue = (oldValue * mySet);

                    chargeDict[TechType.ReactorRod] = (float)newValue;

                    LogSource.LogInfo($"Plugin {PLUGIN_NAME} change a PowerRod capacity from {oldValue:N0} to {newValue:N0} info {mySet:N0} .");
                }
                else

                {
                    LogSource.LogWarning($"Plugin {PLUGIN_NAME} has FAILED loading. Could not access power rod capacity for BaseNuclearReactor.");
                }

            }
            else
            {
                LogSource.LogError($"Plugin {PLUGIN_NAME} has FAILED loading. Could not access private static field 'charge' of class BaseNuclearReactor.");
            }

            SaveUtils.RegisterOnSaveEvent(MyConfig.Save);
        }
    }
}