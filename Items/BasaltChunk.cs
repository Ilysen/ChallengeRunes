using Terraria;
using Terraria.ModLoader;

namespace ChallengeRunes.Items
{
	public class BasaltChunk : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Basalt Chunk");
            Tooltip.SetDefault("Dropped from challenge rune kills\nKeep as a trophy, or sell for profit");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.rare = 1;
            item.maxStack = 99;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }
    }
}
