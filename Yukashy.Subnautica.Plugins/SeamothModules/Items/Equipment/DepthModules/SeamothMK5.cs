
namespace SeamothModules.Items.Equipment.DepthModules
{
    public class SeamothMK5
    {
        #region[Declarations]
        public const string classId = "SeamothDepthModuleMK5",
                            displayName = "Seamoth Depth Module MK5",
                            description = "Enhances safe diving depth by 1500m. Does not stack.",
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
        public static CustomPrefab MK5Prefab { get; private set; }
        public static PrefabTemplate MK5Obj { get; private set; }
        public static RecipeData Recipe { get; private set; }
        #endregion

        public static void Register()
        {
            TechType = Info.TechType;

            MK5Prefab = new(Info);

            MK5Obj = new CloneTemplate(Info, TechType.VehicleHullModule3)
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
                new(SeamothMK4.Info.TechType,1),
                new(TechType.PlasteelIngot),
                new(TechType.Kyanite,3)
                },
            };

            _ = MK5Prefab.SetRecipe(Recipe)
                .WithFabricatorType(CraftTree.Type.Workbench)
                .WithCraftingTime(0.5f);

            _ = MK5Prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
                .WithDepthUpgrade(1700f, true);

            MK5Prefab.SetGameObject(MK5Obj);

            MK5Prefab.Register();
        }
    }
}
