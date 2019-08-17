using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class ArmageddonRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Armageddon Rune");
            Tooltip.SetDefault("While active, bosses will instantly kill you\n" +
                "Defeating a boss will yield six additional treasure bags\n" +
                "Causes instant death if toggled while a boss is active\n" +
                "Deactivates upon death");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 10;
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
            if(!ChallengeRunes.CheckRune(player, "armageddon"))
            {
                ChallengeRunes.NewText(player, "Armageddon is now active.", 255, 0, 255);
                ChallengeRunes.SetRune(player, "armageddon");
            }
            else
            {
                ChallengeRunes.NewText(player, "Armageddon is no longer active.", 255, 0, 255);
                ChallengeRunes.RemoveRune(player, "armageddon");
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
