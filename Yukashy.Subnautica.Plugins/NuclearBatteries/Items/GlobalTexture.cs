using static Utilities.Images;

namespace NuclearBatteries.Items;

internal class GlobalTexture
{
    //Sprite
    public static Atlas.Sprite NuclearBatteryIcon => ImageHelper.GetSpriteFromAssetsFolder("NuclearBattery.png");
    public static Atlas.Sprite NuclearCellIcon => ImageHelper.GetSpriteFromAssetsFolder("NuclearCell.png");

    //Nuclear Batteries Texture2D
    public static Texture2D BTe => GetTexture("NuclearBattery_tex");

    public static Texture2D BIl => GetTexture("NuclearBattery_illum");

    //
    public static Texture2D CTe => GetTexture("NuclearCell_tex");
    public static Texture2D CIl => GetTexture("NuclearCell_illum");

    //private static string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    //private static string SpritePath => Path.Combine(AssetsFolder, $"{ClassId}.png");
}