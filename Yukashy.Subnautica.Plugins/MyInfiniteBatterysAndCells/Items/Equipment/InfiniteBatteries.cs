
using MyInfiniteBatterysAndCells.Patches;

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public static class InfiniteBatteries
    {
        #region[Declarations]
        public static Atlas.Sprite sprite { get; set; }
        public static Battery battery { get; set; }
        public static TechType TechType { get; set; }
        public static PrefabInfo Info { get; set; }
        public static float batteryEnergy { get; set; } = 10000f;

        public const string classId = "MyInfiniteBattery",
                            displayName = "My Infinite Battery",
                            description = "A god powerful battery to make!",
                            language = "English";
        public const bool unlockAtStart = true;
        public static bool wasActive;
        #endregion
        public static void Patch()
        {
            sprite = ImageHelper.GetSpriteFromAssetsFolder("InfiniteBattery.png");

            Info = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(sprite)
            .WithSizeInInventory(new Vector2int(1, 1));

            TechType = Info.TechType;

            CustomPrefab InfiniteBattery = new(Info);

            PrefabTemplate infiniteBatteryClone = new CloneTemplate(Info, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    battery = go.EnsureComponent<Battery>();
                    battery._capacity = batteryEnergy;

                    if (wasActive) go.SetActive(true);
                }
            };

            RecipeData recipe = new()
            {
                craftAmount = 1,
                Ingredients =
                        {
                            new Ingredient(TechType.Titanium, 3),
                            new Ingredient(TechType.AcidMushroom, 5),
                            new Ingredient(TechType.Quartz, 1),
                        },
            };

            InfiniteBattery.SetRecipe(recipe)
                            .WithFabricatorType(CraftTree.Type.Fabricator)
                            .WithStepsToFabricatorTab("Resources", "Electronics")
                            .WithCraftingTime(2f);

            //infiniteBattery.SetUnlock(TechType.AcidMushroom);

            InfiniteBattery.SetEquipment(EquipmentType.BatteryCharger);

            InfiniteBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            InfiniteBattery.SetGameObject(infiniteBatteryClone);

            InfiniteBattery.Register();
        }
    }
}