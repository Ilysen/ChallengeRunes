using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChallengeRunes
{
	public class ChallengeRunes : Mod
	{
		public ChallengeRunes()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public static Dictionary<Player, string> armageddon = new Dictionary<Player, string>();
        public static Dictionary<Player, string> defiled = new Dictionary<Player, string>();
        public static Dictionary<Player, string> frozen = new Dictionary<Player, string>();
        public static Dictionary<Player, string> scorched = new Dictionary<Player, string>();

        public static void NewText(Player player, string text, byte r, byte g, byte b)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Main.NewText(text, r, g, b);
            }
        }

        public static bool AntiCheese(Player player)
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
            return false;
        }

        public static bool CheckRune(Player p, string runeKey)
        {
            switch (runeKey)
            {
                case "armageddon":
                    return armageddon.TryGetValue(p, out _);
                case "defiled":
                    return defiled.TryGetValue(p, out _);
                case "frozen":
                    return frozen.TryGetValue(p, out _);
                case "scorched":
                    return scorched.TryGetValue(p, out _);
            }
            return false;
        }

        public static void SetRune(Player p, string runeKey)
        {
            switch (runeKey)
            {
                case "armageddon":
                    armageddon.Add(p, runeKey);
                    break;
                case "defiled":
                    defiled.Add(p, runeKey);
                    break;
                case "frozen":
                    frozen.Add(p, runeKey);
                    break;
                case "scorched":
                    scorched.Add(p, runeKey);
                    break;
            }
        }

        public static void RemoveRune(Player p, string runeKey)
        {
            switch (runeKey)
            {
                case "armageddon":
                    armageddon.Remove(p);
                    break;
                case "defiled":
                    defiled.Remove(p);
                    break;
                case "frozen":
                    frozen.Remove(p);
                    break;
                case "scorched":
                    scorched.Remove(p);
                    break;
            }
        }
    }
}