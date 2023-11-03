
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using MyInfiniteBatterysAndCells.Items.Equipment;
using Utilities;
using Nautilus.Handlers;

namespace MyInfiniteBatterysAndCells
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInProcess("Subnautica.exe")]
    public class MyInfiniteBatterysAndCells : BaseUnityPlugin
    {
        #region[BepInPlugin]
        public const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
        private const string PLUGIN_NAME = "MyInfiniteBatterysAndCells";
        private const string PLUGIN_VERSION = "1.0.0";
        #endregion

        //internal static ModOptions config { get; } = OptionsPanelHandler.RegisterModOptions<ModOptions>();

        public static new ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {

            var myCustomEquipmentType = EnumHandler.AddEntry<EquipmentType>("MyInfiniteBatterysAndCells");

            // plugin startup logic
            Logger = base.Logger;


            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");

            Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

            PiracyDetector.TryFindPiracy();

            InfiniteBatteries.Register();

        }
    }
}