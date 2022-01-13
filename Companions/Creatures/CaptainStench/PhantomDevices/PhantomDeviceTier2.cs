﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.ModLoader;

namespace giantsummon.Companions.Creatures.CaptainStench.PhantomDevices
{
    public class PhantomDeviceTier2 : Items.GuardianItemPrefab
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Allows the use of Phantom Blitz 2 times.");
        }

        public override void SetDefaults()
        {
            item.value = 100;
            item.stack = 1;
            item.accessory = true;
            item.scale = 1.25f;
        }

        public override void ItemStatusScript(TerraGuardian g)
        {
            g.MMP += 20;
            if (g.Data is CaptainStenchBase.CaptainStenchData)
            {
                CaptainStenchBase.CaptainStenchData data = (CaptainStenchBase.CaptainStenchData)g.Data;
                const int DID = 2;
                if (data.DeviceID < DID)
                    data.DeviceID = DID;
            }
        }
    }
}
