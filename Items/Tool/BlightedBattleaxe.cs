using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class BlightedBattleaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Blighted Battleaxe";
            item.width = 60;
            item.height = 60;
            item.value = 40000;
            item.rare = 4;

            item.axe = 13;

            item.damage = 27;
            item.knockBack = 5;

            item.useStyle = 1;
            item.useTime = 8;
            item.useAnimation = 29;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}