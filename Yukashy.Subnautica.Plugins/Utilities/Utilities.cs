
using Unity.GraphToolsFoundation;

namespace Utilities
{
    public static class Diversos
    {
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

        public static Texture2D GetTexture(string filename)
        {
            return ImageUtils.LoadTextureFromFile(IOUtilities.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png"));
        }

        public static Atlas.Sprite GetSprite(object FileOrTechType)
        {
            if (FileOrTechType is TechType techType) return SpriteManager.Get(techType);
            else if (FileOrTechType is string filename) return ImageUtils.LoadSpriteFromFile(IOUtilities.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png"));
            else throw new ArgumentException($"Incorrect type of '{FileOrTechType}' used in Sprite.Get()");
        }
    }
}