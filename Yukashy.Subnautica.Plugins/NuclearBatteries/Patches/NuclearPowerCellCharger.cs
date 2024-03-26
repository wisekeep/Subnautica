using static NuclearBatteries.Items.Equipment.NuclearCells;

namespace NuclearBatteries.Patches;

[HarmonyPatch(typeof(PowerCellCharger))]
internal class PowerCellChargerPatch
{
    [HarmonyPatch(nameof(PowerCellCharger.Initialize))]
    [HarmonyPostfix]
    public static void Initialize(PowerCellCharger instance)
    {
        if (!instance.allowedTech.Contains(TechType.PowerCell))
            instance.allowedTech.Add(Info.TechType);
    }
}

internal class NuclearPowerCellCharger
{
}