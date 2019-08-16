using Microsoft.Xna.Framework;
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
            if (ChallengeRunes.IsChallenger(player))
            {
                ChallengeRunes crMod = (ChallengeRunes)mod;
                bool armageddon = crMod.Armageddon(true);
                bool defiled = crMod.Defiled(true);
                if (armageddon)
                {
                    foreach (NPC npc in Main.npc)
                    {
                        if (npc.boss && npc.active)
                        {
                            PlayerDeathReason armageddonDeath = PlayerDeathReason.ByCustomReason(player.name + " didn't survive Armageddon.");
                            Main.PlaySound(SoundID.NPCDeath59.WithVolume(0.5f), player.Center);
                            player.KillMe(armageddonDeath, 1.0, 0, false);
                        }
                    }
                }
                if (defiled && damageSource.SourceNPCIndex > 0)
                {
                    damage *= 2;
                }
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void PostUpdateBuffs()
        {
            if (ChallengeRunes.IsChallenger(player))
            {
                ChallengeRunes crMod = (ChallengeRunes)mod;
                if (crMod.Frozen(true))
                {
                    player.allDamageMult *= 0.5f;
                }
                if (crMod.Scorched(true))
                {
                    player.lifeRegen = 0;
                    player.lifeRegenCount = 0;
                    player.lifeRegenTime = 0;
                }
                EmitDusts(crMod);
            }
        }

        public void EmitDusts(ChallengeRunes crMod)
        {
            if (crMod.Armageddon(true))
            {
                if (Main.rand.Next(0, 15) == 0)
                {
                    Dust.NewDust(player.Center, 5, 5, 264, -0.5f, 0, 0, new Color(255, 0, 255), 1f);
                }
            }
            if (crMod.Defiled(true))
            {
                if (Main.rand.Next(0, 15) == 0)
                {
                    Dust.NewDust(player.Center, 5, 5, 264, -0.25f, 0, 0, new Color(0, 255, 0), 1f);
                }
            }
            if (crMod.Frozen(true))
            {
                if (Main.rand.Next(0, 15) == 0)
                {
                    Dust.NewDust(player.Center, 5, 5, 264, 0.25f, 0, 0, new Color(135, 245, 255), 1f);
                }
            }
            if (crMod.Scorched(true))
            {
                if (Main.rand.Next(0, 15) == 0)
                {
                    Dust.NewDust(player.Center, 5, 5, 264, 0.5f, 0, 0, new Color(255, 150, 55), 1f);
                }
            }
        }
    }
}