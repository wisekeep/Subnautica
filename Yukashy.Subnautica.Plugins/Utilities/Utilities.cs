﻿
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
    }
}
