using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    struct Magic
    {
        public static int ID;
        public string magicName;
        public int damage;
        public bool isRestore;
        public int cost;
        public int getID()
        {
            int currentID = ID;
            ID++;
            return currentID;
        }
        public void initialise(string newMagicName, int newDamage, bool newIsRestore, int newCost)
        {
            magicName = newMagicName;
            damage = newDamage;
            isRestore = newIsRestore;
            cost = newCost;
        }
    }
    class Battle
    {
        //Consts
        int MAXMAGICCOST = 10;
        static int WINNINGSCORE = 250;
        //Vars
        string[] hFlavourText = { "You smash {0} over the head for a whopping {1} damage!", "You throw your weapon at {0}, stabbing them in the shin for {1} damage", "You launch yourself at {0}, kicking and screaming for {1} damage", "You drop your sword on {0} by accident, for {1} damage", "You used flail, it's super effective! You hit {0} for {1} damage", "You shout at {0} with all the force a man in his fifties can offer. You do {1} damage", "You wink slyly at {0}, doing {1} damage", "You use POCKET SAND. It does {1} damage", "You swing lazily at {0} doing {1} damage" };
        string[] mFlavourText = { "{0} hits you for {1}", "{0} smacks you over the head for {1} damage", "{0} throws a rock at your head doing {1} damage", "{0} jajajajajajaajjajajajaja {1}", "{0} used harden, it's super effective! You take {1} damage" };
        string[] dFlavourText = { "You defend against {0}, making his damage {1}", "You block {0}, negating his damage, making it {1}", "6" };
        string[] magic = { "A box of dicks", "Summon Nikki Minaj", "Digital skeleton key", "Literally taking a shit", "MAGIC MITHILE", "Tommy Wiseau's cheep in E minor", "The current state of the American economy", "The entire continent of Africa", "Johnny English's mother", "The mole", "The cosmological constant" };
        string[] restoreMagic = { "A full english breakfast", "Drinking your own piss", "Nicolas Cage's face", "A box of 20 chicken nuggets", "The brown note" };
        Item loot = ItemsList.getNewItem();
        //define magics
        Magic magic1 = new Magic();
        Magic magic2 = new Magic();
        Magic magic3 = new Magic();
        public Battle(Hero h, Monster m)
        {
            //make a copy of the health values for the hero and monster
            int hCurrentHealth = h.health;
            int hCurrentMana = h.mana;
            int mCurrentHealth = m.health;
            //count the number of times the battle loop has occurred
            int battleIteration = 0;
            Random rng = new Random();
            //Code
            while (h.isAlive && m.isAlive)
            {
                if (battleIteration == 0)
                {
                    Console.WriteLine("You were attacked by {0}!", m.friendlyName);
                }
                Console.WriteLine(
@"*****************************************
   You:
        Health:{0}  Damage:{1}
        Mana:{2}    Defence:{3}
   {4}:
        Health:{5}  Damage:{6}
        Defence:{7}
*****************************************"
, hCurrentHealth, h.damage, hCurrentMana, h.defence, m.friendlyName, mCurrentHealth, m.damage, m.defence);
                Console.WriteLine("What do you wish to do? \n(A)ttack, (M)agic, (D)efend");
                string userInput = Console.ReadLine();
                int heroDamage = rng.Next(0, h.damage) - (m.defence)/3;
                int monsterDamage = rng.Next(0, m.damage) - (h.defence)/3;
                if (heroDamage <= 0) heroDamage = 0;
                if (monsterDamage <= 0) monsterDamage = 0;
                switch (userInput.ToLower())
                {
                    case "a":
                        Console.WriteLine(hFlavourText[rng.Next(0, hFlavourText.Count())], m.friendlyName, heroDamage);
                        //TODO: add damage taken/given, and introduce mana/magic system
                        mCurrentHealth -= heroDamage;
                        Console.WriteLine(mFlavourText[rng.Next(0, mFlavourText.Count())], m.friendlyName, monsterDamage);
                        hCurrentHealth -= monsterDamage;
                        break;
                    case "m":
                        magic1.initialise(magic[rng.Next(0, magic.Count())], rng.Next(0, hCurrentMana), true, rng.Next(0, MAXMAGICCOST));
                        magic2.initialise(magic[rng.Next(0, magic.Count())], rng.Next(0, hCurrentMana), false, rng.Next(0, MAXMAGICCOST));
                        magic3.initialise(magic[rng.Next(0, magic.Count())], rng.Next(0, hCurrentMana), false, rng.Next(0, MAXMAGICCOST));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(
@"*****************************************
    Your Spells:
    {0}     Cost: {1}   Heals:  {2}
    {3}     Cost: {4}   Damage: {5}
    {6}     Cost: {7}   Damage: {8}
*****************************************
"
    , magic1.magicName, magic1.cost, magic1.damage,
     magic2.magicName, magic2.cost, magic2.damage,
     magic3.magicName, magic3.cost, magic3.damage);
                        Console.WriteLine("Which would you like to use?(1/2/3)");
                        Console.ResetColor();
                        string userMagicInput = Console.ReadLine();
                        switch (userMagicInput)
                        {
                            case "1":
                                if (hCurrentMana < magic1.cost)
                                {
                                    Console.WriteLine("You don't have enough Mana");
                                    Console.WriteLine("Your magic fizzles out, and the monster hits you for {0}", monsterDamage);
                                    hCurrentHealth -= monsterDamage;
                                    break;
                                }
                                Console.WriteLine("You used {0}, You feel invigorated, and gain {1}", magic1.magicName, magic1.damage);
                                hCurrentMana -= magic1.cost;
                                hCurrentHealth += magic1.damage;
                                hCurrentHealth -= monsterDamage;
                                break;

                            case "2":
                                if (hCurrentMana < magic2.cost)
                                {
                                    Console.WriteLine("You don't have enough Mana");
                                    Console.WriteLine("Your magic fizzles out, and the monster hits you for {0}", monsterDamage);
                                    hCurrentHealth -= monsterDamage;
                                    break;
                                }
                                Console.WriteLine("You used {0}, It's super effective! You do {1} damage", magic2.magicName, magic2.damage);
                                hCurrentMana -= magic2.cost;
                                mCurrentHealth -= magic2.damage;
                                hCurrentHealth -= monsterDamage;
                                break;
                            case "3":
                                if (hCurrentMana < magic3.cost)
                                {
                                    Console.WriteLine("You don't have enough Mana");
                                    Console.WriteLine("Your magic fizzles out, and the monster hits you for {0}", monsterDamage);
                                    hCurrentHealth -= monsterDamage;
                                    break;
                                }
                                Console.WriteLine("You used {0}, It's super effective! You do {1} damage", magic3.magicName, magic3.damage);
                                hCurrentMana -= magic3.cost;
                                mCurrentHealth -= magic3.damage;
                                hCurrentHealth -= monsterDamage;
                                break;
                            default:
                                Console.WriteLine("Your magic fizzles out, and the monster hits you for {0}", monsterDamage);
                                hCurrentHealth -= monsterDamage;
                                break;
                        }
                        Console.WriteLine(mFlavourText[rng.Next(0, mFlavourText.Count())], m.friendlyName, monsterDamage);
                        break;
                    case "d":
                        monsterDamage -= h.defence;
                        if (monsterDamage <= 0) monsterDamage = 0;
                        Console.WriteLine(dFlavourText[rng.Next(0, dFlavourText.Count())], m.friendlyName, monsterDamage);

                        hCurrentHealth -= monsterDamage;
                        break;

                    default:
                        Console.WriteLine("You fumble with your weapon, and the monster hits you for {0}", monsterDamage);
                        hCurrentHealth -= monsterDamage;
                        break;
                }
                //check for deaths
                Game.addScore(battleIteration * 10);
                if (hCurrentHealth <= 0)
                {
                    Console.WriteLine("Oh no, You died.");
                    h.isAlive = false;
                }
                else if (mCurrentHealth <= 0)
                {
                    m.isAlive = false;
                    Game.addScore(WINNINGSCORE);
                }

                battleIteration++;
                if (Program.DEBUGENABLED)
                {
                    Console.WriteLine("Battle iteration at {0}", battleIteration);
                    break;
                }
            }
            //bool checking if loot is misc
            bool isMisc = (loot.type == "misc");
            //congratulatory message
            if (h.isAlive)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Congratulations on defeating {0}!", m.friendlyName);
                h.levelUp();
                Console.WriteLine("You are now level {0}", Hero.level);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You found {0}!", loot.friendlyName);
                Console.ResetColor();
                Console.WriteLine(getStats(loot));
                Console.WriteLine("Do you want to swap it out for");
                switch (loot.type)
                {
                    case "head":
                        Console.WriteLine(getStats(h.head));
                        break;
                    case "body":
                        Console.WriteLine(getStats(h.body));
                        break;
                    case "legs":
                        Console.WriteLine(getStats(h.legs));
                        break;
                    case "feet":
                        Console.WriteLine(getStats(h.feet));
                        break;
                    default:
                        Console.WriteLine("You got a misc item, and automatically add it to your inventory.");
                        h.addItem(loot);
                        //Console.WriteLine(getStats(loot));
                        break;
                }
                if (!isMisc)
                {
                    Console.WriteLine("Would you like to replace your current item? (Y/N)");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        h.addItem(loot);
                    }
                }
                Console.WriteLine("Your current stats are:");
                Console.WriteLine(h.getStats());
            }
        }
        protected string getStats(Item i)
        {
            //vars
            string returnItem =
@"******************************
    Name: " + i.friendlyName + @"    Goes on: " + i.type + @"
    Modifiers:
    H: " + i.healthMod + @"  Dm: " + i.damageMod + @"
    M: " + i.manaMod + @"   Df: " + i.defenceMod + @"
******************************";
            //methods
            return returnItem;
        }
    }
}
