﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace EnduriumMod.NPCs.TheScourge
{
    public class ScourgeSpitNonOrbit : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 16; //324
            npc.height = 16; //216
            npc.defense = 20;
            npc.lifeMax = 120;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxic Spit");
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        bool hasSummoned = false;
        public override void AI()
        {
            npc.dontTakeDamage = true;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            int num;
            if (!hasSummoned)
            {
                Vector2 PlayerPosition = new Vector2(player.Center.X + Main.rand.Next(-150, 151) - npc.Center.X, player.Center.Y + Main.rand.Next(-150, 151) - npc.Center.Y);
                PlayerPosition.Normalize();
                npc.velocity = PlayerPosition * 12f;
                hasSummoned = true;
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 89, 0f, 0f, 100, default(Color), 1.6f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
                for (int num624 = 0; num624 < 15; num624++)
                {
                    int num1 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("ScourgeSpit"), npc.damage, 0f, Main.myPlayer);
                    Main.projectile[num1].ai[0] = npc.whoAmI;
                }
            }
            int num2 = 30;
            int num3 = 30;
            for (int i = 0; i < 1; i++)
            {
                Vector2 position = new Vector2(npc.Center.X - (float)(num2 / 2), npc.position.Y + (float)npc.height - (float)num3);
                if (Collision.SolidCollision(position, num2, num3) || Collision.WetCollision(position, num2, num3))
                {
                    npc.active = false;
                    npc.life = 0;
                    npc.checkDead();
                    npc.HitEffect();
                }
            }
        }
    }
}