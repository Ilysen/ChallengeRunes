using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class FleshRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Flesh Rune");
            Tooltip.SetDefault("A wet, bleeding rune\n" +
                "While active, defense is halved\n" +
                "Armor penetration is increased by 50");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 4;
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
            bool arma = crMod.Flesh();
            if(arma)
            {
                Main.NewText("Flesh is now active.", 220, 30, 100);
            }
            else
            {
                Main.NewText("Flesh is no longer active.", 220, 30, 100);
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
