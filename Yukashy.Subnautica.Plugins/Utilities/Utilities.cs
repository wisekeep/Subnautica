using System.IO;
using System.Reflection;
using UnityEngine;
using Nautilus.Utility;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using System;

namespace Utilities
{
    public static class Diversos
    {
        public static class Colors
        {
            public static string Red = "<color=#c2484f>";
            public static string Orange = "<color=#ff9706>";
            public static string Yellow = "<color=#f2cb5f>";
            public static string Green = "<color=#1eda62>";
            public static string Lime = "<color=#c4ff1f>";
            public static string Blue = "<color=#6bd6eb>";
            public static string Pink = "<color=#d76eff>";
            public static string Purple = "<color=#7f19f5>";
            public static string Grey = "<color=#a4a4a4>";
            public static string End = "</color>";
        }

        public static class Texture
        {
            public static Texture2D Get(string filename)
            {
                return ImageUtils.LoadTextureFromFile(Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets"), filename));
            }
        }

        public static string MyLower(string input)
        {
            return input.ToLower().Replace(" ", string.Empty);
        }

        public static class ImageHelper
        {
            public static Sprite SpriteFromAtlasSprite(Atlas.Sprite atlasSprite)
            {   //https://github.com/Indigocoder1/Indigocoder_SubnauticaMods/blob/master/IndigocoderLib/ImageHelper.cs

                Rect rect = new Rect(0, 0, atlasSprite.texture.width, atlasSprite.texture.height);
                Vector2 pivot = new Vector2(atlasSprite.texture.width / 2, atlasSprite.texture.height / 2);
                return Sprite.Create(atlasSprite.texture, rect, pivot);
            }

            public static Atlas.Sprite GetSpriteFromAssetsFolder(string imageName, string asetFolderPath = null)
            {
                string spriteFilePath = "";
                if (!string.IsNullOrEmpty(asetFolderPath))
                {
                    spriteFilePath = Path.Combine(asetFolderPath + $"/{imageName}");
                }
                else
                {
                    spriteFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets") + $"/{imageName}";
                }
                return ImageUtils.LoadSpriteFromFile(spriteFilePath);
            }
        }

        public class TechTypeList
        {
            public string name;
            public List<TechType> techTypes = new List<TechType>();

            public void Add(TechType techType) => techTypes.Add(techType);
            public bool Remove(TechType techType) => techTypes.Remove(techType);

            public void Add(TechTypeList list) => Add(list.techTypes);
            public void Add(IEnumerable<TechType> list) => techTypes.AddRange(list);

            public bool Contains(TechType techType) => techTypes.Contains(techType);

            public TechTypeList(string name, params TechType[] techTypes)
            {
                this.name = name;
                this.techTypes = techTypes.ToList();
            }

            //public TechTypeList(TechTypeList list) : this(list.name, list.techTypes.ToArray()) { }
        }

        public static void PatchIfExists(Harmony harmony, string assemblyName, string typeName, string methodName, HarmonyMethod prefix, HarmonyMethod postfix, HarmonyMethod transpiler)
        {
            var targetType = FindType(assemblyName, typeName);

            var targetMethod = AccessTools.Method(targetType, methodName);
            if (targetMethod != null)
            {
                harmony.Patch(targetMethod, prefix, postfix, transpiler);
            }
            else
            {
                Console.WriteLine($"Was not able to patch {typeName}.{methodName} because it doesn't exist!");
            }
        }
        public static Type FindType(string assemblyName, string typeName)
        {
            var assembly = FindAssembly(assemblyName);
            if (assembly == null)
            {
                return null;
            }

            Type targetType = assembly.GetType(typeName);
            if (targetType == null)
            {
                return null;
            }
            return targetType;
        }

        public static Assembly FindAssembly(string assemblyName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.FullName.StartsWith(assemblyName + ","))
                    return assembly;

            return null;
        }

        public static string GetNameWithCloneRemoved(string name)
        {
            string cloneString = "(Clone)";
            int nameLength = name.Length - cloneString.Length;
            return name.Substring(0, nameLength);
        }
    }
}