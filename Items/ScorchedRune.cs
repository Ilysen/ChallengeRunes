using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class ScorchedRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Scorched Rune");
            Tooltip.SetDefault("While active, all life regeneration is disabled\n" +
                "Bosses will drop life crystals and mana crystals\n" +
                "Hardmode bosses will also drop life fruits");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = -11;
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
            if (!ChallengeRunes.CheckRune(player, "scorched"))
            {
                ChallengeRunes.NewText(player, "Scorched is now active.", 255, 150, 55);
                ChallengeRunes.SetRune(player, "scorched");
            }
            else
            {
                ChallengeRunes.NewText(player, "Scorched is no longer active.", 255, 150, 55);
                ChallengeRunes.RemoveRune(player, "scorched");
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
