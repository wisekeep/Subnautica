using NuclearBatteries.Items.Equipment;

namespace NuclearBatteries.Patches;

[HarmonyPatch(typeof(EnergyMixin))]
internal class EnergyMixinPatches
{
    [HarmonyPatch(nameof(EnergyMixin.Start))]
    [HarmonyPostfix]
    public static void Start(EnergyMixin instance)
    {
        if (instance.compatibleBatteries.Contains(TechType.Battery))
            instance.compatibleBatteries.Add(Items.Equipment.NuclearBatteries.Info.TechType);
        instance.allowBatteryReplacement = true;
        instance.allowedToPlaySounds = true;

        if (instance.compatibleBatteries.Contains(TechType.PowerCell))
            instance.compatibleBatteries.Add(NuclearCells.Info.TechType);
        instance.allowBatteryReplacement = true;
        instance.allowedToPlaySounds = true;
    }

    [HarmonyPatch(typeof(EnergyMixin), nameof(EnergyMixin.NotifyHasBattery))]
    [HarmonyPostfix]
    public static void NotifyHasBattery(ref EnergyMixin instance, InventoryItem item)
    {
        List<TechType> nuclearCells = new() { NuclearCells.Info.TechType };

        if (nuclearCells.Count == 0) return;

        var itemInSlot = item?.item?.GetTechType();

        if (!itemInSlot.HasValue || itemInSlot.Value == TechType.None)
            return;

        var powerCellTechType = itemInSlot.Value;

        var isKnownModdedPowerCell = nuclearCells.Find(techType => techType == powerCellTechType) != TechType.None;

        if (isKnownModdedPowerCell)
        {
            var modelToDisplay =
                0; // If a matching model cannot be found, the standard PowerCell model will be used instead.
            for (var b = 0; b < instance.batteryModels.Length; b++)
                if (instance.batteryModels[b].techType == powerCellTechType)
                {
                    modelToDisplay = b;
                    break;
                }

            instance.batteryModels[modelToDisplay].model.SetActive(true);
        }
    }
}