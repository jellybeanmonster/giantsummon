﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace giantsummon
{
    public class RequestBase
    {
        public string Name = "";
        public string BriefText = "", AcceptText = "", DenyText = "", CompleteText = "", RequestInfoText = "";
        public List<RequestObjective> Objectives = new List<RequestObjective>();
        public delegate bool RequestRequirementDel(Terraria.Player player);
        public RequestRequirementDel Requirement = delegate(Terraria.Player player) { return true; };
        public int RequestScore = 500;

        public RequestBase(string Name, int RequestScore, string BriefText, string AcceptText, string DenyText, string CompleteText, string RequestInfoText)
        {
            this.Name = Name;
            this.RequestScore = RequestScore;
            this.BriefText = BriefText;
            this.AcceptText = AcceptText;
            this.DenyText = DenyText;
            this.CompleteText = CompleteText;
            this.RequestInfoText = RequestInfoText;
        }

        public bool IsRequestDoable(Terraria.Player player, GuardianData gd)
        {
            bool Is = Requirement(player);
            if (Is)
            {
                foreach (RequestObjective ro in Objectives)
                {
                    if (ro.objectiveType == RequestObjective.ObjectiveTypes.CompanionRequirement)
                    {
                        CompanionRequirementRequest req = (CompanionRequirementRequest)ro;
                        if (!PlayerMod.PlayerHasGuardian(player, req.CompanionID, req.CompanionModID))
                        {
                            Is = false;
                            break;
                        }
                    }
                }
            }
            return Is;
        }

        public void AddHuntObjective(int NpcID, int Stack = 5, float StackPerFriendLevel = 0.333f)
        {
            HuntRequestObjective req = new HuntRequestObjective();
            req.NpcID = NpcID;
            req.Stack = Stack;
            req.StackIncreasePerFriendshipLevel = StackPerFriendLevel;
            Objectives.Add(req);
        }

        public void AddItemCollectionRequest(int ItemID, int Stack = 5, float StackPerFriendLevel = 0.333f)
        {
            CollectItemRequest req = new CollectItemRequest();
            req.ItemID = ItemID;
            req.ItemStack = Stack;
            req.StackIncreasePerFriendshipLevel = StackPerFriendLevel;
            Objectives.Add(req);
        }

        public void AddExploreRequest(float InitialDistance, float DistanceIncreasePerFriendLevel = 100f, bool RequiresRequester = true)
        {
            ExploreRequest req = new ExploreRequest();
            req.InitialDistance = InitialDistance;
            req.StackIncreasePerFriendshipLevel = DistanceIncreasePerFriendLevel;
            req.RequiresGuardianActive = RequiresRequester;
            Objectives.Add(req);
        }

        public void AddEventParticipationRequest(int EventID, int WavesToSurvive, float ExtraWavesPerFriendshipLevel = 0.02f)
        {
            EventParticipationRequest req = new EventParticipationRequest();
            req.EventID = EventID;
            req.EventWaves = WavesToSurvive;
            req.ExtraWavesPerFriendshipLevel = ExtraWavesPerFriendshipLevel;
            Objectives.Add(req);
        }

        public void AddEventKillsRequest(int EventID, int KillCount, float ExtraKillsPerFriendshipLevel = 0.5f)
        {
            EventKillRequest req = new EventKillRequest();
            req.EventID = EventID;
            req.InitialKills = KillCount;
            req.ExtraKillsPerFriendshipLevel = ExtraKillsPerFriendshipLevel;
            Objectives.Add(req);
        }

        public void AddRequesterRequirement()
        {
            RequestObjective req = new RequestObjective(RequestObjective.ObjectiveTypes.RequiresRequester);
            Objectives.Add(req);
        }

        public void AddObjectCollectionRequest(string ObjectName, int ObjectCount, float ExtraObjectCountPerFriendshipLevel = 0.333f)
        {
            ObjectCollectionRequest req = new ObjectCollectionRequest();
            req.ObjectName = ObjectName;
            req.ObjectCount = ObjectCount;
            req.ObjectExtraCountPerFriendshipLevel = ExtraObjectCountPerFriendshipLevel;
            Objectives.Add(req);
        }

        public void AddObjectDroppingMonster(int MonsterID, float Rate)
        {
            if (Objectives.Count > 0 && Objectives[Objectives.Count - 1].objectiveType == RequestObjective.ObjectiveTypes.ObjectCollection)
            {
                ObjectCollectionRequest.DropRateFromMonsters rate = new ObjectCollectionRequest.DropRateFromMonsters(MonsterID, Rate);
                ((ObjectCollectionRequest)Objectives[Objectives.Count - 1]).DropFromMobs.Add(rate);
            }
        }

        public void AddCompanionRequirement(int ID, string ModID = "")
        {
            CompanionRequirementRequest req = new CompanionRequirementRequest();
            req.CompanionID = ID;
            if (ModID == "")
                ModID = MainMod.mod.Name;
            req.CompanionModID = ModID;
            Objectives.Add(req);
        }

        public void AddKillBossRequest(int BossID, int GemLevelBonus = 0)
        {
            KillBossRequest req = new KillBossRequest();
            req.BossID = BossID;
            req.DifficultyBonus = GemLevelBonus;
            Objectives.Add(req);
        }

        public class KillBossRequest : RequestObjective
        {
            public int BossID = 0, DifficultyBonus = 0;

            public KillBossRequest()
                : base(ObjectiveTypes.KillBoss)
            {

            }
        }

        public class CompanionRequirementRequest : RequestObjective
        {
            public int CompanionID = 0;
            public string CompanionModID = "";

            public CompanionRequirementRequest()
                : base(ObjectiveTypes.CompanionRequirement)
            {

            }
        }

        public class ObjectCollectionRequest : RequestObjective
        {
            public string ObjectName = "";
            public int ObjectCount = 0;
            public float ObjectExtraCountPerFriendshipLevel = 0.333f;
            public List<DropRateFromMonsters> DropFromMobs = new List<DropRateFromMonsters>();

            public ObjectCollectionRequest()
                : base(ObjectiveTypes.ObjectCollection)
            {

            }

            public struct DropRateFromMonsters
            {
                public int MobID;
                public float DropRate;

                public DropRateFromMonsters(int MobID, float DropRate)
                {
                    this.MobID = MobID;
                    this.DropRate = DropRate;
                }
            }
        }

        public class EventKillRequest : RequestObjective
        {
            public int EventID = 0;
            public int InitialKills = 20;
            public float ExtraKillsPerFriendshipLevel = 0.2f;

            public EventKillRequest()
                : base(ObjectiveTypes.EventKills)
            {

            }
        }

        public class EventParticipationRequest : RequestObjective
        {
            public int EventID = 0;
            public int EventWaves = 1;
            public float ExtraWavesPerFriendshipLevel = 0.02f;

            public EventParticipationRequest()
                : base(ObjectiveTypes.EventParticipation)
            {

            }
        }

        public class ExploreRequest : RequestObjective
        {
            public float InitialDistance = 1000f,
                StackIncreasePerFriendshipLevel = 100f;
            public bool RequiresGuardianActive = true;

            public ExploreRequest()
                : base(ObjectiveTypes.Explore)
            {

            }
        }

        public class CollectItemRequest : RequestObjective
        {
            public int ItemID = 0, ItemStack = 1;
            public float StackIncreasePerFriendshipLevel = 0.5f;

            public CollectItemRequest()
                : base(ObjectiveTypes.CollectItem)
            {

            }
        }

        public class HuntRequestObjective : RequestObjective
        {
            public int NpcID = 0, Stack = 1;
            public float StackIncreasePerFriendshipLevel = 0.5f;

            public HuntRequestObjective() : base(ObjectiveTypes.HuntMonster)
            {

            }
        }

        public class RequestObjective
        {
            public ObjectiveTypes objectiveType = ObjectiveTypes.None;

            public RequestObjective(ObjectiveTypes otype)
            {
                objectiveType = otype;
            }

            public enum ObjectiveTypes
            {
                None,
                HuntMonster,
                CollectItem,
                Explore,
                EventParticipation,
                EventKills,
                RequiresRequester,
                ObjectCollection,
                CompanionRequirement,
                KillBoss
            }
        }
    }
}
