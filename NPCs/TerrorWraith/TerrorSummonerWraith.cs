using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace EnduriumMod.NPCs.TerrorWraith
{
    public class TerrorSummonerWraith : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 200;
            npc.npcSlots = 5f;
            npc.width = 42; //324
            npc.height = 46; //216
            npc.defense = 10;
            npc.lifeMax = 4000;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 4;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.alpha = 70;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terror Caster Spirit");
        }
        public override void AI()
        {

            bool flag19 = false;
            bool flag20 = npc.type == 330 && !Main.dayTime;
            if (npc.justHit)
            {
                npc.ai[2] = 0f;
            }
            if (!flag20)
            {
                if (npc.ai[2] >= 0f)
                {
                    int num283 = 16;
                    bool flag21 = false;
                    bool flag22 = false;
                    if (npc.position.X > npc.ai[0] - (float)num283 && npc.position.X < npc.ai[0] + (float)num283)
                    {
                        flag21 = true;
                    }
                    else if ((npc.velocity.X < 0f && npc.direction > 0) || (npc.velocity.X > 0f && npc.direction < 0))
                    {
                        flag21 = true;
                    }
                    num283 += 24;
                    if (npc.position.Y > npc.ai[1] - (float)num283 && npc.position.Y < npc.ai[1] + (float)num283)
                    {
                        flag22 = true;
                    }
                    if (flag21 & flag22)
                    {
                        npc.ai[2] += 1f;
                        if (npc.ai[2] >= 30f && num283 == 16)
                        {
                            flag19 = true;
                        }
                        if (npc.ai[2] >= 60f)
                        {
                            npc.ai[2] = -200f;
                            npc.direction *= -1;
                            npc.velocity.X = npc.velocity.X * -1f;
                            npc.collideX = false;
                        }
                    }
                    else
                    {
                        npc.ai[0] = npc.position.X;
                        npc.ai[1] = npc.position.Y;
                        npc.ai[2] = 0f;
                    }
                    npc.TargetClosest(true);
                }
                else
                {
                    if (npc.type == 330)
                    {
                        npc.ai[2] += 0.1f;
                    }
                    else
                    {
                        npc.ai[2] += 1f;
                    }
                    if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
                    {
                        npc.direction = -1;
                    }
                    else
                    {
                        npc.direction = 1;
                    }
                }
            }
            int num284 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
            int num285 = (int)((npc.position.Y + (float)npc.height) / 16f);
            bool flag23 = true;
            bool flag24 = false;
            int num286 = 3;
            num286 = 4;
            if (Main.rand.Next(6) == 0)
            {
                int num293 = Dust.NewDust(npc.position, npc.width, npc.height, 14, 0f, 0f, 200, npc.color, 1f);
                Dust dust3 = Main.dust[num293];
                dust3.velocity *= 0.3f;
            }

            int num;
            for (int num309 = num285; num309 < num285 + num286; num309 = num + 1)
            {
                if (Main.tile[num284, num309] == null)
                {
                    Main.tile[num284, num309] = new Tile();
                }
                if ((Main.tile[num284, num309].nactive() && Main.tileSolid[(int)Main.tile[num284, num309].type]) || Main.tile[num284, num309].liquid > 0)
                {
                    if (num309 <= num285 + 1)
                    {
                        flag24 = true;
                    }
                    flag23 = false;
                    break;
                }
                num = num309;
            }
            if (Main.player[npc.target].npcTypeNoAggro[npc.type])
            {
                bool flag25 = false;
                for (int num310 = num285; num310 < num285 + num286 - 2; num310 = num + 1)
                {
                    if (Main.tile[num284, num310] == null)
                    {
                        Main.tile[num284, num310] = new Tile();
                    }
                    if ((Main.tile[num284, num310].nactive() && Main.tileSolid[(int)Main.tile[num284, num310].type]) || Main.tile[num284, num310].liquid > 0)
                    {
                        flag25 = true;
                        break;
                    }
                    num = num310;
                }
                npc.directionY = (!flag25).ToDirectionInt();
            }
            if (flag19)
            {
                flag24 = false;
                flag23 = true;

            }
            if (npc.velocity.Y > 0.9f)
            {
                npc.velocity.Y = 0.9f;
            }
            if (flag23)
            {

                npc.velocity.Y = npc.velocity.Y + 0.2f;
                if (npc.velocity.Y > 1.1f)
                {
                    npc.velocity.Y = 1.1f;
                }
            }
            else
            {

                if ((npc.directionY < 0 && npc.velocity.Y > 0f) | flag24)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.2f;
                }
            }
            if (npc.wet)
            {
                npc.velocity.Y = npc.velocity.Y - 0.2f;
                if (npc.velocity.Y < -2f)
                {
                    npc.velocity.Y = -2f;
                }
            }
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.4f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
                {
                    npc.velocity.X = 1f;
                }
                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
                {
                    npc.velocity.X = -1f;
                }
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                {
                    npc.velocity.Y = 1f;
                }
                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                {
                    npc.velocity.Y = -1f;
                }
            }


            float num312 = 5f;
            if (npc.direction == -1 && npc.velocity.X > -num312)
            {
                npc.velocity.X = npc.velocity.X - 0.04f;
                if (npc.velocity.X > num312)
                {
                    npc.velocity.X = npc.velocity.X - 0.04f;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.velocity.X = npc.velocity.X + 0.02f;
                }
                if (npc.velocity.X < -num312)
                {
                    npc.velocity.X = -num312;
                }
            }
            else if (npc.direction == 1 && npc.velocity.X < num312)
            {
                npc.velocity.X = npc.velocity.X + 0.04f;
                if (npc.velocity.X < -num312)
                {
                    npc.velocity.X = npc.velocity.X + 0.04f;
                }
                else if (npc.velocity.X < 0f)
                {
                    npc.velocity.X = npc.velocity.X - 0.02f;
                }
                if (npc.velocity.X > num312)
                {
                    npc.velocity.X = num312;
                }
            }


            num312 = 1.1f;

            if (npc.directionY == -1 && npc.velocity.Y > -num312)
            {
                npc.velocity.Y = npc.velocity.Y - 0.02f;
                if (npc.velocity.Y > num312)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.04f;
                }
                else if (npc.velocity.Y > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.02f;
                }
                if (npc.velocity.Y < -num312)
                {
                    npc.velocity.Y = -num312;
                }
            }
            else if (npc.directionY == 1 && npc.velocity.Y < num312)
            {
                npc.velocity.Y = npc.velocity.Y + 0.02f;
                if (npc.velocity.Y < -num312)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.04f;
                }
                else if (npc.velocity.Y < 0f)
                {
                    npc.velocity.Y = npc.velocity.Y - 0.02f;
                }
                if (npc.velocity.Y > num312)
                {
                    npc.velocity.Y = num312;
                }
            }
            if (Main.netMode != 1 && !npc.confused)
            {
                npc.ai[3] += 1f;
                if (npc.justHit)
                {
                    npc.ai[3] = -2f;
                    npc.localAI[1] = 0f;
                }
                if (Main.netMode != 1 && npc.ai[3] >= (float)(60 + Main.rand.Next(60)))
                {
                    npc.ai[3] = 0f;
                    if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].head))
                    {
                        float num301 = 10f;
                        Vector2 vector35 = new Vector2(npc.position.X + (float)npc.width * 0.5f - 4f, npc.position.Y + (float)npc.height * 0.7f);
                        float num302 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector35.X;
                        float num303 = Math.Abs(num302) * 0.1f;
                        float num304 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector35.Y - num303;
                        num302 += (float)Main.rand.Next(-10, 11);
                        num304 += (float)Main.rand.Next(-30, 21);
                        float num305 = (float)Math.Sqrt((double)(num302 * num302 + num304 * num304));
                        num305 = num301 / num305;
                        num302 *= num305;
                        num304 *= num305;
                        int num306 = 50;
                        int num307 = mod.ProjectileType("AnarchySpell");
                        Projectile.NewProjectile(vector35.X, vector35.Y, num302, num304, num307, num306, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            Player player = Main.player[npc.target];
            if (player.Center.X > npc.Center.X)
            {
                npc.spriteDirection = 1;
            }
            else
            {
                npc.spriteDirection = 2;
            }
            return;
        }
    }
}