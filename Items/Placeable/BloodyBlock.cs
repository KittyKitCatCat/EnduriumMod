﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Placeable
{
    public class BloodyBlock : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = 1;
            item.rare = 2;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 0, 5, 0);
            item.createTile = mod.TileType("BloodyPillarBlock"); //put your CustomBlock Tile name
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Temple Brick");
            Tooltip.SetDefault("");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BloodFangCore"), 5);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}