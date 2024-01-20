
namespace SeamothModules.Items.Equipment.DepthModules
{
    public class SeamothMK4
    {
        #region[Declarations]
        public const string classId = "SeamothDepthModuleMK4",
                            displayName = "Seamoth Depth Module MK4",
                            description = "Enhances safe diving depth by 1100m. Does not stack.",
                            language = "English";
        public const bool unlockAtStart = true;
        public static bool wasActive;
        #endregion

        #region[Prefab Declarations]
        public static PrefabInfo Info { get; private set; } = PrefabInfo
            .WithTechType(classId, displayName, description, language, unlockAtStart, null)
            .WithIcon(SpriteManager.Get(TechType.VehicleHullModule3))
            .WithSizeInInventory(new Vector2int(1, 1));
        public static TechType TechType { get; private set; }
        public static CustomPrefab MK4Prefab { get; private set; }
        public static PrefabTemplate MK4Obj { get; private set; }
        public static RecipeData Recipe { get; private set; }
        #endregion



        public static void Register()
        {
            TechType = Info.TechType;

            MK4Prefab = new(Info);

            MK4Obj = new CloneTemplate(Info, TechType.VehicleHullModule3)
            {
                ModifyPrefab = go =>
                {
                    wasActive = go.activeSelf;
                    if (wasActive) go.SetActive(false);

                    //

                    if (wasActive) go.SetActive(true);
                }
            };

            Recipe = new()
            {
                craftAmount = 1,
                Ingredients =
                {
                    new(TechType.VehicleHullModule3),
                    new(TechType.PlasteelIngot),
                    new(TechType.Nickel,3),
                    new(TechType.AluminumOxide,2)
                },
            };

            _ = MK4Prefab.SetRecipe(Recipe)
                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithCraftingTime(0.5f);

            _ = MK4Prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
                .WithDepthUpgrade(1300f, true);

            MK4Prefab.SetGameObject(MK4Obj);

            MK4Prefab.Register();
        }
    }
}
