namespace MyInfiniteBatterysAndCells
{
    [Menu($"{MyInfiniteBatterysAndCells.PLUGIN_NAME} Config")]
    public class PluginConfig : ConfigFile
    {
        [Slider("<color=#FFFF00>Infinite</color> Battery Energy", Format = "{0:F0}", DefaultValue = 1000f, Min = 1000f, Max = 10000f, Step = 1000f), OnChange(nameof(Refresh))]
        public float configBatteryEnergy = 1000f;

        [Slider("<color=#FFFF00>Infinite</color> Powercell Energy", Format = "{0:F0}", DefaultValue = 2000f, Min = 2000f, Max = 20000f, Step = 1000f), OnChange(nameof(Refresh))]
        public float configPowercellEnergy = 2000f;

        public float Refresh(SliderChangedEventArgs _)
        {
            return _.Value;
        }
    }
}
