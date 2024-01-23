
using static Utilities.Images;

namespace NuclearBatteries.Items.Equipment
{
    internal class NuclearBatteries
    {
        #region[Declarations]
        public static Battery Battery { get; private set; }

        public const string classId = "NuclearBattery",
                            displayName = "My Nuclear Battery",
                            description = "A Nuclear powerful battery!",
                            language = "English";
        public const bool unlockAtStart = true;
        public const float NuclearPower = 10000f;
        #endregion

        #region[Prefab IMGs]
        public static Atlas.Sprite NuclearBatteryIcon { get; } = ImageHelper.GetSpriteFromAssetsFolder("NuclearBattery.png");
        public static Atlas.Sprite NuclearCellIcon { get; } = ImageHelper.GetSpriteFromAssetsFolder("NuclearCell.png");
        #endregion

        #region[Prefab Declarations]
        public static PrefabInfo Info { get; } = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(NuclearBatteryIcon)
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechType { get; private set; }
        public static CustomPrefab NuclearBattery { get; private set; }
        public static PrefabTemplate NuclearBatteryClone { get; private set; }
        public static RecipeData Recipe { get; private set; }
        public static MeshRenderer Renderer { get; private set; }
        #endregion

        public static void Patch()
        {
            TechType = Info.TechType;

            NuclearBattery = new(Info);

            NuclearBatteryClone = new CloneTemplate(Info, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    bool wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    Battery = go.EnsureComponent<Battery>();
                    Battery._capacity = NuclearPower;

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
                            new Ingredient(TechType.Battery, 2),
                            new Ingredient(TechType.UraniniteCrystal, 2),
                            new Ingredient(TechType.Quartz, 2),
                        },
            };

            _ = NuclearBattery.SetRecipe(Recipe)
                .WithFabricatorType(CraftTree.Type.Fabricator)
                .WithStepsToFabricatorTab("Resources", "Electronics")
                .WithCraftingTime(1f);

            //_ = NuclearBattery.SetUnlock(TechType.AcidMushroom);

            _ = NuclearBattery.SetEquipment(EquipmentType.BatteryCharger);

            _ = NuclearBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            NuclearBattery.SetGameObject(NuclearBatteryClone);

            NuclearBattery.Register();
        }
    }
}
