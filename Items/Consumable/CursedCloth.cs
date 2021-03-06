﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class CursedCloth : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cursed Cloth";
            item.width = item.height = 16;
            item.toolTip = "Summons Infernon";
            item.rare = 4;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.position.Y / 16f < Main.maxTilesY - 200)
            {
                Main.NewText("Infernon will only appear before you in Hell.", 200, 80, 130, true);
                return false;
            }
            else if (!NPC.AnyNPCs(mod.NPCType("Infernon")))
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
           
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Infernon"));
           
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.HellstoneBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
