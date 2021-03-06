using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnduriumMod.Projectiles
{
    public class FlamerainSpawn : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = 1;
            projectile.timeLeft = 100;
            projectile.friendly = true;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
            projectile.penetrate = -1;      //this is how many enemy this projectile penetrate before desapear 
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flame Rain");
        }
        public override void AI()
        {
            projectile.ai[1] += 1;
            if (projectile.ai[1] >= 60)
            {
                projectile.Kill();
                int num414 = (int)(projectile.position.X + (float)Main.rand.Next(projectile.width));
                int num415 = (int)(projectile.position.Y + (float)projectile.height);
                Projectile.NewProjectile((float)num414, (float)num415, 6f, 0f, mod.ProjectileType("FlameRain"), 100, 0f, projectile.owner, 0f, 0f);
                Projectile.NewProjectile((float)num414, (float)num415, -6f, 0f, mod.ProjectileType("FlameRain"), 100, 0f, projectile.owner, 0f, 0f);
            }
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, 0, 0);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 2f;
        }
    }
}