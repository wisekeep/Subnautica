
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using System.Collections.Generic;
using UnityEngine;
using static Utilities.Diversos;
using static VFXParticlesPool;
using Ingredient = CraftData.Ingredient;

namespace MyInfiniteBatterysAndCells.Items.Equipment
{
    internal class InfiniteBatteries : CustomPrefab
    {
        public static new void Register() //se der erro retirar o NEW
        {
            #region[Declarations]
            const string classId = "MyInfiniteBattery",
                         displayName = "My Infinite Battery",
                         description = "A powerful battery of the Gods to make!",
                         language = "English";
            const bool unlockAtStart = true;

            Atlas.Sprite sprite = ImageHelper.GetSpriteFromAssetsFolder("InfiniteBattery.png");
            #endregion

            PrefabInfo infiniteBatteryInfo = PrefabInfo.WithTechType(
                classId, displayName, description, language, unlockAtStart, null);
            infiniteBatteryInfo.WithIcon(sprite);
            infiniteBatteryInfo.WithSizeInInventory(new Vector2int(1, 1));

            TechType techType = infiniteBatteryInfo.TechType;

            CustomPrefab infiniteBattery = new(infiniteBatteryInfo);

            PrefabTemplate infiniteBatteryClone = new CloneTemplate(infiniteBatteryInfo, TechType.PrecursorIonBattery)
            {
                ModifyPrefab = go =>
                {
                    //go.SetActive(false);

                    //CoroutineTask<GameObject> task = CraftData.GetPrefabForTechTypeAsync(TechType.Battery);
                    //GameObject originalPrefab = task.GetResult();

                    var energyMixinIdentifier = go.AddComponent<EnergyMixin>();
                        //energyMixinIdentifier.allowBatteryReplacement = true;
                        //energyMixinIdentifier.defaultBatteryCharge = 1f;
                    



                    Battery myBattery = go.EnsureComponent<Battery>();
                            myBattery = go.GetComponentInChildren<Battery>(true);

                            myBattery._capacity = 9999f;
                            myBattery.name = displayName;

                            BatteryCharger.compatibleTech.Add(techType);

                            //if (!compatibleTech.Contains(techType))
                            //    compatibleTech.Add(techType);

                            go.SetActive(true);
                }
            };


            infiniteBattery.SetGameObject(infiniteBatteryClone);

            RecipeData recipe = new()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient(TechType.Titanium, 3),
                    new Ingredient(TechType.AcidMushroom, 5),
                    new Ingredient(TechType.Quartz, 1),
                },
            };

            infiniteBattery.SetRecipe(recipe)
                .WithFabricatorType(CraftTree.Type.Fabricator)
                .WithStepsToFabricatorTab("Resources", "Electronics")
                .WithCraftingTime(2f);

            //infiniteBattery.SetUnlock(TechType.AcidMushroom);

            //CraftDataHandler.SetEquipmentType(TechType.Battery, EquipmentType.BatteryCharger);

            //EnumHandler.AddEntry<EquipmentType>($"{classId}");
            //EnumHandler.AddEntry<TechType>($"{classId}");

            infiniteBattery.SetEquipment(EquipmentType.BatteryCharger).WithQuickSlotType(QuickSlotType.None);

            infiniteBattery.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics);

            infiniteBattery.Register();

        }
    }
}