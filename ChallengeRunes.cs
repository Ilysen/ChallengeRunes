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