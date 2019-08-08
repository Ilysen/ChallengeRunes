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
            Tooltip.SetDefault("A rune of sickly, profane defilement\n" +
                "While active, damage taken from monsters is doubled\n" +
                "Enemies will drop twice as much money\n" +
                "Bosses will drop an additional treasure bag");
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

        public override bool UseItem(Player player)
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc.boss && npc.active)
                {
                    PlayerDeathReason runeDeath = PlayerDeathReason.ByCustomReason(player.name + " defied the runes.");
                    Main.PlaySound(SoundID.NPCDeath59.WithVolume(0.5f), player.Center);
                    player.KillMe(runeDeath, 1.0, 0, false);
                    return true;
                }
            }
            ChallengeRunes crMod = (ChallengeRunes)mod;
            if (crMod.Apocalypse(true))
            {
                Main.NewText("Apocalypse is active; disable that first.", 125, 125, 125);
                return true;
            }
            bool defi = crMod.Defiled();
            if(defi)
            {
                Main.NewText("Defiled is now active.", 0, 255, 0);
            }
            else
            {
                Main.NewText("Defiled is no longer active.", 0, 255, 0);
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
