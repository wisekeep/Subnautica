using static NuclearBatteries.Items.GlobalTexture;

namespace NuclearBatteries.Items.Equipment;

public static class NuclearBatteries
{
    public static void Patch()
    {
        Info = PrefabInfo
            .WithTechType(ClassId, DisplayName, Description, Language, UnlockAtStart)
            .WithSizeInInventory(new Vector2int(1, 1))
            .WithIcon(NuclearBatteryIcon);

        _nuclearBatteryPrefab = new CustomPrefab(Info);
        _nuclearBatteryClone = new CloneTemplate(Info, TechType.ReactorRod)
        {
            ModifyPrefab = go =>
            {
                var wasActive = go.activeSelf;
                if (wasActive) go.SetActive(false);
                _battery = go.EnsureComponent<Battery>();
                _battery.GetComponentInChildren<Battery>(true);
                _battery._capacity = NuclearPowerBattery;
                if (_battery != null)
                    _battery.charge = _battery.capacity;

                _batteryRenderer = go.GetComponentInChildren<MeshRenderer>(true);
                _batteryRenderer.material.SetTexture(ShaderPropertyID._MainTex, BTe);
                _batteryRenderer.material.SetTexture(ShaderPropertyID._Illum, BIl);

                if (wasActive) go.SetActive(true);
            }
        };

        _nuclearBatteryPrefab.SetGameObject(_nuclearBatteryClone);

        RecipeData recipe = new()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.Battery),
                new Ingredient(TechType.UraniniteCrystal, 2),
                new Ingredient(TechType.ReactorRod)
            }
        };

        _ = _nuclearBatteryPrefab.SetRecipe(recipe)
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(1f);

        _ = _nuclearBatteryPrefab.SetUnlock(TechType.Battery);

        _ = _nuclearBatteryPrefab.SetEquipment(EquipmentType.BatteryCharger);

        _ = _nuclearBatteryPrefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

        _nuclearBatteryPrefab.Register();
    }

    #region[Declarations]

    private const string ClassId = "NuclearBattery",
        DisplayName = "My Nuclear Battery",
        Description = "A Nuclear powerful battery!",
        Language = "English";

    private const bool UnlockAtStart = false;

    private const float NuclearPowerBattery = 10000f;

    //
    public static PrefabInfo Info;
    private static CustomPrefab _nuclearBatteryPrefab;
    private static PrefabTemplate _nuclearBatteryClone;
    private static Battery _battery;
    private static Renderer _batteryRenderer;

    #endregion
}