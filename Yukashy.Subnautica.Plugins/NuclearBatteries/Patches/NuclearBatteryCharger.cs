using static NuclearBatteries.Items.Equipment.NuclearBatteries;

namespace NuclearBatteries.Patches;

[HarmonyPatch(typeof(BatteryCharger))]
internal class BatteryChargerPatch
{
    [HarmonyPatch(nameof(BatteryCharger.Initialize))]
    [HarmonyPostfix]
    public static void Initialize(BatteryCharger instance)
    {
        if (!instance.allowedTech.Contains(TechType.Battery))
            instance.allowedTech.Add(Info.TechType);
    }
}

internal class NuclearBatteryCharger
{
}