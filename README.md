# Challenge Runes 
Challenge Runes borrows the challenge items from Calamity and separates them into their own mod. These items can be used to increase the challenge of certain parts of the game, while offering increased rewards.

I don't claim originality for the Armageddon and Defiled runes - they are directly referencing Calamity and have very similar effects. I wanted to adapt these ideas into a standalone mod so that they could be used in normal Terraria and other content mods, too.

(note to MountainDrew, creator of Calamity and original conceptualizer of Armageddon and Defiled - I kept the names so that people would be able to switch between the two and understand what the runes do. If this bothers you, leave an issue report on this repo and I'll change them no questions asked.)

* **Armageddon Rune** - While a boss is alive, taking any damage will instantly kill you. Upon beating a boss, however, it will drop 5 treasure bags, or 6 in Expert Mode.
* **Defiled Rune** - All damage inflicted by monsters is doubled. Enemies drop twice as much money.
* **Frozen Rune** - You deal half damage with all weapons. Mana costs are halved. Enemies drop 50% more money.
* **Scorched Rune** - All life regeneration is disabled. Enemies drop additional hearts, and bosses drop life crystals and mana crystals. Hardmode bosses drop life fruits (in Hardmode only, of course.)

The Apocalypse Sigil enables all four of these runes at once, and grants normal enemies a 1% chance to drop a Basalt Chunk that sells for 1 gold. Bosses will always drop two chunks on death. In Armageddon, bosses also drop one chunk, regardless of if Apocalypse is active.

All runes and sigils can be crafted at a demon altar for no cost.

# Changelog

### Aug. 17, 2019

#### 1.0.1

* Complete refactor of backend code. It should now be much more stable, and function well in multiplayer.
* Removed the apocalypse sigil. Todo: readd at a later date?

### Aug. 15, 2019

#### 1.0.0.5

* Fixed the Scorched rune having improper colors.
* Removed the Scorched rune making every enemy drop hearts, since it arguably trivialized a lot of things and inarguably trivialized a few more.

#### 1.0.0.4

* Improvements to multiplayer use.
* While using a rune, you will emit faint particle effects in the color of that rune.
* Removed basalt chunks and replaced all instances of them with gold coins.

### Aug. 7, 2019

#### 1.0.0.3

* Slight code improvements.
* During Scorched, enemies only drop one heart, instead of 2-3.
* Frozen now also reduces mana costs by half.

### Jul. 31, 2019

#### 1.0.0.2

* Initial commit. Includes Armageddon, Defiled, Frozen, and Scorched runes, plus the Apocalypse Sigil for activating them all.