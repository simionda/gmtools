using System;
using System.Collections.Generic;
using System.Text;

namespace gmtools.items
{
    public class StaticItemRepository : IItemRepository
    {
        public IEnumerable<GameItem> ItemList()
        {
            var result = new List<GameItem>();

            //Armor::Light Armor
            result.Add(new GameItem("Padded", LightArmor, 3, "5gp"));
            result.Add(new GameItem("Leather", LightArmor, 3, "10gp"));
            result.Add(new GameItem("Studded Leather", LightArmor, 1, "45gp"));

            //Armor::Medium Armor
            result.Add(new GameItem("Hide", MediumArmor, 3, "10gp"));
            result.Add(new GameItem("Chain shirt", MediumArmor, 1, "50gp"));
            result.Add(new GameItem("Scale mail", MediumArmor, 1, "50gp"));
            result.Add(new GameItem("Breastplate", MediumArmor, 1, "400gp"));
            result.Add(new GameItem("Half Plate", MediumArmor, 1, "750gp"));

            //Armor::Heavy Armor
            result.Add(new GameItem("Ring mail", HeavyArmor, 1, "30gp"));
            result.Add(new GameItem("Chain mail", HeavyArmor, 1, "75gp"));
            result.Add(new GameItem("Splint", HeavyArmor, 1, "200gp"));
            result.Add(new GameItem("Plate", HeavyArmor, 1, "1500gp"));

            //Armor::Shield
            result.Add(new GameItem("Shield", Armor, 5, "10gp"));

            //Weapon::Simple Melee
            result.Add(new GameItem("Club", SimpleMeleeWeapon, 5, "1sp"));
            result.Add(new GameItem("Dagger", SimpleMeleeWeapon, 5, "2gp"));
            result.Add(new GameItem("Greatclub", SimpleMeleeWeapon, 5, "2sp"));
            result.Add(new GameItem("Handaxe", SimpleMeleeWeapon, 5, "5gp"));
            result.Add(new GameItem("Javelin", SimpleMeleeWeapon, 5, "5sp"));
            result.Add(new GameItem("Light hammer", SimpleMeleeWeapon, 5, "2gp"));
            result.Add(new GameItem("Mace", SimpleMeleeWeapon, 5, "5gp"));
            result.Add(new GameItem("Quarterstaff", SimpleMeleeWeapon, 5, "2sp"));
            result.Add(new GameItem("Sickle", SimpleMeleeWeapon, 5, "1gp"));
            result.Add(new GameItem("Spear", SimpleMeleeWeapon, 5, "1gp"));

            //Weapon::Simple Ranged
            result.Add(new GameItem("Crossbow, light", SimpleRangedWeapon, 5, "25gp"));
            result.Add(new GameItem("Dart", SimpleRangedWeapon, 5, "5cp"));
            result.Add(new GameItem("Shortbow", SimpleRangedWeapon, 5, "25gp"));
            result.Add(new GameItem("Sling", SimpleRangedWeapon, 5, "1sp"));

            //Weapon::Martial Melee
            result.Add(new GameItem("Battleaxe", MartialMeleeWeapon, 3, "10gp"));
            result.Add(new GameItem("Flail", MartialMeleeWeapon, 3, "10gp"));
            result.Add(new GameItem("Glaive", MartialMeleeWeapon, 3, "20gp"));
            result.Add(new GameItem("Greataxe", MartialMeleeWeapon, 3, "30gp"));
            result.Add(new GameItem("Greatsword", MartialMeleeWeapon, 3, "50gp"));
            result.Add(new GameItem("Halberd", MartialMeleeWeapon, 3, "20gp"));
            result.Add(new GameItem("Lance", MartialMeleeWeapon, 3, "10gp"));
            result.Add(new GameItem("Longsword", MartialMeleeWeapon, 3, "15gp"));
            result.Add(new GameItem("Maul", MartialMeleeWeapon, 3, "10gp"));
            result.Add(new GameItem("Morningstar", MartialMeleeWeapon, 3, "15gp"));
            result.Add(new GameItem("Pike", MartialMeleeWeapon, 3, "5gp"));
            result.Add(new GameItem("Rapier", MartialMeleeWeapon, 3, "25gp"));
            result.Add(new GameItem("Scimitar", MartialMeleeWeapon, 3, "25gp"));
            result.Add(new GameItem("Shortsword", MartialMeleeWeapon, 3, "10gp"));
            result.Add(new GameItem("Trident", MartialMeleeWeapon, 3, "5gp"));
            result.Add(new GameItem("War pick", MartialMeleeWeapon, 3, "5gp"));
            result.Add(new GameItem("Warhammer", MartialMeleeWeapon, 3, "15gp"));
            result.Add(new GameItem("Whip", MartialMeleeWeapon, 3, "2gp"));

            //Weapon::Martial Ranged
            result.Add(new GameItem("Blowgun", MartialRangedWeapon, 3, "10gp"));
            result.Add(new GameItem("Crossbow, hand", MartialRangedWeapon, 3, "75gp"));
            result.Add(new GameItem("Crossbow, heavy", MartialRangedWeapon, 3, "50gp"));
            result.Add(new GameItem("Longbow", MartialRangedWeapon, 3, "50gp"));
            result.Add(new GameItem("Net", MartialRangedWeapon, 3, "1gp"));

            //Adventuring Gear::Ammunition
            result.Add(new GameItem("Arrows (20)", AmmunitionAdventuringGear, 10, "1gp"));
            result.Add(new GameItem("Blowgun needles (50)", AmmunitionAdventuringGear, 10, "1gp"));
            result.Add(new GameItem("Crossbow bolts (20)", AmmunitionAdventuringGear, 10, "1gp"));
            result.Add(new GameItem("Sling bullets (20)", AmmunitionAdventuringGear, 10, "4sp"));

            //Adventuring Gear::Arcane Focus
            result.Add(new GameItem("Crystal", ArcaneFocusAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Orb", ArcaneFocusAdventuringGear, 1, "20gp"));
            result.Add(new GameItem("Rod", ArcaneFocusAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Staff", ArcaneFocusAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Wand", ArcaneFocusAdventuringGear, 1, "10gp"));

            //Adventuring Gear::Druidic Focus
            result.Add(new GameItem("Sprig of mistletoe", DruidicFocusAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Totem", DruidicFocusAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Wooden staff", DruidicFocusAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Yew wand", DruidicFocusAdventuringGear, 1, "10gp"));

            //Adventuring Gear::Holy Symbol
            result.Add(new GameItem("Amulet", HolySymbolAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Emblem", HolySymbolAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Reliquary", HolySymbolAdventuringGear, 1, "5gp"));

            //Adventuring Gear::Other
            result.Add(new GameItem("Abacus", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Acid (vial)", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Alchemist's fire (flask)", OtherAdventuringGear, 1, "50gp"));
            result.Add(new GameItem("Antitoxin (vial)", OtherAdventuringGear, 1, "50gp"));
            result.Add(new GameItem("Backpack", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Ball bearings (bag of 1,000)", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Barrel", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Basket", OtherAdventuringGear, 1, "4sp"));
            result.Add(new GameItem("Bedroll", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Bell", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Blanket", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Block and tackle", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Book", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Bottle, glass", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Bucket", OtherAdventuringGear, 1, "5cp"));
            result.Add(new GameItem("Caltrops (bag of 20)", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Candle", OtherAdventuringGear, 1, "1cp"));
            result.Add(new GameItem("Case, crossbow bolt", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Case, map or scroll", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Chain (10 feet)", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Chalk (1 piece)", OtherAdventuringGear, 1, "1cp"));
            result.Add(new GameItem("Chest", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Climber's kit", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Clothes, common", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Clothes, costume", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Clothes, fine", OtherAdventuringGear, 1, "15gp"));
            result.Add(new GameItem("Clothes, traveler's", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Component pouch", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Crowbar", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Fishing tackle", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Flask or tankard", OtherAdventuringGear, 1, "2cp"));
            result.Add(new GameItem("Grappling hook", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Hammer", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Hammer, sledge", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Healer's kit", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Holy water (flask)", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Hourglass", OtherAdventuringGear, 1, "25gp"));
            result.Add(new GameItem("Hunting trap", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Ink (1oz bottle)", OtherAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Ink pen", OtherAdventuringGear, 1, "2cp"));
            result.Add(new GameItem("Jug or pitcher", OtherAdventuringGear, 1, "2cp"));
            result.Add(new GameItem("Ladder (10ft)", OtherAdventuringGear, 1, "1sp"));
            result.Add(new GameItem("Lamp", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Lantern, bullseye", OtherAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Lantern, hooded", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Lock", OtherAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Magnifying glass", OtherAdventuringGear, 1, "100gp"));
            result.Add(new GameItem("Manacles", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Mess kit", OtherAdventuringGear, 1, "2sp"));
            result.Add(new GameItem("Mirror, steel", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Oil (flask)", OtherAdventuringGear, 1, "1sp"));
            result.Add(new GameItem("Paper (one sheet)", OtherAdventuringGear, 1, "2sp"));
            result.Add(new GameItem("Parchment (one sheet)", OtherAdventuringGear, 1, "1sp"));
            result.Add(new GameItem("Perfume (vial)", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Pick, miner's", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Piton", OtherAdventuringGear, 1, "5cp"));
            result.Add(new GameItem("Poison, basic (vial)", OtherAdventuringGear, 1, "100gp"));
            result.Add(new GameItem("Pole (10ft)", OtherAdventuringGear, 1, "5cp"));
            result.Add(new GameItem("Pot, iron", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Potion of healing", OtherAdventuringGear, 1, "50gp"));
            result.Add(new GameItem("Pouch", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Quiver", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Ram, portable", OtherAdventuringGear, 1, "4gp"));
            result.Add(new GameItem("Rations (1 day)", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Robes", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Rope, hempen (50ft)", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Rope, silk (50ft)", OtherAdventuringGear, 1, "10gp"));
            result.Add(new GameItem("Sack", OtherAdventuringGear, 1, "1cp"));
            result.Add(new GameItem("Scale, merchant's", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Sealing wax", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Shovel", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Signal whistle", OtherAdventuringGear, 1, "5cp"));
            result.Add(new GameItem("Signet ring", OtherAdventuringGear, 1, "5gp"));
            result.Add(new GameItem("Soap", OtherAdventuringGear, 1, "2cp"));
            result.Add(new GameItem("Spellbook", OtherAdventuringGear, 1, "50gp"));
            result.Add(new GameItem("Spikes, iron (10)", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Spyglass", OtherAdventuringGear, 1, "1000gp"));
            result.Add(new GameItem("Tent, two-person", OtherAdventuringGear, 1, "2gp"));
            result.Add(new GameItem("Tinderbox", OtherAdventuringGear, 1, "5sp"));
            result.Add(new GameItem("Torch", OtherAdventuringGear, 1, "1cp"));
            result.Add(new GameItem("Vial", OtherAdventuringGear, 1, "1gp"));
            result.Add(new GameItem("Waterskin", OtherAdventuringGear, 1, "2sp"));
            result.Add(new GameItem("Whetstone", OtherAdventuringGear, 1, "1cp"));

            return result;
        }

        private ItemCategory LightArmor = new ItemCategory("Armor", "Light Armor");
        private ItemCategory MediumArmor = new ItemCategory("Armor", "Medium Armor");
        private ItemCategory HeavyArmor = new ItemCategory("Armor", "Heavy Armor");
        private ItemCategory Armor = new ItemCategory("Armor", "");
        private ItemCategory SimpleMeleeWeapon = new ItemCategory("Weapon", "Simple Melee");
        private ItemCategory SimpleRangedWeapon = new ItemCategory("Weapon", "Simple Ranged");
        private ItemCategory MartialMeleeWeapon = new ItemCategory("Weapon", "Martial Melee");
        private ItemCategory MartialRangedWeapon = new ItemCategory("Weapon", "Martial Ranged");
        private ItemCategory AmmunitionAdventuringGear = new ItemCategory("Adventuring Gear", "Ammunition");
        private ItemCategory ArcaneFocusAdventuringGear = new ItemCategory("Adventuring Gear", "Arcane Focus");
        private ItemCategory DruidicFocusAdventuringGear = new ItemCategory("Adventuring Gear", "Druidic Focus");
        private ItemCategory HolySymbolAdventuringGear = new ItemCategory("Adventuring Gear", "Holy Symbol");
        private ItemCategory OtherAdventuringGear = new ItemCategory("Adventuring Gear", "Other");

    }
}
