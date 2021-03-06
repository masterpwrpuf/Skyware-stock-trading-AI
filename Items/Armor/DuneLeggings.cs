using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuneLeggings : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dune Leggings";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases Movement Speed by 15% and Thrown Cost by 10%";
            item.value = 56000;
            item.rare = 6;
            item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed+= 0.15f;
            player.thrownCost33 = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence", 18);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}