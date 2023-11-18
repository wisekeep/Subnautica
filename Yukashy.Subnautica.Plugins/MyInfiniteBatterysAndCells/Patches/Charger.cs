using static MyInfiniteBatterysAndCells.GlobalTexture;

namespace MyInfiniteBatterysAndCells.Patches
{
    [HarmonyPatch(typeof(Charger))]
    public class ChargerPatches
    {
        [HarmonyPatch(nameof(Charger.OnEquip)), HarmonyPostfix]
        public static void OnEquip(Charger __instance, string slot, InventoryItem item, Dictionary<string, SlotDefinition> ___slots)
        {
            if (___slots.TryGetValue(slot, out SlotDefinition slotDefinition))
            {
                GameObject battery = slotDefinition.battery;
                Pickupable pickupable = item.item;

                if (battery != null && pickupable != null)
                {
                    GameObject model;

                    switch (__instance)
                    {
                        case BatteryCharger _:
                            model = pickupable.gameObject.transform.Find("model/battery_01")?.gameObject ?? pickupable.gameObject.transform.Find("model/battery_ion")?.gameObject;

                            if (model != null && model.TryGetComponent(out Renderer ModelRenderer_0)
                                              && battery.TryGetComponent(out Renderer ChargerRenderer_0))
                            {
                                switch (item.item.GetTechName())
                                {
                                    case "MyInfiniteBattery":
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._MainTex, B_TE);
                                        ChargerRenderer_0.material.SetTexture(ShaderPropertyID._Illum, B_IL);
                                        break;
                                }
                            }
                            break;

                        case PowerCellCharger _:
                            model = pickupable.gameObject.FindChild("engine_power_cell_01") ?? pickupable.gameObject.FindChild("engine_power_cell_ion");

                            if (model != null && model.TryGetComponent(out Renderer ModelRenderer_1)
                                              && battery.TryGetComponent(out Renderer ChargerRenderer_1)
                                              && model.TryGetComponent(out MeshFilter ModelMeshFilter_1)
                                              && battery.TryGetComponent(out MeshFilter BatteryMeshFilter_1))
                            {
                                BatteryMeshFilter_1.mesh = ModelMeshFilter_1.mesh;
                                ChargerRenderer_1.material.CopyPropertiesFromMaterial(ModelRenderer_1.material);

                                switch (item.item.GetTechName())
                                {
                                    case "MyInfiniteCells":
                                        ChargerRenderer_1.material.SetTexture(ShaderPropertyID._MainTex, C_TE);
                                        ChargerRenderer_1.material.SetTexture(ShaderPropertyID._Illum, C_IL);
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
