using NuclearBatteries.Items.Equipment;
using PluginInfo = Nautilus.PluginInfo;

#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"
#pragma warning disable IDE0051 // Remove unused private members

namespace NuclearBatteries;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
//[BepInDependency(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus", BepInDependency.DependencyFlags.HardDependency)]
[BepInIncompatibility("com.ahk1221.smlhelper")]
[BepInProcess("Subnautica.exe")]
public class Plugin : BaseUnityPlugin
{
    public static ManualLogSource LogSource;

    private static Assembly Assembly => Assembly.GetExecutingAssembly();

    private void Awake()
    {
        // plugin startup logic
        LogSource = Logger;

        // register harmony patches, if there are any
        Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");
        LogSource.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

        Items.Equipment.NuclearBatteries.Patch();
        NuclearCells.Patch();
    }

    #region[BepInPlugin]

    private const string PLUGIN_GUID = $"com.yukashy.{PLUGIN_NAME}.ver.{PLUGIN_VERSION}";
    private const string PLUGIN_NAME = "NuclearBatteries";
    private const string PLUGIN_VERSION = "1.0.0";

    #endregion
}