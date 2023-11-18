#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

namespace MyReactorRod
{
    [Menu("MyReactorRod Multiplicator")]
    public class PluginConfig : ConfigFile
    {
        [Slider("<color=#FFFF00>ReactorRod</color> Multiplicator X", Format = "{0:F0}", DefaultValue = 10f, Min = 10f, Max = 1000f, Step = 100f)]
        public float multiply = 10f;

    }
}