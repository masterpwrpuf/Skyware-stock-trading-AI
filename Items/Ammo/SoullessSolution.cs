﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	class SoullessSolution : ModItem
	{
        public override void SetDefaults()
        {
            item.name = "Soulless Solution";
            item.shoot = mod.ProjectileType("SoullessSolution") - ProjectileID.PureSpray;
            item.ammo = AmmoID.Solution;
            item.width = 10;
            item.height = 12;
            item.value = 0;
            item.rare = 3;
            item.maxStack = 999;
            item.toolTip = "Used by the Clentaminator";
            item.toolTip2 = "Destroys the spirit";
            item.consumable = true;
        }
    }
}
