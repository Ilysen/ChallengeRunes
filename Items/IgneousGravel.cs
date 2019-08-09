using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class IgneousGravel : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Igneous Gravel");
            Tooltip.SetDefault("Dropped from challenge rune kills\nCan be shaped into ore at a hellforge");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.rare = 3;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.CopperOre, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.TinOre, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.IronOre, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.LeadOre, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.SilverOre, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.TungstenOre, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.GoldOre, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.PlatinumOre, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.CobaltOre, 3);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.MythrilOre, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.OrichalcumOre, 2);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.AdamantiteOre, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddIngredient(this);
            recipe.SetResult(ItemID.TitaniumOre, 1);
            recipe.AddRecipe();
        }
    }
}
