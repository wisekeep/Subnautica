using MyInfiniteBatterysAndCells.Items.Equipment;

namespace MyInfiniteBatterysAndCells
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class MyInfiniteBatterysAndCells : BaseUnityPlugin
    {
        #region[BepInPlugin]
        public const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        public const string PLUGIN_NAME = "MyInfiniteBatterysAndCells";
        public const string PLUGIN_VERSION = "1.0.0";
        #endregion
        internal static PluginConfig MyConfig { get; private set; } = OptionsPanelHandler.RegisterModOptions<PluginConfig>();
        public static ManualLogSource LogSource { get; private set; }

        private static readonly Harmony harmony = new(PLUGIN_GUID);
        public void Awake()
        {
            harmony.PatchAll();
            LogSource = Logger;
            LogSource.LogInfo($">> Loading harmony patches for {PLUGIN_GUID}..");
            LogSource.LogInfo($"Plugin {PLUGIN_NAME} is loaded!");

            InfiniteBatteries.Patch();
            InfiniteCells.Patch();
        }
    }
}
