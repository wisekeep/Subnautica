namespace Utilities;

internal class Images
{
    public static string PluginFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static string AssetsFolder => Path.Combine(PluginFolder, "Assets");

    public static string RecipeFolder => Path.Combine(PluginFolder, "Recipes");

    public static string GetAssetPath(string filename)
    {
        return Path.Combine(AssetsFolder, filename + ".png");
    }

    public static Atlas.Sprite GetSprite(object FileOrTechType)
    {
        if (FileOrTechType is TechType techType) return SpriteManager.Get(techType);
        if (FileOrTechType is string filename)
            return ImageUtils.LoadSpriteFromFile(IOUtilities.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png"));
        throw new ArgumentException($"Incorrect type of '{FileOrTechType}' used in Sprite.Get()");
    }

    public static Texture2D GetTexture(string filename)
    {
        return ImageUtils.LoadTextureFromFile(GetAssetPath(filename));
    }

    public static class ImageHelper
    {
        public static Sprite SpriteFromAtlasSprite(Atlas.Sprite atlasSprite)
        {
            //https://github.com/Indigocoder1/Indigocoder_SubnauticaMods/blob/master/IndigocoderLib/ImageHelper.cs

            var rect = new Rect(0, 0, atlasSprite.texture.width, atlasSprite.texture.height);
            var pivot = new Vector2(atlasSprite.texture.width / 2, atlasSprite.texture.height / 2);
            return Sprite.Create(atlasSprite.texture, rect, pivot);
        }

        public static Atlas.Sprite GetSpriteFromAssetsFolder(string imageName, string asetFolderPath = null)
        {
            var spriteFilePath = "";
            if (!string.IsNullOrEmpty(asetFolderPath))
                spriteFilePath = Path.Combine(asetFolderPath + $"/{imageName}");
            else
                spriteFilePath =
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets") +
                    $"/{imageName}";
            return ImageUtils.LoadSpriteFromFile(spriteFilePath);
        }
    }
}