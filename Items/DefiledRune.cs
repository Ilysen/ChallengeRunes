using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class DefiledRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Defiled Rune");
            Tooltip.SetDefault("While active, damage taken from monsters is doubled\n" +
                "Enemies will drop twice as much money\n" +
                "Bosses will drop an additional treasure bag (not stacking with Armageddon)");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 7;
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
            if (!ChallengeRunes.CheckRune(player, "defiled"))
            {
                ChallengeRunes.NewText(player, "Defiled is now active.", 0, 255, 0);
                ChallengeRunes.SetRune(player, "defiled");
            }
            else
            {
                ChallengeRunes.NewText(player, "Defiled is no longer active.", 0, 255, 0);
                ChallengeRunes.RemoveRune(player, "defiled");
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
