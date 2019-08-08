using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class FrozenRune : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Frozen Rune");
            Tooltip.SetDefault("A rune of numbing, wintry cold\n" +
                "While active, you deal half damage\n" +
                "Mana costs are cut in half\n" +
                "Enemies will drop 50% more money");
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
            bool frozen = crMod.Frozen();
            if(frozen)
            {
                Main.NewText("Frozen is now active.", 135, 245, 255);
            }
            else
            {
                Main.NewText("Frozen is no longer active.", 135, 245, 255);
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
