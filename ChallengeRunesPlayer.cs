using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes
{
	public class ChallengeRunesPlayer : ModPlayer
	{
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            ChallengeRunes crMod = (ChallengeRunes)mod;
            bool armageddon = crMod.Armageddon(true);
            bool defiled = crMod.Defiled(true);
            if(armageddon)
            {
                foreach(NPC npc in Main.npc)
                {
                    if(npc.boss && npc.active)
                    {
                        PlayerDeathReason armageddonDeath = PlayerDeathReason.ByCustomReason(player.name + " didn't survive Armageddon.");
                        Main.PlaySound(SoundID.NPCDeath59.WithVolume(0.5f), player.Center);
                        player.KillMe(armageddonDeath, 1.0, 0, false);
                    }
                }
            }
            if(defiled && damageSource.SourceNPCIndex > 0)
            {
                damage *= 2;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void PostUpdateBuffs()
        {
            ChallengeRunes crMod = (ChallengeRunes)mod;
            if (crMod.Frozen(true))
            {
                player.allDamageMult *= 0.5f;
                player.manaCost *= 0.5f;
            }
            if(crMod.Scorched(true))
            {
                player.lifeRegen = 0;
                player.lifeRegenCount = 0;
                player.lifeRegenTime = 0;
            }
        }
    }
}