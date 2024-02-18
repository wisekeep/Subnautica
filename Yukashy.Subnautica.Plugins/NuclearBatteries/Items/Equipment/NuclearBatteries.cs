
using static NuclearBatteries.Items.GlobalTexture;

namespace NuclearBatteries.Items.Equipment
{
    public static class NuclearBatteries
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

        #region[Prefab Declarations]
        public static PrefabInfo Info { get; private set; } = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(NuclearBatteryIcon)
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechType;
        public static CustomPrefab NuclearBattery;
        public static PrefabTemplate NuclearBatteryClone;
        public static RecipeData Recipe;
        public static MeshRenderer Renderer;
        #endregion

        public static void Patch()
        {
            TechType = Info.TechType;

            NuclearBattery = new(Info);

            NuclearBatteryClone = new CloneTemplate(Info, TechType.PrecursorIonBattery)
            {
                ModifyPrefab = go =>
                {
                    bool wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    Battery = go.EnsureComponent<Battery>();
                    Battery._capacity = NuclearPower;
                    if (Battery != null)
                        Battery.charge = Battery.capacity;

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

            _ = NuclearBattery.SetUnlock(TechType.UraniniteCrystal);

            _ = NuclearBattery.SetEquipment(EquipmentType.BatteryCharger);

            _ = NuclearBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            NuclearBattery.SetGameObject(NuclearBatteryClone);

            NuclearBattery.Register();
        }
    }
}
