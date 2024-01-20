#pragma warning disable IDE1006 // Suppress warnings (convention violation) related to "Naming Styles"

/*       Microsoft   */


/*      BepInEx      */
global using BepInEx;
global using BepInEx.Logging;
//global using BepInEx.Configuration;
global using BepInEx.AssemblyPublicizer;

/*      Harmony      */

global using HarmonyLib;

/*       Nautilus    */
global using Nautilus;
global using Nautilus.Utility;
global using Nautilus.Utility.ModMessages;
global using Nautilus.Utility.MaterialModifiers;
global using Nautilus.Options;
global using Nautilus.Options.Attributes;
global using Nautilus.Json;
global using Nautilus.Json.Interfaces;
global using Nautilus.Json.ExtensionMethods;
global using Nautilus.Json.Converters;
global using Nautilus.Json.Attributes;
global using Nautilus.Handlers;
global using Nautilus.FMod;
global using Nautilus.FMod.Interfaces;
global using Nautilus.Extensions;
global using Nautilus.Crafting;
global using Nautilus.Commands;
global using Nautilus.Assets;
global using Nautilus.Assets.PrefabTemplates;
global using Nautilus.Assets.Gadgets;

/*       System      */
global using System;
global using System.Text;
global using System.Security;
global using System.Runtime.CompilerServices;
global using System.Reflection;
global using System.Reflection.Emit;
global using System.Linq;
global using System.IO;
global using System.Drawing;
global using System.Diagnostics;
global using System.Collections;
global using System.Collections.Generic;

/*       Unity       */
global using UnityEngineInternal;
global using UnityEngine;
global using UnityEngine.UI;
global using UnityEngine.Scripting;
global using UnityEngine.SceneManagement;
global using UnityEngine.Internal;
global using UnityEngine.Bindings;
global using UnityEngine.Animations;
global using UnityEngine.AddressableAssets;
//global using Unity.Properties;
global using Unity;

/*        Other      */
global using UWE;
global using TMPro;
global using static VFXParticlesPool;
global using static Utilities.Diversos;
global using static CraftData;
global using static Charger;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using Ingredient = CraftData.Ingredient;
global using FMOD;
