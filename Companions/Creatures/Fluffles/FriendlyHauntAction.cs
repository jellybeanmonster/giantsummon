﻿using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace giantsummon.Companions.Creatures.Fluffles
{
    public class FriendlyHauntAction : GuardianActions
    {
        private TerraGuardian TargetGuardian;
        private Player TargetPlayer;
        public bool ByPlayerOrder = false;
        private bool LastPlayerFollower = false;


        public FriendlyHauntAction(Player Target, bool ByPlayerOrder = false)
        {
            TargetPlayer = Target;
            TargetGuardian = null;
            BlockOffHandUsage = NoAggro = true;
            this.ByPlayerOrder = ByPlayerOrder;
        }

        public FriendlyHauntAction(TerraGuardian Target, bool ByPlayerOrder = false)
        {
            TargetGuardian = Target;
            TargetPlayer = null;
            BlockOffHandUsage = NoAggro = true;
            this.ByPlayerOrder = ByPlayerOrder;
        }

        public override void Update(TerraGuardian guardian)
        {
            if(TargetPlayer != null)
            {
                if (TargetPlayer.dead || !TargetPlayer.active)
                {
                    InUse = false;
                    return;
                }
            }
            if(TargetGuardian != null)
            {
                if(!TargetGuardian.Active || TargetGuardian.Downed)
                {
                    InUse = false;
                    return;
                }
            }
            switch (Step)
            {
                case 0:
                    {
                        Rectangle TargetHitbox;
                        Vector2 TargetPosition;
                        if(TargetPlayer != null)
                        {
                            TargetPosition = TargetPlayer.Center;
                            TargetHitbox = TargetPlayer.getRect();
                        }
                        else
                        {
                            TargetPosition = TargetGuardian.CenterPosition;
                            TargetHitbox = TargetGuardian.HitBox;
                        }
                        if(!TargetHitbox.Intersects(guardian.HitBox) || Time >= 10 * 60)
                        {
                            ChangeStep();
                        }
                        else if(guardian.Position.X > TargetPosition.X)
                        {
                            guardian.MoveLeft = true;
                            guardian.MoveRight = false;
                        }
                        else
                        {
                            guardian.MoveRight = true;
                            guardian.MoveLeft = false;
                        }
                    }
                    break;

                case 1:
                    {
                        if(guardian.OwnerPos > -1 != LastPlayerFollower)
                        {
                            InUse = false;
                            return;
                        }
                        if (!ByPlayerOrder && Time >= 3 * 3600)
                        {
                            if (TargetPlayer != null)
                            {
                                guardian.Position = TargetPlayer.Bottom;
                            }
                            else
                            {
                                guardian.Position = TargetGuardian.Position;
                            }
                            InUse = false;
                            return;
                        }
                        guardian.ChangeIdleAction(TerraGuardian.IdleActions.Wait, 300);
                        Vector2 MountedPosition = guardian.Base.LeftHandPoints.GetPositionFromFrameVector(guardian.Base.PlayerMountedArmAnimation);
                        MountedPosition.X = MountedPosition.X - guardian.Base.SpriteWidth * 0.5f;
                        Vector2 HauntPosition = Vector2.Zero;
                        if (guardian.Direction > 0)
                            MountedPosition.X *= -1;
                        if (TargetPlayer != null)
                        {
                            if (guardian.ItemAnimationTime == 0)
                                guardian.Direction = TargetPlayer.direction;
                            HauntPosition = TargetPlayer.position;
                            HauntPosition.X += TargetPlayer.width * 0.5f;
                            HauntPosition.Y += TargetPlayer.height + (guardian.Base.SpriteHeight - MountedPosition.Y - 30) * guardian.Scale;
                            HauntPosition.X += (MountedPosition.X - 6 * guardian.Direction) * guardian.Scale;
                            guardian.AddDrawMomentToPlayer(TargetPlayer);
                        }
                        else
                        {
                            if (guardian.ItemAnimationTime == 0)
                                guardian.Direction = TargetGuardian.Direction;
                            HauntPosition = TargetGuardian.Position;
                            HauntPosition.X += (MountedPosition.X - 6 * guardian.Direction) * guardian.Scale; //TargetGuardian.Width * 0.2f * guardian.Direction;
                            HauntPosition.Y += MountedPosition.Y * guardian.Scale - TargetGuardian.Height * 0.95f;
                            guardian.AddDrawMomentToTerraGuardian(TargetGuardian);
                        }
                        guardian.Velocity = Vector2.Zero;
                        guardian.Position = HauntPosition;
                    }
                    break;
            }
            LastPlayerFollower = guardian.OwnerPos > -1;
        }

        public override void OnActionEnd(TerraGuardian guardian)
        {
            if (TargetPlayer != null)
            {
                guardian.Position = TargetPlayer.Bottom;
            }
            else
            {
                guardian.Position = TargetGuardian.Position;
            }
        }

        public override void UpdateAnimation(TerraGuardian guardian, ref bool UsingLeftArmAnimation, ref bool UsingRightArmAnimation)
        {
            if (Step == 1)
            {
                int Animation = guardian.Base.PlayerMountedArmAnimation;
                if(TargetGuardian != null)
                {
                    if (TargetGuardian.IsUsingBed)
                        Animation = guardian.Base.ReviveFrame;
                }
                guardian.BodyAnimationFrame = Animation;
                if (!UsingLeftArmAnimation) guardian.LeftArmAnimationFrame = Animation;
                if (!UsingRightArmAnimation) guardian.RightArmAnimationFrame = Animation;
            }
        }
    }
}
