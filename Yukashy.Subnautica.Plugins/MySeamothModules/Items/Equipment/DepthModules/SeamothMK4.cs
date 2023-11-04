
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using System.Collections.Generic;

namespace MySeamothModules.Items.Equipment.DepthModules
{
    public class SeamothMK4
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {

            Info = PrefabInfo.WithTechType("SeamothDepthModuleMK4", "Seamoth Depth Module MK4", "Enhances safe diving depth by 1100m. Does not stack.").WithIcon(SpriteManager.Get(TechType.VehicleHullModule1));
            var MK4Prefab = new CustomPrefab(Info);


            var MK4Obj = new CloneTemplate(Info, TechType.VehicleHullModule1);
            MK4Prefab.SetGameObject(MK4Obj);

            MK4Prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.VehicleHullModule3),
                new CraftData.Ingredient(TechType.PlasteelIngot),
                new CraftData.Ingredient(TechType.Nickel,3),
                new CraftData.Ingredient(TechType.AluminumOxide,2)
            }
            }).WithFabricatorType(CraftTree.Type.Workbench).WithCraftingTime(5f);
            MK4Prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive).WithDepthUpgrade(1300f, true);

            MK4Prefab.Register();
        }
    }
}
