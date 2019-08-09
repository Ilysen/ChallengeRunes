using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class PetrifiedRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Petrified Rune");
            Tooltip.SetDefault("A crumbling, rocky rune\n" +
                "While active, movement acceleration is reduced by 75%\n" +
                "Hostile enemies may drop igneous gravel\n" +
                "Smelt igneous gravel into various ores at a hellforge");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 3;
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
            bool arma = crMod.Petrified();
            if(arma)
            {
                Main.NewText("Petrified is now active.", 175, 0, 0);
            }
            else
            {
                Main.NewText("Petrified is no longer active.", 175, 0, 0);
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
