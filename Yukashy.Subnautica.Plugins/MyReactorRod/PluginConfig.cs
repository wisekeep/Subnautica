﻿#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

using Nautilus.Handlers;
using Nautilus.Options;
using Nautilus.Json;
using Nautilus.Options.Attributes;
using UnityEngine.UI;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

using Nautilus.Utility;
using System.Reflection;
using System.Collections.Generic;
using static MyReactorRod.PluginConfig;



using MyReactorRod;

namespace MyReactorRod
{
    internal class PluginConfig : ModOptions
    {

        [Menu("MyReactorRod Multiplicator")]
        public class MyReactorRodConfig : ConfigFile
        {
            [Slider("<color=#FFFF00>ReactorRod</color> Multiplicator X", Format = "{0:F0}", DefaultValue = 10f, Min = 10f, Max = 1000f, Step = 10f)]
            public float multiply = 10f;
            
        }


        public PluginConfig() : base("MyReactorRod Multiplicator")

        {
            OptionsPanelHandler.RegisterModOptions(this);

            var sliderWithChange = ModSliderOption.Create(id: "Fancy", label: "<color=#FFFF00>ReactorRod</color> Multiplicator X", minValue: 10f, maxValue: 1000f,  10f, 100f );
                sliderWithChange.OnChanged += specific_OnChanged;
                AddItem(sliderWithChange);
        }

        private void specific_OnChanged(object sender, SliderChangedEventArgs e)
        {
            public float multiply = 10;
            //Subtitles.Add("Module activated");
        }
    }
}