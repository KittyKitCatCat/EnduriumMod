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


namespace EnduriumMod.NPCs.PrismMonolith
{
    public class CruptixWorm_Head : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tortured Soul");
        }
        public override void SetDefaults()
        {
            npc.damage = 50;
            npc.npcSlots = 5f;
            npc.width = 32;
            npc.height = 32;
            npc.defense = 0;
            npc.lifeMax = 1280;
            npc.aiStyle = 6;
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 0, 50, 0);

            npc.behindTiles = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.Item14;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneSnow && EnduriumWorld.downedPrismArcanum || NPC.downedBoss3 && spawnInfo.player.ZoneSnow ? 0.05f : 0f;
        }
        public override void AI()
        {
            if (npc.ai[0] == 0)
            {
                // So, here we assing the npc.realLife value.
                // The npc.realLife value is mainly used to determine which NPC loses life when we hit this NPC.
                // We don't want every single piece of the worm to have its own HP pool, so this is a neat way to fix that.
                npc.realLife = npc.whoAmI;
                // LatestNPC is going to be used later on and I'll explain it there.
                int latestNPC = npc.whoAmI;

                // Here we determine the length of the worm.
                // In this case the worm will have a length of 10 to 14 body parts.
                int randomWormLength = Main.rand.Next(9, 14);
                for (int i = 0; i < randomWormLength; ++i)
                {
                    // We spawn a new NPC, setting latestNPC to the newer NPC, whilst also using that same variable
                    // to set the parent of this new NPC. The parent of the new NPC (may it be a tail or body part)
                    // will determine the movement of this new NPC.
                    // Under there, we also set the realLife value of the new NPC, because of what is explained above.
                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CruptixWorm_Body"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                }
                // When we're out of that loop, we want to 'close' the worm with a tail part!
                latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CruptixWorm_Tail"), npc.whoAmI, 0, latestNPC);
                Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;

                // We're setting npc.ai[0] to 1, so that this 'if' is not triggered again.
                npc.ai[0] = 1;
                npc.netUpdate = true;
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(20) == 0)
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OddGemstone"));

            }
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceEnergy"), Main.rand.Next(2, 4));
            Terraria.Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrismShard"), Main.rand.Next(4, 9));
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Shiver"), 100);
        }
    }
}