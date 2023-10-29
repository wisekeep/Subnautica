#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using System.Collections.Generic;
using Nautilus.Assets.Gadgets;
using static CraftData;

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    public class InfiniteBatteries
    {

        public static void Register()
        {
            #region[Declarations]
            const string classId = "My Infinite Battery",
                         displayName = "Infinite Battery",
                         description = "Powerful battery to make.",
                         language = "English";

            const bool unlockAtStart = true;
            #endregion

            PrefabInfo infiniteBatteryInfo = PrefabInfo.WithTechType(
                classId, displayName, description, language, unlockAtStart, null);

            infiniteBatteryInfo.WithIcon(SpriteManager.Get(TechType.Battery));

            infiniteBatteryInfo.WithSizeInInventory(new Vector2int(1, 1));

            CustomPrefab infiniteBattery = new CustomPrefab(infiniteBatteryInfo);

            PrefabTemplate infiniteBatteryClone = new CloneTemplate(infiniteBatteryInfo, TechType.Battery)
            {
                ModifyPrefab = go =>
                {
                    //BatteryCharger batteryCharger = go.GetComponent<BatteryCharger>();
                    //BatteryCharger.compatibleTech.Add(TechType.);

                    Battery myBattery = go.GetComponent<Battery>();
                    //myBattery.GetAllComponentsInChildren<Battery>();
                    myBattery._capacity = 10000f;

                }
            };

            //infiniteBattery.SetUnlock(TechType.AcidMushroom);
            //infiniteBattery.SetUnlock(TechType.None);

            infiniteBattery.SetGameObject(infiniteBatteryClone);

            infiniteBattery.SetRecipe(new RecipeData()
            {
                craftAmount = 1,

                Ingredients = new List<Ingredient>()
            {
                    new Ingredient(TechType.Titanium, 3),
                    new Ingredient(TechType.AcidMushroom, 5),
                    new Ingredient(TechType.Quartz, 1),
            }
            }).WithFabricatorType(CraftTree.Type.Fabricator)

                .WithStepsToFabricatorTab("Resources", "Electronics")

                .WithCraftingTime(1f);

            infiniteBattery.SetEquipment(EquipmentType.BatteryCharger).WithQuickSlotType(QuickSlotType.None);

            infiniteBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            infiniteBattery.Register();

        }
    }
}