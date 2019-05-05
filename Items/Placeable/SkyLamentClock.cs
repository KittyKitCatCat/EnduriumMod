using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Placeable
{
    public class SkyLamentClock : ModItem
    {
		public override void SetStaticDefaults()
		{
		    DisplayName.SetDefault("Sky Glaze Clock");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("SkyLamentClock");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkyLamentBrick", 18);
			recipe.AddIngredient(null, "MagicPowder", 12);
            recipe.AddTile(null, "SkyLamentAnvil");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}