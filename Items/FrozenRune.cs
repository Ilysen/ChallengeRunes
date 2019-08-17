using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class FrozenRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Frozen Rune");
            Tooltip.SetDefault("While active, you deal half damage\n" +
                "Enemies will drop 50% more money\n" +
                "Bosses will drop an additional gold coin for each 500 points of max life they have");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 9;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
        }

        public override bool CanUseItem(Player player)
        {
            if (ChallengeRunes.AntiCheese(player))
                return false;
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (!ChallengeRunes.CheckRune(player, "frozen"))
            {
                ChallengeRunes.NewText(player, "Frozen is now active.", 135, 245, 255);
                ChallengeRunes.SetRune(player, "frozen");
            }
            else
            {
                ChallengeRunes.NewText(player, "Frozen is no longer active.", 135, 245, 255);
                ChallengeRunes.RemoveRune(player, "frozen");
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
