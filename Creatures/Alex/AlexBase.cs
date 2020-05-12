﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Microsoft.Xna.Framework;

namespace giantsummon.Creatures
{
    public class AlexBase : GuardianBase
    {
        public const int HealingLickAction = 0;
        /// <summary>
        /// -Very playful.
        /// -Blames himself for his old partner's demise.
        /// -Bad at protecting people.
        /// -Extremelly sociable.
        /// </summary>

        public AlexBase()
        {
            Name = "Alex";
            Description = "Your new best friend, a very playful one.";
            Size = GuardianSize.Large;
            Width = 68;
            Height = 62;
            DuckingHeight = 52;
            SpriteWidth = 96;
            SpriteHeight = 96;
            Age = 42; //Mental Age = Age / 9
            Male = true;
            InitialMHP = 175; //1125
            LifeCrystalHPBonus = 30;
            LifeFruitHPBonus = 25;
            Accuracy = 0.36f;
            Mass = 0.7f;
            MaxSpeed = 5.65f;
            Acceleration = 0.33f;
            SlowDown = 0.83f;
            MaxJumpHeight = 15;
            JumpSpeed = 6.71f;
            CanDuck = false;
            ReverseMount = false;
            DrinksBeverage = false;
            DontUseRightHand = false;
            SetTerraGuardian();
            //HurtSound = new SoundData(Terraria.ID.SoundID.DD2_KoboldHurt);
            //DeadSound = new SoundData(Terraria.ID.SoundID.DD2_KoboldDeath);
            CallUnlockLevel = 0;

            PopularityContestsWon = 0;
            ContestSecondPlace = 0;
            ContestThirdPlace = 2;

            AddInitialItem(Terraria.ID.ItemID.Trident, 1);
            AddInitialItem(Terraria.ID.ItemID.HealingPotion, 5);

            //Animation Frames
            StandingFrame = 0;
            WalkingFrames = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            JumpFrame = 9;
            //HeavySwingFrames = new int[] { 10, 11, 12 };
            ItemUseFrames = new int[] { 10, 11, 12, 13 };
            //DuckingFrame = 20;
            //DuckingSwingFrames = new int[] { 21, 22, 12 };
            SittingFrame = 14;
            ChairSittingFrame = 18;
            SittingItemUseFrames = new int[] { 15, 16, 17 };
            DrawLeftArmInFrontOfHead.AddRange(new int[] { 10, 11, 15 });
            ThroneSittingFrame = 22;
            BedSleepingFrame = 23;
            SleepingOffset.X = 16;
            ReviveFrame = 20;
            DownedFrame = 29;
            PetrifiedFrame = 30;

            SpecificBodyFrontFramePositions = true;
            BodyFrontFrameSwap.Add(14, 0);

            //for(int f = 0; f < 9; f++)
            //    RightArmFrontFrameSwap.Add(f, 0);
            //RightArmFrontFrameSwap.Add(99, 1);
            //RightArmFrontFrameSwap.Add(100, 2);

            //Mount Player Sit Position
            MountShoulderPoints.DefaultCoordinate2x = new Point(30, 25);
            MountShoulderPoints.AddFramePoint2x(14, 13, 20);
            SittingPoint = new Point(20 * 2, 41 * 2); //14, 40 > 20,41

            //Left Arm Item Position
            LeftHandPoints.AddFramePoint2x(10, 37, 28);
            LeftHandPoints.AddFramePoint2x(11, 41, 31);
            LeftHandPoints.AddFramePoint2x(12, 42, 37);
            LeftHandPoints.AddFramePoint2x(13, 39, 43);

            LeftHandPoints.AddFramePoint2x(15, 24 + 6, 14 + 1);
            LeftHandPoints.AddFramePoint2x(16, 29 + 6, 27 + 1);
            LeftHandPoints.AddFramePoint2x(17, 22 + 6, 36 + 1);

            LeftHandPoints.AddFramePoint2x(19, 38, 47);
            LeftHandPoints.AddFramePoint2x(20, 38, 47);
            LeftHandPoints.AddFramePoint2x(21, 38, 47);
            LeftHandPoints.AddFramePoint2x(24, 38, 47);
            LeftHandPoints.AddFramePoint2x(25, 38, 47);
            LeftHandPoints.AddFramePoint2x(26, 38, 47);
            LeftHandPoints.AddFramePoint2x(27, 38, 47);
            LeftHandPoints.AddFramePoint2x(28, 38, 47);

            //Mouth Item Position
            RightHandPoints.DefaultCoordinate2x = new Point(43, 29);
            RightHandPoints.AddFramePoint2x(2, 31, 24);

            //Wing Position
            WingPosition.DefaultCoordinate2x = new Point(30, 27);
            WingPosition.AddFramePoint2x(14, 17 + 6, 25 + 1);
            WingPosition.AddFramePoint2x(18, 17 + 6, 25 + 1);

            //Helmet Position
            HeadVanityPosition.DefaultCoordinate2x = new Point(38, 23);
            HeadVanityPosition.AddFramePoint2x(14, 21 + 6, 17 + 1);
            HeadVanityPosition.AddFramePoint2x(15, 21 + 6, 17 + 1);
            HeadVanityPosition.AddFramePoint2x(16, 21 + 6, 17 + 1);
            HeadVanityPosition.AddFramePoint2x(17, 21 + 6, 17 + 1);
            HeadVanityPosition.AddFramePoint2x(18, 21 + 6, 17 + 1);
            HeadVanityPosition.AddFramePoint2x(22, 23, 17);

            HeadVanityPosition.AddFramePoint2x(19, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(20, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(21, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(19, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(24, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(25, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(26, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(27, -1000, -1000);
            HeadVanityPosition.AddFramePoint2x(28, -1000, -1000);
        }

        public override string MountUnlockMessage
        {
            get
            {
                return "Hey, let's play Dragon Fighter? Mount on my back so we can be like Knight and Steed!";
            }
        }

        public override string ControlUnlockMessage
        {
            get
            {
                return "I care so much for you, I don't want to see any harm come to you. If you need to do something dangerous, let me go do it instead.";
            }
        }

        public override string FriendLevelMessage
        {
            get
            {
                return "You're back! You're back! Yay!! *He's jumping around in circles, out of happiness, after seeing you.*";
            }
        }

        public override string BestFriendLevelMessage
        {
            get
            {
                return "You're one of the best pack members I ever had! You're the best!";
            }
        }

        public override string BFFLevelMessage
        {
            get
            {
                return "Hey, look what I found! It's for you! Just for my best friend! *He gave you a bone.*";
            }
        }

        public override string BuddyForLifeLevelMessage
        {
            get
            {
                return "I had " + AlexRecruitScripts.AlexOldPartner + ", now I have you. I had the best friends I could have ask for!";
            }
        }

        public override void GuardianAnimationOverride(TerraGuardian guardian, byte AnimationID, ref int Frame)
        {
            if (AnimationID == 2)
            {
                if (guardian.BodyAnimationFrame == ThroneSittingFrame || guardian.BodyAnimationFrame == BedSleepingFrame)
                {
                    Frame = 0;
                }
                else if (guardian.SelectedOffhand > -1)
                {
                    if (guardian.BodyAnimationFrame == SittingFrame || guardian.BodyAnimationFrame == ChairSittingFrame)
                    {
                        Frame = 2;
                    }
                    else
                    {
                        Frame = 1;
                    }
                }
                else
                {
                    Frame = 0;
                }
            }
        }

        public override bool WhenTriggerActivates(TerraGuardian guardian, TriggerTypes trigger, int Value, int Value2 = 0, float Value3 = 0f, float Value4 = 0f, float Value5 = 0f)
        {
            /*if (!guardian.DoAction.InUse)
            {
                if (trigger == TriggerTypes.PlayerHurt)
                {
                    GuardianActions action = guardian.StartNewGuardianAction(HealingLickAction);
                    action.Players.Add(Main.player[Value]);
                }
                if (trigger == TriggerTypes.GuardianHurt)
                {
                    GuardianActions action = guardian.StartNewGuardianAction(HealingLickAction);
                    action.Guardians.Add(MainMod.ActiveGuardians[Value]);
                }
            }*/
            return base.WhenTriggerActivates(guardian, trigger, Value, Value2, Value3, Value4, Value5);
        }

        public override void GuardianActionUpdate(TerraGuardian guardian, GuardianActions action)
        {
            switch (action.ID)
            {
                case HealingLickAction:
                    {
                        action.AvoidItemUsage = true;
                        switch (action.Step)
                        {
                            case 0: //Reach Target
                                Vector2 TargetPosition = Vector2.Zero;
                                int TargetWidth = 0, TargetHeight = 0;
                                action.IgnoreCombat = true;
                                if (action.Players.Count > 0)
                                {
                                    TargetPosition = action.Players[0].position;
                                    TargetWidth = action.Players[0].width;
                                    TargetHeight = action.Players[0].height;
                                }
                                else if (action.Guardians.Count > 0)
                                {
                                    TargetPosition = action.Guardians[0].TopLeftPosition;
                                    TargetWidth = action.Guardians[0].Width;
                                    TargetHeight = action.Guardians[0].Height;
                                }
                                else
                                {
                                    action.InUse = false;
                                    return;
                                }
                                if (guardian.HitBox.Intersects(new Rectangle((int)TargetPosition.X, (int)TargetPosition.Y, TargetWidth, TargetHeight)))
                                {
                                    action.ChangeStep();
                                }
                                else
                                {
                                    guardian.MoveLeft = guardian.MoveRight = false;
                                    if (TargetPosition.X + TargetWidth * 0.5f - guardian.CenterPosition.X < 0)
                                    {
                                        guardian.MoveLeft = true;
                                    }
                                    else
                                    {
                                        guardian.MoveRight = true;
                                    }
                                    if (action.Time >= 5 * 60)
                                    {
                                        action.InUse = false;
                                        guardian.DisplayEmotion(TerraGuardian.Emotions.Sad);
                                    }
                                }
                                break;

                            case 1:
                                {
                                    guardian.MoveLeft = guardian.MoveRight = false;
                                    action.NoAggro = action.AvoidItemUsage = action.Immune = true;
                                    Vector2 EffectPosition = new Vector2(22 * guardian.Scale * guardian.Direction,0) + guardian.Position;
                                    bool AnimationTrigger = action.Time == 120 + 8 * 2 || action.Time == 120 + 8 * 5 + 8 * 2 || action.Time == 120 + 8 * 10 + 8 * 2;
                                    bool RestoreCharacters = false;
                                    if (action.Time >= 120 + 8 * 15)
                                    {
                                        RestoreCharacters = true;
                                        action.InUse = false;
                                    }
                                    if (action.Players.Count > 0)
                                    {
                                        Player p = action.Players[0];
                                        if (AnimationTrigger)
                                        {
                                            int HealthRestored = (int)(p.statLifeMax2 * 0.1f);
                                            p.statLife += HealthRestored;
                                            p.HealEffect(HealthRestored);
                                        }
                                        if (RestoreCharacters)
                                        {
                                            p.position = guardian.Position;
                                            p.position.X -= p.width * 0.5f;
                                            p.position.Y -= p.height;
                                            p.fullRotation = 0;
                                        }
                                        else
                                        {
                                            p.Center = EffectPosition;
                                            p.direction = -guardian.Direction;
                                            p.fullRotation = 1.570796326794897f * guardian.Direction;
                                            if (p.immuneTime < 5)
                                                p.immuneTime = 5;
                                        }
                                    }
                                    else if (action.Guardians.Count > 0)
                                    {
                                        TerraGuardian g = action.Guardians[0];
                                        if (AnimationTrigger)
                                        {
                                            g.RestoreHP((int)(g.MHP * 0.1f));
                                        }
                                        if (RestoreCharacters)
                                        {
                                            g.Position = guardian.Position;
                                            g.Rotation = 0;
                                        }
                                        else
                                        {
                                            g.Position = EffectPosition;
                                            g.Position.Y += g.Height * 0.5f;
                                            g.Direction = -g.Direction;
                                            g.Rotation = 1.570796326794897f * guardian.Direction;
                                            if (g.ImmuneTime < 5)
                                                g.ImmuneTime = 5;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        public override void GuardianActionUpdateAnimation(TerraGuardian guardian, GuardianActions action, ref bool UsingLeftArm, ref bool UsingRightArm)
        {
            switch (action.ID)
            {
                case HealingLickAction:
                    {
                        switch (action.Step)
                        {
                            case 0:
                                break;
                            case 1:
                                if (action.Time < 120)
                                {
                                    int Animation = (action.Time / 5) % 4;
                                    if (Animation == 3)
                                        Animation = 1;
                                    guardian.BodyAnimationFrame = 19 + Animation;
                                    guardian.LeftArmAnimationFrame = guardian.RightArmAnimationFrame = guardian.BodyAnimationFrame;
                                    UsingLeftArm = UsingRightArm = true;
                                }
                                else
                                {
                                    int Animation = (action.Time / 8) % 5;
                                    guardian.BodyAnimationFrame = 24 + Animation;
                                    guardian.LeftArmAnimationFrame = guardian.RightArmAnimationFrame = guardian.BodyAnimationFrame;
                                    UsingLeftArm = UsingRightArm = true;
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        public override string GreetMessage(Player player, TerraGuardian guardian)
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Hey, who are you? Are you my newest friend?";
                case 1:
                    return "More friends? I like that!";
                case 2:
                    return "Yay! I met more people!";
            }
            return base.GreetMessage(player, guardian);
        }

        public override string NormalMessage(Player player, TerraGuardian guardian)
        {
            List<string> Mes = new List<string>();
            Mes.Add("Yay! I met more people!");
            Mes.Add("Don't worry, I'll protect you from any danger.");
            Mes.Add("I'm sure you would like to meet " + AlexRecruitScripts.AlexOldPartner + ", well, she was a bit closed to other people, but she was my best pal, that's what matter, I guess?");
            Mes.Add("I wonder if " + AlexRecruitScripts.AlexOldPartner + "'s tombstone is alright. I should check it up later?");
            if (Main.bloodMoon)
            {
                Mes.Add("Stay near me and you'll be safe.");
                Mes.Add("So many things to bite outside.");
            }
            if (Main.eclipse)
            {
                Mes.Add("I think I saw some of those guys in some movies I watched with " + AlexRecruitScripts.AlexOldPartner + ".");
                Mes.Add("I don't fear any of those monsters outside, the only thing I fear is the Legion, but It doesn't exists in this world.");
            }
            if (Main.dayTime)
            {
                if (!Main.eclipse)
                {
                    if (!Main.raining)
                        Mes.Add("The day seems good enough for playing outside!");
                    else
                        Mes.Add("The rain would spoil the fun, If wasn't for the puddles.");
                    Mes.Add("I still have two AA batteries to be depleted, let's play a game!");
                }
            }
            else
            {
                if (!Main.bloodMoon)
                {
                    if (Main.moonPhase == 2)
                        Mes.Add("This night remembers me of an adventure I had with " + AlexRecruitScripts.AlexOldPartner + ". That makes me miss her.");
                }
            }
            if (NpcMod.HasGuardianNPC(0))
            {
                Mes.Add("When you are not around, I play some Hide and Seek with [gn:0]. He's really bad at hiding, his tail gives him away, but It's fun to always find him.");
                if (NPC.AnyNPCs(Terraria.ID.NPCID.Merchant))
                    Mes.Add("Do you know why [gn:0] eats [nn:" + Terraria.ID.NPCID.Merchant + "]'s trash? I'd join him but, " + AlexRecruitScripts.AlexOldPartner + " teached me that eating trash is bad.");
            }
            if (NpcMod.HasGuardianNPC(1))
            {
                Mes.Add("I fertilized [gn:1]'s yard, and she thanked me by chasing me while swinging her broom on me. I guess we are besties now.");
                Mes.Add("[gn:1] looked very upset when I was playing with her red cloak. By the way, tell her that you didn't see me if she asks.");
                if (NpcMod.HasGuardianNPC(2))
                    Mes.Add("Why [gn:1] watches [gn:2] and I playing, and don't join us in the fun? Would be better than staring, right?");
            }
            if (NpcMod.HasGuardianNPC(2))
            {
                Mes.Add("[gn:2] called me to go on an adventure, I wonder if you will mind that.");
            }
            if (NpcMod.HasGuardianNPC(3))
            {
                Mes.Add("I asked earlier if [gn:3] were using one of his bones. His answer was very rude.");
                if (NpcMod.HasGuardianNPC(1))
                    Mes.Add("Why does [gn:3] and [gn:1] looks a bit sad when meet each other? Aren't they dating?");
                Mes.Add("I tried cheering [gn:3], he threw a frizbee for me to catch, but when I returned, he wasn't there. Where did he go?");
            }
            if (NpcMod.HasGuardianNPC(4))
            {
                Mes.Add("What's with [gn:4]? He never shows up any kind of emotion when I talk to him. Even when we play.");
                Mes.Add("I don't really have any fun when playing with [gn:4], because he doesn't seems to be having fun.");
            }
            if (NpcMod.HasGuardianNPC(0) && NpcMod.HasGuardianNPC(2))
                Mes.Add("I've got [gn:0] and [gn:2] to play with me. I guess my new dream will be everyone in the village to play together.");
            if (NpcMod.HasGuardianNPC(7))
            {
                Mes.Add("I think sometimes [gn:7] feels lonely, so I stay nearby to make her feel less lonely.");
                Mes.Add("I smell a variety of things inside of [gn:7]'s bag, includding food. Can you persuade her to open her bag and show us what is inside?");
            }
            if (NpcMod.HasGuardianNPC(8))
            {
                Mes.Add("I love playing with [gn:8], the other person that played as much with me was " + AlexRecruitScripts.AlexOldPartner + ".");
                Mes.Add("I'm up to playing some more, do you know if [gn:8] is free?");
            }
            if (NpcMod.HasGuardianNPC(Vladimir))
            {
                Mes.Add("(He's watching the horizon. Maybe he's thinking about something?)");
                Mes.Add("Have been talking with [gn:"+Vladimir+"] and... No... Forget it... Nevermind what I was saying.");
                Mes.Add("That [gn:" + Vladimir + "] is a real buddy, he accompany me when I go visit " + AlexRecruitScripts.AlexOldPartner + "'s Tombstone. I don't feel alone when doing that anymore.");
            }
            if (guardian.IsUsingToilet)
            {
                Mes.Add("I'm trying hard to aim at the hole.");
                Mes.Add("Is this how you humans uses toilet? It's very hard for me to use it.");
            }
            return Mes[Main.rand.Next(Mes.Count)];
        }

        public override string NoRequestMessage(Player player, TerraGuardian guardian)
        {
            if (Main.rand.NextDouble() < 0.5)
                return "Other than playing? I want nothing else.";
            return "I'm full of energy, if that's what you mean.";
        }

        public override string HasRequestMessage(Player player, TerraGuardian guardian)
        {
            if (Main.rand.NextDouble() < 0.5)
                return "I really need something to be done. What? Thought I was into playing 24/7?";
            return "There is a thing I need to be done, can you help me with it?";
        }

        public override string CompletedRequestMessage(Player player, TerraGuardian guardian)
        {
            if (Main.rand.NextDouble() < 0.5)
                return "Yay! You're the best!";
            return "You did it! Yay!";
        }

        public override string HomelessMessage(Player player, TerraGuardian guardian)
        {
            List<string> Mes = new List<string>();
            Mes.Add("There's a lot of space in this backyard, but... Where will I sleep?");
            if (Main.raining)
                Mes.Add("This is awful, you know. I could have a less wet place to stay.");
            if (!Main.dayTime)
                Mes.Add("I don't fear anything, but I'd like to sleep soundly at night.");
            if (Main.bloodMoon)
                Mes.Add("Looks like I wont have a rest this night. If I had a place to live, I could avoid that.");

            return Mes[Main.rand.Next(Mes.Count)];
        }

        public override string TalkMessage(Player player, TerraGuardian guardian)
        {
            List<string> Mes = new List<string>();
            Mes.Add("My old partner once said that I had C batteries in the body. What is that supposed to mean?");
            Mes.Add("You're the best, let's play a game?");
            Mes.Add(AlexRecruitScripts.AlexOldPartner + " and I were the best friends every! I should've followed my instincts and stopped her.");
            if (PlayerMod.PlayerHasGuardian(player, 0))
                Mes.Add("[gn:0] and I are trying to guess who's your best friend. Can you tell me?");
            if(!Main.dayTime && Main.moonPhase == 2)
                Mes.Add("Maybe I should tell you why " + AlexRecruitScripts.AlexOldPartner + " isn't with us anymore... She tried to protect me from flying bugs in the purple place... I should be the one protecting her, not the inverse.");
            return Mes[Main.rand.Next(Mes.Count)];
        }

        public override string BirthdayMessage(Player player, TerraGuardian guardian)
        {
            if (!PlayerMod.HasGuardianBeenGifted(player, 5) && Main.rand.NextDouble() < 0.5)
                return "Woof! Woof! What you brought me? Is it edible? Is it a new toy?";
            return "A party? Just for me? I must be the luckiest dog ever!";
        }
    }
}
