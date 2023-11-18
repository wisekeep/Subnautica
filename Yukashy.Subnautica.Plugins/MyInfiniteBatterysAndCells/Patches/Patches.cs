namespace MyInfiniteBatterysAndCells.Patches
{
    internal class Patches
    {
        [HarmonyPatch(typeof(BatteryCharger))]
        internal class BatteryChargerPatch
        {
            [HarmonyPatch(nameof(BatteryCharger.Initialize)), HarmonyPostfix]
            public static void Initialize(BatteryCharger __instance)
            {
                if (!__instance.allowedTech.Contains(Items.Equipment.InfiniteBatteries.TechType))
                    __instance.allowedTech.Add(Items.Equipment.InfiniteBatteries.TechType);
            }
        }

        [HarmonyPatch(typeof(PowerCellCharger))]
        internal class PowerCellChargerPatch
        {
            [HarmonyPatch(nameof(PowerCellCharger.Initialize)), HarmonyPostfix]
            public static void Initialize(PowerCellCharger __instance)
            {
                if (!__instance.allowedTech.Contains(Items.Equipment.InfiniteCells.TechType))
                    __instance.allowedTech.Add(Items.Equipment.InfiniteCells.TechType);
            }
        }
    }
}
