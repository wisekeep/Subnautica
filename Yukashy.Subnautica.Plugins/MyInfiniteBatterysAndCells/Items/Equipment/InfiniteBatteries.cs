
namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public class InfiniteBatteries
    {
        #region[Declarations]
        public static Atlas.Sprite Sprite { get; } = ImageHelper.GetSpriteFromAssetsFolder("InfiniteBattery.png");
        public static Battery Battery { get; private set; }
        public static float Battery_Capacity { get; private set; } = 1000f;

        public const string classId = "MyInfiniteBattery",
                            displayName = "My Infinite Battery",
                            description = "A god powerful battery to make!",
                            language = "English";
        public const bool unlockAtStart = true;
        public static bool wasActive;
        #endregion

        #region[Prefab Declarations]
        public static PrefabInfo Info { get; private set; } = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(Sprite)
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechTypeID { get; private set; }
        public static CustomPrefab InfiniteBattery { get; private set; }
        public static PrefabTemplate InfiniteBatteryClone { get; private set; }
        public static RecipeData Recipe { get; private set; }
        #endregion

        public static void Patch()
        {
            TechTypeID = Info.TechType;

            InfiniteBattery = new(Info);

            InfiniteBatteryClone = new CloneTemplate(Info, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    Battery = go.EnsureComponent<Battery>();
                    Battery._capacity = Battery_Capacity;

                    if (wasActive) go.SetActive(true);
                }
            };

            Recipe = new()
            {
                craftAmount = 1,
                Ingredients =
                        {
                            new Ingredient(TechType.Titanium, 3),
                            new Ingredient(TechType.AcidMushroom, 5),
                            new Ingredient(TechType.Quartz, 1),
                        },
            };

            InfiniteBattery.SetRecipe(Recipe)
                            .WithFabricatorType(CraftTree.Type.Fabricator)
                            .WithStepsToFabricatorTab("Resources", "Electronics")
                            .WithCraftingTime(2f);

            //InfiniteBattery.SetUnlock(TechType.AcidMushroom);

            InfiniteBattery.SetEquipment(EquipmentType.BatteryCharger);

            InfiniteBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            InfiniteBattery.SetGameObject(InfiniteBatteryClone);

            InfiniteBattery.Register();
        }
    }
}