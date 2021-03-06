﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles   //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class NatureFlame : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;  //Set the hitbox width
            projectile.height = 12; //Set the hitbox height
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;  //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 175;  //The amount of time the projectile is alive for  
            projectile.extraUpdates = 3;
        }

        public override void AI()
        {
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            if (projectile.ai[0] > 7f)
            {
                float num297 = 1f;
                if (projectile.ai[0] == 8f)
                {
                    num297 = 0.25f;
                }
                else if (projectile.ai[0] == 9f)
                {
                    num297 = 0.5f;
                }
                else if (projectile.ai[0] == 10f)
                {
                    num297 = 0.75f;
                }
                projectile.ai[0] += 1f;
                int num298 = 3;
                if (num298 == 2 || Main.rand.Next(2) == 0)
                {
                    int num3;
                    for (int num299 = 0; num299 < 1; num299 = num3 + 1)
                    {
                        int num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num298, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        Dust dust3;
                        if (Main.rand.Next(3) != 0 || (Main.rand.Next(3) == 0))
                        {
                            Main.dust[num300].noGravity = true;
                            dust3 = Main.dust[num300];
                            dust3.scale *= 3f;
                            Dust dust52 = Main.dust[num300];
                            dust52.velocity.X = dust52.velocity.X * 2f;
                            Dust dust53 = Main.dust[num300];
                            dust53.velocity.Y = dust53.velocity.Y * 2f;
                        }
                        Dust dust54 = Main.dust[num300];
                        dust54.velocity.X = dust54.velocity.X * 1.2f;
                        Dust dust55 = Main.dust[num300];
                        dust55.velocity.Y = dust55.velocity.Y * 1.2f;
                        dust3 = Main.dust[num300];
                        dust3.scale *= num297;
                        if (num298 == 75)
                        {
                            dust3 = Main.dust[num300];
                            dust3.velocity += projectile.velocity;
                            if (!Main.dust[num300].noGravity)
                            {
                                dust3 = Main.dust[num300];
                                dust3.velocity *= 0.5f;
                            }
                        }
                        num3 = num299;
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation += 0.3f * (float)projectile.direction;
            return;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}