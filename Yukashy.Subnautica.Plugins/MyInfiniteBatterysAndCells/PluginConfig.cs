#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

using Nautilus.Handlers;
using Nautilus.Options;

namespace MyInfiniteBatterysAndCells
{
    public class PluginConfig : ModOptions
    {
        public PluginConfig() : base($"{Nautilus.PluginInfo.PLUGIN_GUID} Config")

        {
            OptionsPanelHandler.RegisterModOptions(this);

            OnChanged += GlobalOptions_Changed;

            var sliderWithChange = ModSliderOption.Create(id: "Fancy", label: "Slider", minValue: 0, maxValue: 100, value: 50);
            sliderWithChange.OnChanged += specific_OnChanged;
            AddItem(sliderWithChange);

            AddItem(ModSliderOption.Create(id: "Foo", label: "Bar", minValue: 0, maxValue: 100, value: 50));
            AddItem(ModChoiceOption<string>.Create(id: "Baz", label: "Qux", options: new[] { "ABC", "DEF", "XYZ" }, index: 0));
        }

        private void specific_OnChanged(object sender, SliderChangedEventArgs e)
        {
            // Do onChange here
        }

        private void GlobalOptions_Changed(object sender, OptionEventArgs e)
        {
            switch (e)
            {
                case SliderChangedEventArgs sliderArgs:
                    switch (sliderArgs.Id)
                    {
                        case "Foo":
                            // Do stuff here
                            break;
                    }
                    break;
                case ChoiceChangedEventArgs<string> choiceArgs:
                    switch (choiceArgs.Id)
                    {
                        case "Baz":
                            // Do stuff here
                            break;
                    }
                    break;
            }
        }
    }

    //[Menu($"{MyInfo.PLUGIN_NAME} Config")]
    //public class ModOptions : ConfigFile
    //{
    //    [Slider("<color=#FFFF00>Infinite</color> Battery Energy", Format = "{0:F0}", DefaultValue = 1000f, Min = 1000f, Max = 10000f, Step = 100f)]
    //    public float batteryEnergy = 1000f;

    //    [Slider("<color=#FFFF00>Infinite</color> Powercell Energy", Format = "{0:F0}", DefaultValue = 2000f, Min = 2000f, Max = 20000f, Step = 100f)]
    //    public float powercellEnergy = 2000f;
    //}
}