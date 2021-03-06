using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuskPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dusk Plate";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increases ranged damage by 10%");
            AddTooltip("25% Chance to not consume arrows");
            item.value = 50000;
            item.rare = 5;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage = 1.10f;
            player.ammoCost75 = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuskStone", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}