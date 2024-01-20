using static MyInfiniteBatterysAndCells.GlobalTexture;

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public class InfiniteCells
    {
        #region[Declarations]
        public static Battery Cells { get; private set; }

        public const string classId = "MyInfiniteCells",
                            displayName = "My Infinite Cell",
                            description = "A god powerful cell to make!",
                            language = "English";
        public const bool unlockAtStart = true;
        public static bool wasActive;
        #endregion

        #region[Prefab Declarations]
        public static PrefabInfo Info { get; private set; } = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(Sprite_Cell)
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechType { get; private set; }
        public static CustomPrefab InfiniteCell { get; private set; }
        public static PrefabTemplate InfiniteCellClone { get; private set; }
        public static RecipeData Recipe { get; private set; }
        #endregion

        public static void Patch()
        {
            TechType = Info.TechType;

            InfiniteCell = new(Info);

            InfiniteCellClone = new CloneTemplate(Info, TechType.PowerCell)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    Cells = go.EnsureComponent<Battery>();
                    Cells._capacity = MyInfiniteBatterysAndCells.MyConfig.configPowercellEnergy;

                    if (wasActive) go.SetActive(true);
                }
            };

            Recipe = new()
            {
                craftAmount = 1,
                Ingredients =
                        {
                            new Ingredient(TechType.Silicone, 1),
                            new Ingredient(TechType.Quartz, 1),
                            new Ingredient(InfiniteBatteries.Info.TechType, 2),
                        },
            };

            _ = InfiniteCell.SetRecipe(Recipe)
                            .WithFabricatorType(CraftTree.Type.Fabricator)
                            .WithStepsToFabricatorTab("Resources", "Electronics")
                            .WithCraftingTime(0.5f);

            //_ = infiniteBattery.SetUnlock(TechType.AcidMushroom);

            _ = InfiniteCell.SetEquipment(EquipmentType.PowerCellCharger);

            _ = InfiniteCell.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            InfiniteCell.SetGameObject(InfiniteCellClone);

            InfiniteCell.Register();
        }
    }
}
