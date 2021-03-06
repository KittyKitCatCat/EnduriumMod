﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Items.Weapons
{
    public class Exhaustion : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 68;
            item.ranged = true;
            item.width = 34;
            item.height = 50;
            item.useTime = 13;

            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.5f;
            item.value = 125000;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 19; //idk why but all the guns in the vanilla source have this
            item.shootSpeed = 27f;
            item.useAmmo = 40;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(6));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exhaustion");
            Tooltip.SetDefault("Fires two arrows at once");
        }

    }
}
