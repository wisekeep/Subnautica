using static Utilities.Images;

namespace NuclearBatteries.Items
{
    internal class GlobalTexture
    {
        //Sprite
        public static Atlas.Sprite Sprite_Cell => ImageHelper.GetSpriteFromAssetsFolder("NuclearBattery.png");
        public static Atlas.Sprite Sprite_Battery => ImageHelper.GetSpriteFromAssetsFolder("NuclearCell.png");

        //Nuclear Batteries Texture2D
        public static Texture2D B_TE => GetTexture("NuclearBattery_tex");
        public static Texture2D B_IL => GetTexture("NuclearBattery_illum");
        //
        public static Texture2D C_TE => GetTexture("NuclearCell_tex");
        public static Texture2D C_IL => GetTexture("NuclearCell_illum");
    }
}
