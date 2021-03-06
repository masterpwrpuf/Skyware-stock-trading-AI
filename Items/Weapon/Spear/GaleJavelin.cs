using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear
{
    public class GaleJavelin : ModItem
    {
        private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Ocean's Gale Javelin";
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.toolTip = "Left-click to thrust at foes, Right-click to throw at enemies";
            item.useAnimation = 40;
            item.useTime = 40;
            item.shootSpeed = 6f;
            item.knockBack = 4f;
            item.damage = 25;
            item.value = Item.sellPrice(0, 2, 60, 0);
            item.rare = 3;
            item.shoot = mod.ProjectileType("GaleJavelinProj1");
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                item.thrown = true;
                item.autoReuse = true;
                item.useAnimation = 30;
                item.useTime = 30;
                item.shootSpeed = 15f;


                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GaleJavelinProj2"), damage, knockBack, player.whoAmI, 0f, 0f);
                return false;
            }
            else
            {
                item.autoReuse = false;
                item.melee = true;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GaleJavelinProj1"), damage, knockBack, player.whoAmI, 0f, 0f);
                item.shootSpeed = 6f;
            }
            return false;
        }
    }
}