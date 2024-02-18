
namespace NuclearBatteries.Patches
{
    [HarmonyPatch(typeof(BatteryCharger))]
    internal class BatteryChargerPatch
    {
        [HarmonyPatch(nameof(BatteryCharger.Initialize)), HarmonyPostfix]
        public static void Initialize(BatteryCharger __instance)
        {
            if (!__instance.allowedTech.Contains(Items.Equipment.NuclearBatteries.NuclearBattery.Info.TechType))
                __instance.allowedTech.Add(Items.Equipment.NuclearBatteries.NuclearBattery.Info.TechType);
        }
    }

    [HarmonyPatch(typeof(PowerCellCharger))]
    internal class PowerCellChargerPatch
    {
        [HarmonyPatch(nameof(PowerCellCharger.Initialize)), HarmonyPostfix]
        public static void Initialize(PowerCellCharger __instance)
        {
            if (!__instance.allowedTech.Contains(Items.Equipment.NuclearCells. .Prefab.Info.TechType))
                __instance.allowedTech.Add(Items.Equipment.NuclearCells.  Prefab.Info.TechType);
        }
    }
}
