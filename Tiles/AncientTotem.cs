﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EnduriumMod.Tiles
{
    class AncientTotem : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                16
            };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Ancient Totem");
            AddMapEntry(new Color(0, 255, 175), name);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}