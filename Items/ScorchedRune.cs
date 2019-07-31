using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class ScorchedRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Scorched Rune");
            Tooltip.SetDefault("A rune of blazing, withering heat\nWhile active, all life regeneration is disabled\nDamage-over-time debuffs won't affect you\nEnemies will drop additional hearts\nBosses will drop life crystals and mana crystals\nHardmode bosses will also drop life fruits");
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
            if (player.statLife < player.statLifeMax2)
            {
                Main.NewText("Get to full health first.", 125, 125, 125);
                return true;
            }
            bool scorched = crMod.Scorched();
            if (scorched)
            {
                Main.NewText("Scorched is now active.", 255, 0, 0);
            }
            else
            {
                Main.NewText("Scorched is no longer active.", 255, 0, 0);
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
