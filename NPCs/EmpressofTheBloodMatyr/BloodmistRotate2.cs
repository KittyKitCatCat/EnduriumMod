﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.NPCs.EmpressofTheBloodMatyr
{
    public class BloodmistRotate2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodmist Bolt");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 16;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 400;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            int num3;
            for (int num93 = 0; num93 < 5; num93 = num3 + 1)
            {
                float num94 = projectile.velocity.X / 3f * (float)num93;
                float num95 = projectile.velocity.Y / 3f * (float)num93;
                int num96 = 4;
                int num97 = Dust.NewDust(new Vector2(projectile.position.X + (float)num96, projectile.position.Y + (float)num96), projectile.width - num96 * 2, projectile.height - num96 * 2, 52, 0f, 0f, 100, default(Color), 0.4f);
                Main.dust[num97].noGravity = true;
                Dust dust3 = Main.dust[num97];
                dust3.velocity *= 0f;
                dust3 = Main.dust[num97];
                dust3.velocity += projectile.velocity * 0f;
                Dust dust6 = Main.dust[num97];
                dust6.position.X = dust6.position.X - num94;
                Dust dust7 = Main.dust[num97];
                dust7.position.Y = dust7.position.Y - num95;
                num3 = num93;
            }
            projectile.ai[0] += 1;
            if (projectile.ai[1] == 0)
            {
                if (projectile.ai[0] >= 20)
                {
                    projectile.ai[0] = 0;
                    projectile.ai[1] = 1;
                }
                else
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-1));
                    projectile.velocity.Y = perturbedSpeed.Y;
                    projectile.velocity.X = perturbedSpeed.X;
                }
            }
            else
            {
                if (projectile.ai[0] <= 20)
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(2));
                    projectile.velocity.Y = perturbedSpeed.Y;
                    projectile.velocity.X = perturbedSpeed.X;

                }
                else if (projectile.ai[0] >= 40 && projectile.ai[0] <= 60)
                {
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-2));
                    projectile.velocity.Y = perturbedSpeed.Y;
                    projectile.velocity.X = perturbedSpeed.X;
                }
                if (projectile.ai[0] >= 80)
                {
                    projectile.ai[0] = 0;
                }
            }
        }
    }
}