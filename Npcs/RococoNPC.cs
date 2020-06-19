﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace giantsummon.Npcs
{
    public class RococoNPC : GuardianActorNPC
    {
        public bool RejectedOnce = false, AcceptedOnce = false;
        private bool PlayerHasRococo { get { return PlayerMod.PlayerHasGuardian(Main.player[Main.myPlayer], 0); } }

        public RococoNPC()
            : base(0, "")
        {

        }

        public override bool CanChat()
        {
            return true;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            if (npc.GetGlobalNPC<NpcMod>().mobType > MobTypes.Normal)
                npc.GetGlobalNPC<NpcMod>().mobType = MobTypes.Normal;
            NpcMod.LatestMobType = MobTypes.Normal;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (PlayerHasRococo)
            {
                npc.Transform(ModContent.NPCType<GuardianNPC.List.RaccoonGuardian>());
                ((GuardianNPC.List.RaccoonGuardian)npc.modNPC).UnlockGuardian();
            }
            else if (!RejectedOnce && !AcceptedOnce)
            {
                if (firstButton) //Accept
                {
                    AcceptedOnce = true;
                    Main.npcChatText = "*It got very happy after I said that It can move to my world, and said that his name is "+Base.Name+".*";
                    Jump = true;
                }
                else
                {
                    RejectedOnce = true;
                    Main.npcChatText = "*It got saddened after hearing my refusal. But says that wont feel bad for that.*";
                }
            }
            else if (AcceptedOnce)
            {
                PlayerMod.AddPlayerGuardian(Main.player[Main.myPlayer], GuardianID, GuardianModID);
                npc.Transform(ModContent.NPCType<GuardianNPC.List.RaccoonGuardian>());
                ((GuardianNPC.List.RaccoonGuardian)npc.modNPC).UnlockGuardian();
            }
        }

        public override string GetChat()
        {
            string mes = "";
            if (PlayerHasRococo)
            {
                mes = "*Hey buddy, good to see you again.*";
            }
            else if (!RejectedOnce && !AcceptedOnce)
            {
                mes = "*The creature is surprised for seeing me, said that has been travelling over and over looking for a place with cool people to live with. Should I let It live in my world?*";
            }
            else if (AcceptedOnce)
            {
                mes = "*It asks if It can settle in the world already.*";
            }
            else
            {
                mes = "*The raccoon creature looks sad now. Said that maybe other time he can return and ask.*";
            }
            return mes;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (PlayerHasRococo)
            {
                button = "Welcome back.";
            }
            else if (!RejectedOnce)
            {
                if (AcceptedOnce)
                {
                    button = "Let's go!";
                }
                else
                {
                    button = "You can live here.";
                    button2 = "Sorry, but no.";
                }
            }
        }

        public override void AI()
        {
            if (!Main.dayTime)
            {
                bool PlayerInRange = false;
                bool TalkingWithMe = false;
                for (int p = 0; p < 255; p++)
                {
                    Player pl = Main.player[p];
                    if (pl.active)
                    {
                        if (pl.talkNPC == npc.whoAmI)
                            TalkingWithMe = true;
                        if ((Math.Abs(pl.Center.X - npc.Center.X) >= NPC.sWidth * 0.5f + NPC.safeRangeX ||
                            Math.Abs(pl.Center.Y - npc.Center.Y) >= NPC.sHeight * 0.5f + NPC.safeRangeY))
                        {
                            PlayerInRange = true;
                        }
                    }
                }
                if (!TalkingWithMe)
                {
                    Idle = true;
                }
                if (PlayerInRange)
                {
                    Main.NewText("The Raccoon vanished in the sunset.");
                    npc.active = false;
                    npc.life = 0;
                    return;
                }
            }
            npc.dontTakeDamage = npc.dontTakeDamageFromHostiles = npc.dontCountMe = true;
            base.AI();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime && !NpcMod.HasGuardianNPC(0) && !PlayerMod.PlayerHasGuardian(Main.player[Main.myPlayer], 0) && Main.time > 27000 && Main.time < 48600 && !NPC.AnyNPCs(ModContent.NPCType<RococoNPC>()))
            {
                return (float)(Main.time - 27000) / 432000;
            }
            return 0;
        }
    }
}
