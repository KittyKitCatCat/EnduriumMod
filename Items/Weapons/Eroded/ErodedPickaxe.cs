﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons.Eroded
{
    public class ErodedPickaxe : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 21;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 7;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.pick = 101;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 21);
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("ErodedShard"), 20);
            recipe.AddIngredient(null, ("RuneofFear"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eroded Pickaxe");
            Tooltip.SetDefault("");
        }
    }
}
