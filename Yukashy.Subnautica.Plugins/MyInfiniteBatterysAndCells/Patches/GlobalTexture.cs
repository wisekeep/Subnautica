using static Utilities.Images;

namespace MyInfiniteBatterysAndCells;
public class GlobalTexture
{
    //Sprite
    public static Atlas.Sprite Sprite_Cell => ImageHelper.GetSpriteFromAssetsFolder("InfiniteCell.png");
    public static Atlas.Sprite Sprite_Battery => ImageHelper.GetSpriteFromAssetsFolder("InfiniteBattery.png");

    //MyInfiniteBatterysAndCells
    public static Texture2D B_TE => Battery_tex2;
    public static Texture2D B_IL => Powercell_illum4;

    public static Texture2D C_TE => Powercell_tex3;
    public static Texture2D C_IL => Powercell_illum4;


    //Texture2D
    public static Texture2D VanillaTexture => GetTexture("Vanilla_tex");
    public static Texture2D VanillaIllum => GetTexture("Vanilla_illum");
    public static Texture2D BatteryTexture => GetTexture("Battery_tex");
    public static Texture2D BatteryTextureIllum => GetTexture("Battery_illum");
    public static Texture2D IonBatteryTexture => GetTexture("Ion_tex");
    public static Texture2D IonBatteryTextureIllum => GetTexture("Ion_illum");
    public static Texture2D Battery_tex2 => GetTexture("Battery_tex2");
    public static Texture2D Battery_illum2 => GetTexture("Battery_illum2");
    public static Texture2D Battery_tex3 => GetTexture("Battery_tex3");
    public static Texture2D Battery_illum3 => GetTexture("Battery_illum3");
    //
    public static Texture2D Powercell_tex => GetTexture("Powercell_tex");
    public static Texture2D Powercell_illum => GetTexture("Powercell_illum");
    public static Texture2D Powercell_tex_Ion => GetTexture("Powercell_tex_Ion");
    public static Texture2D Powercell_illum_Ion => GetTexture("Powercell_illum_Ion");
    public static Texture2D Powercell_tex2 => GetTexture("Powercell_tex2");
    public static Texture2D Powercell_illum2 => GetTexture("Powercell_illum2");
    public static Texture2D Powercell_tex3 => GetTexture("Powercell_tex3");
    public static Texture2D Powercell_illum3 => GetTexture("Powercell_illum3");

    public static Texture2D Powercell_illum4 => GetTexture("Powercell_illum4");

    
}
