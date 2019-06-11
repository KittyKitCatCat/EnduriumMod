﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace EnduriumMod.Projectiles
{
    public class LivingAccord : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.CloneDefaults(ProjectileID.TheEyeOfCthulhu);
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.scale = 1f;
            projectile.penetrate = -1;
            projectile.melee = true;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 20f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 340f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 19f;
        }
        float num001 = 0f;
        public override void AI()
        {
            num001 += 1f;
            if (num001 > 10f)
            {
                projectile.rotation -= 0.104719758f;
                int num3;
                for (int num961 = 0; num961 < 2; num961 = num3 + 1)
                {
                    int num962 = Main.rand.Next(3);
                    if (num962 == 0)
                    {
                        Vector2 vector129 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
                        Dust dust114 = Main.dust[Dust.NewDust(projectile.Center - vector129 * 30f, 0, 0, 229, 0f, 0f, 0, default(Color), 1f)];
                        dust114.noGravity = true;
                        dust114.position = projectile.Center - vector129 * (float)Main.rand.Next(60, 81);
                        dust114.velocity = vector129.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                        dust114.scale = 0.7f + Main.rand.NextFloat();
                        dust114.fadeIn = 1.2f;
                        dust114.customData = projectile.Center;
                    }
                    else if (num962 == 1)
                    {
                        Vector2 vector130 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * projectile.scale;
                        Dust dust115 = Main.dust[Dust.NewDust(projectile.Center - vector130 * 30f, 0, 0, 107, 0f, 0f, 100, default(Color), 1f)];
                        dust115.noGravity = true;
                        dust115.position = projectile.Center - vector130 * 180f;
                        dust115.velocity = vector130.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
                        dust115.scale = 0.7f + Main.rand.NextFloat();
                        dust115.fadeIn = 1.2f;
                        dust115.customData = projectile.Center;
                    }
                    num3 = num961;
                }
                return;
            }
            if (Main.rand.Next(3) == 0)
            {
                Vector2 vector131 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
                Dust dust116 = Main.dust[Dust.NewDust(projectile.Center - vector131 * 30f, 0, 0, 107, 0f, 0f, 100, default(Color), 1f)];
                dust116.noGravity = true;
                dust116.position = projectile.Center - vector131 * (float)Main.rand.Next(10, 21);
                dust116.velocity = vector131.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
                dust116.scale = 0.7f + Main.rand.NextFloat();
                dust116.fadeIn = 1.2f;
                dust116.customData = projectile.Center;
                return;
            }
            Vector2 vector132 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
            Dust dust117 = Main.dust[Dust.NewDust(projectile.Center - vector132 * 30f, 0, 0, 229, 0f, 0f, 0, default(Color), 1f)];
            dust117.noGravity = true;
            dust117.position = projectile.Center - vector132 * 30f;
            dust117.velocity = vector132.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
            dust117.scale = 0.7f + Main.rand.NextFloat();
            dust117.fadeIn = 1.2f;
            dust117.customData = projectile.Center;
            return;

        }
        
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Reflux");
        }
    }
}