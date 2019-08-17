using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes.NPCs
{
	public class ChallengeRunesNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
        
		public override void NPCLoot(NPC npc)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Player runePlayer = Main.LocalPlayer;
                if (ChallengeRunes.CheckRune(runePlayer, "armageddon") && npc.boss && npc.active)
                {
                    Main.PlaySound(SoundID.NPCDeath60.WithVolume(0.5f), npc.Center);
                    for (int i = 0; i < 6; i++)
                    {
                        npc.DropBossBags(); // Armageddon drops six additional bags
                    }
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin);
                }
                if (ChallengeRunes.CheckRune(runePlayer, "defiled"))
                {
                    npc.value *= 2;
                    if (npc.boss && npc.active && !(ChallengeRunes.CheckRune(runePlayer, "armageddon")))
                    {
                        npc.DropBossBags(); // Defiled yields one additional bag
                    }
                }
                if (ChallengeRunes.CheckRune(runePlayer, "frozen"))
                {
                    npc.value *= 1.5f;
                    if (npc.boss && npc.active)
                    {
                        int lodsOfEmone = npc.lifeMax / 500;
                        // It would be more efficient to spawn this as a stack, but a big burst of coins is much more satisfying
                        for (int i = 0; i < lodsOfEmone; i++)
                        {
                            // Crunch gold coins down into platinum to avoid going over item cap with modded bosses
                            if (lodsOfEmone >= 100)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PlatinumCoin);
                                lodsOfEmone -= 100;
                            }
                            else
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin);
                            }
                        }
                    }
                }
                if (ChallengeRunes.CheckRune(runePlayer, "scorched") && npc.boss)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeCrystal);
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ManaCrystal);
                    }

                    // This is far from a foolproof check but it's the best way that I can tell to make sure modded bosses also get included
                    if (Main.hardMode && npc.lifeMax > 10000)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeFruit);
                        }
                    }
                }
            }
        }
	}
}
