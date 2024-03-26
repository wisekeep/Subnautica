
using MySeamothModules.Items.Equipment.DepthModules;

namespace MySeamothModules
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class MySeamothModules : BaseUnityPlugin
    {
        #region[BepInPlugin]
        private const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        private const string PLUGIN_NAME = "MySeamothModules";
        private const string PLUGIN_VERSION = "1.0.0";
        #endregion

        internal static PluginConfig MyConfig { get; private set; } = OptionsPanelHandler.RegisterModOptions<PluginConfig>();
        public static ManualLogSource LogSource { get; private set; }
        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            LogSource = base.Logger;

            Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");
            LogSource.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

            InitializePrefabs();

        }

        private void InitializePrefabs()
        {
            SeamothMK4.Register();
            SeamothMK5.Register();

            SaveUtils.RegisterOnSaveEvent(MyConfig.Save);
        }

        [Menu("")]
        public class PluginConfig : ConfigFile
        {
            [Slider("<color=#FFFF00>ReactorRod</color> XXXXXXXXXX X", Format = "{0:F0}", DefaultValue = 10f, Min = 10f, Max = 1000f, Step = 10f)]
            public float multiply = 10f;
        }
    }
}