using static NuclearBatteries.Items.GlobalTexture;

namespace NuclearBatteries.Items.Equipment;

public static class NuclearCells
{
    public static void Patch()
    {
        Info = PrefabInfo
            .WithTechType(ClassId, DisplayName, Description, Language, UnlockAtStart)
            .WithIcon(NuclearCellIcon)
            .WithSizeInInventory(new Vector2int(1, 1));
        _nuclearCellPrefab = new CustomPrefab(Info);
        _nuclearCellClone = new CloneTemplate(Info, TechType.PrecursorIonPowerCell)
        {
            ModifyPrefab = go =>
            {
                var wasActive = go.activeSelf;
                if (wasActive) go.SetActive(false);
                _cell = go.EnsureComponent<Battery>();
                _cell.GetComponentInChildren<Battery>(true);
                _cell._capacity = NuclearPowerCell;
                if (_cell != null)
                    _cell.charge = _cell.capacity;

                _cellRenderer = go.GetComponentInChildren<MeshRenderer>(true);
                _cellRenderer.material.SetTexture(ShaderPropertyID._MainTex, CTe);
                _cellRenderer.material.SetTexture(ShaderPropertyID._Illum, CIl);

                if (wasActive) go.SetActive(true);
            }
        };
        _nuclearCellPrefab.SetGameObject(_nuclearCellClone);

        RecipeData recipe = new()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(NuclearBatteries.Info.TechType, 2),
                new Ingredient(TechType.UraniniteCrystal, 4),
                new Ingredient(TechType.AcidMushroom, 2)
            }
        };

        _ = _nuclearCellPrefab.SetRecipe(recipe)
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(1f);

        _ = _nuclearCellPrefab.SetUnlock(TechType.Battery);

        _ = _nuclearCellPrefab.SetEquipment(EquipmentType.PowerCellCharger);

        _ = _nuclearCellPrefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

        _nuclearCellPrefab.Register();
    }

    #region[Declarations]

    private const string ClassId = "NuclearCell",
        DisplayName = "My Nuclear Cell",
        Description = "A Nuclear powerful battery!",
        Language = "English";

    private const bool UnlockAtStart = false;

    private const float NuclearPowerCell = 20000f;

    //
    public static PrefabInfo Info;
    private static CustomPrefab _nuclearCellPrefab;
    private static PrefabTemplate _nuclearCellClone;
    private static Battery _cell;
    private static Renderer _cellRenderer;

    #endregion
}