using Terraria;
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

        public static void NewText(Player player, string text, byte r, byte g, byte b)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Main.NewText(text, r, g, b);
            }
        }

        public static bool IsChallenger(Player player)
        {
            return player.whoAmI == Main.myPlayer;
        }

        private bool armageddonActive;
        private bool defiledActive;
        private bool frozenActive; // LET IT GOOO
        private bool scorchedActive;

        private bool apocalypse;

        public bool Armageddon(bool checkOnly = false)
        {
            if(!checkOnly)
                armageddonActive = !armageddonActive;
            return armageddonActive;
        }

        public bool Defiled(bool checkOnly = false)
        {
            if (!checkOnly)
                defiledActive = !defiledActive;
            return defiledActive;
        }

        public bool Frozen(bool checkOnly = false)
        {
            if (!checkOnly)
                frozenActive = !frozenActive;
            return frozenActive;
        }

        public bool Scorched(bool checkOnly = false)
        {
            if (!checkOnly)
                scorchedActive = !scorchedActive;
            return scorchedActive;
        }

        public bool Apocalypse(bool checkOnly = false)
        {
            if (!checkOnly)
            {
                apocalypse = !apocalypse;
                armageddonActive = apocalypse;
                defiledActive = apocalypse;
                frozenActive = apocalypse;
                scorchedActive = apocalypse;
            }
            return apocalypse;
        }
    }
}