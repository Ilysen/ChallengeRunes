using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class ArmageddonRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Armageddon Rune");
            Tooltip.SetDefault("A rune prophesying the end\nWhile active, bosses will instantly kill you\nDefeating a boss will yield five treasure bags\nCauses instant death if toggled while a boss is active");
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
            if(crMod.Apocalypse(true))
            {
                Main.NewText("Apocalypse is active; disable that first.", 125, 125, 125);
                return true;
            }
            bool arma = crMod.Armageddon();
            if(arma)
            {
                Main.NewText("Armageddon is now active.", 255, 0, 255);
            }
            else
            {
                Main.NewText("Armageddon is no longer active.", 255, 0, 255);
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
