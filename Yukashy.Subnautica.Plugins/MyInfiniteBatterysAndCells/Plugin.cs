using MyInfiniteBatterysAndCells.Items.Equipment;

namespace MyInfiniteBatterysAndCells
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    internal class MyInfiniteBatterysAndCells : BaseUnityPlugin
    {
        #region[BepInPlugin]
        internal const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        internal const string PLUGIN_NAME = "MyInfiniteBatterysAndCells";
        internal const string PLUGIN_VERSION = "1.0.0";
        #endregion
        internal static PluginConfig MyConfig { get; private set; } = OptionsPanelHandler.RegisterModOptions<PluginConfig>();
        internal static ManualLogSource LogSource { get; private set; }

        internal void Awake()
        {
            LogSource = Logger;
            LogSource.LogInfo($">> Loading harmony patches for {PLUGIN_GUID}..");

            Harmony harmony = new(PLUGIN_GUID);
            harmony.PatchAll();

            LogSource.LogInfo($"Plugin {PLUGIN_NAME} is loaded!");

            InfiniteBatteries.Patch();
            InfiniteCells.Patch();
        }
    }
}
