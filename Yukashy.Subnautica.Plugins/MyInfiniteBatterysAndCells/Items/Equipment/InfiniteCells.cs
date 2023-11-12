

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public static class InfiniteCells
    {
        #region[Declarations]
        public static Atlas.Sprite sprite { get; set; }
        public static Battery cells { get; set; }
        public static TechType TechType { get; set; }
        public static PrefabInfo Info { get; set; }
        public static float powercellEnergy { get; set; } = 20000f;

        public const string classId = "MyInfiniteCells",
                            displayName = "My Infinite Cell",
                            description = "A god powerful cell to make!",
                            language = "English";
        public const bool unlockAtStart = true;
        public static bool wasActive;
        #endregion
        public static void Patch()
        {
            sprite = ImageHelper.GetSpriteFromAssetsFolder("InfiniteCell.png");

            Info = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(sprite)
            .WithSizeInInventory(new Vector2int(1, 1));

            TechType = Info.TechType;

            CustomPrefab InfiniteCells = new(Info);

            PrefabTemplate InfiniteCellsClone = new CloneTemplate(Info, TechType.PowerCell)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    cells = go.EnsureComponent<Battery>();
                    cells._capacity = powercellEnergy;

                    if (wasActive) go.SetActive(true);
                }
            };

            RecipeData recipe = new()
            {
                craftAmount = 1,
                Ingredients =
                        {
                            new Ingredient(TechType.Silicone, 1),
                            new Ingredient(TechType.Quartz, 1),
                            new Ingredient(InfiniteBatteries.TechType, 2),
                        },
            };

            InfiniteCells.SetRecipe(recipe)
                            .WithFabricatorType(CraftTree.Type.Fabricator)
                            .WithStepsToFabricatorTab("Resources", "Electronics")
                            .WithCraftingTime(1f);

            //infiniteBattery.SetUnlock(TechType.AcidMushroom);

            InfiniteCells.SetEquipment(EquipmentType.PowerCellCharger);

            InfiniteCells.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            InfiniteCells.SetGameObject(InfiniteCellsClone);

            InfiniteCells.Register();
        }
    }
}
