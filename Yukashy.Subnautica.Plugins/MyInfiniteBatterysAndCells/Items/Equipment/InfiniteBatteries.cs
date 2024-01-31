using static MyInfiniteBatterysAndCells.GlobalTexture;

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public class InfiniteBatteries
    {
        #region[Declarations]
        public static Battery Battery { get; private set; }

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
            .WithIcon(Sprite_Battery)
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechType { get; private set; }
        public static CustomPrefab InfiniteBattery { get; private set; }
        public static PrefabTemplate InfiniteBatteryClone { get; private set; }
        public static RecipeData Recipe { get; private set; }
        public static MeshRenderer Renderer { get; private set; }
        #endregion

        public static void Patch()
        {
            TechType = Info.TechType;

            InfiniteBattery = new(Info);

            InfiniteBatteryClone = new CloneTemplate(Info, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    Battery = go.EnsureComponent<Battery>();
                    Battery._capacity = MyInfiniteBatterysAndCells.MyConfig.configBatteryEnergy;

                    Renderer = go.GetComponentInChildren<MeshRenderer>(true);
                    Renderer.material.SetTexture(ShaderPropertyID._MainTex, B_TE);
                    Renderer.material.SetTexture(ShaderPropertyID._Illum, B_IL);

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

            _ = InfiniteBattery.SetRecipe(Recipe)
                            .WithFabricatorType(CraftTree.Type.Fabricator)
                            .WithStepsToFabricatorTab("Resources", "Electronics")
                            .WithCraftingTime(0.5f);

            //_ = InfiniteBattery.SetUnlock(TechType.AcidMushroom);

            _ = InfiniteBattery.SetEquipment(EquipmentType.BatteryCharger);

            _ = InfiniteBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            InfiniteBattery.SetGameObject(InfiniteBatteryClone);

            InfiniteBattery.Register();
        }
    }
}
