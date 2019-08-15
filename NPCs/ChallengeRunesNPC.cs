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
            if (!ChallengeRunes.IsChallenger(Main.LocalPlayer))
            {
                return;
            }
            ChallengeRunes crMod = (ChallengeRunes)mod;
            bool armageddon = crMod.Armageddon(true);
            bool defiled = crMod.Defiled(true);
            bool frozen = crMod.Frozen(true);
            bool scorched = crMod.Scorched(true);
            bool apocalypse = crMod.Apocalypse(true);
            if (armageddon && npc.boss)
            {
                Main.PlaySound(SoundID.NPCDeath60.WithVolume(0.5f), npc.Center);
                for (int i = 0; i < 5; i++)
                {
                    npc.DropBossBags(); // Armageddon drops five additional bags
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin);
            }
            else if(defiled)
            {
                npc.value *= 2;
                if(npc.boss)
                {
                    npc.DropBossBags(); // Defiled yields one additional bag
                }
            }
            if(frozen)
            {
                npc.value *= 1.5f;
            }
            if (!npc.friendly)
            {
                if (scorched)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Heart);
                    if (npc.boss)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeCrystal);
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ManaCrystal);
                        }
                        if (Main.hardMode && npc.lifeMax > 10000)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeFruit);
                            }
                        }
                    }
                }
                if (apocalypse)
                {
                    if (Main.rand.Next(100) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin);
                    }
                    else if (npc.boss)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin);
                        }
                    }
                }
            }
        }
	}
}
