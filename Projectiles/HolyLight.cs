using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
	public class HolyLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Light");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.penetrate = 10;
            projectile.timeLeft /= 2;
            projectile.magic = true;
        }

        public override void AI()
        {
            int num;
            for (int num143 = 0; num143 < 2; num143 = num + 1)
            {
                int num144 = Utils.SelectRandom<int>(Main.rand, new int[]
                {
                        269,
                        6
                });
                Dust dust23 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, num144, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f)];
                dust23.velocity = dust23.velocity / 4f + projectile.velocity / 2f;
                dust23.noGravity = true;
                dust23.scale = 1.2f;
                dust23.position = projectile.Center;
                dust23.noLight = true;
                num = num143;
            }

            projectile.ai[0] += 1f;
        }
        public override void Kill(int timeLeft)
        {

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 12;
            projectile.height = 12;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            int num3;
            for (int num731 = 0; num731 < 2; num731 = num3 + 1)
            {
                int num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num732].noGravity = true;
                Dust dust = Main.dust[num732];
                dust.velocity *= 3f;
                num732 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 269, 0f, 0f, 100, default(Color), 1.2f);
                dust = Main.dust[num732];
                dust.velocity *= 1f;
                num3 = num731;
            }
        }
    }
}