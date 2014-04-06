using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    abstract class Creature
    {
        //defines the basic integers required in both Hero and Monster classes
        protected int _health, _damage, _mana, _defence;
        public string friendlyName;
        public bool isAlive;
    }
    class Monster : Creature
    {
        //Vars
        Random seed = new Random();
        Hashtable monsterNames = new Hashtable();
        string randomName
        {
            get 
            {
                int i = seed.Next(0, monsterNames.Count);
                return monsterNames[i] as string;
            }
            set { }
        }
        int randomHealth
        {
            get 
            {
                int result;
                switch(Hero.level)
                {
                    case 0:
                    case 1:
                    case 2:
                        result = seed.Next(1, 20);
                        return result;
                    case 3:
                        result = seed.Next(15, 40);
                        return result;
                    case 4:
                        result = seed.Next(35, 60);
                        return result;
                    case 5:
                        result = seed.Next(55, 80);
                        return result;
                    default:
                        result = seed.Next(1, 100);
                        return result;
                }
            }
            set { }
        }
        int randomDamage
        {
            get
            {
                int result;
                switch (Hero.level)
                {
                    case 0:
                    case 1:
                    case 2:
                        result = seed.Next(1, 20);
                        return result;
                    case 3:
                        result = seed.Next(15, 40);
                        return result;
                    case 4:
                        result = seed.Next(35, 60);
                        return result;
                    case 5:
                        result = seed.Next(55, 80);
                        return result;
                    default:
                        result = seed.Next(1, 100);
                        return result;
                }
            }
            set { }
        }
        int randomDefence
        {
            get
            {
                int result;
                switch (Hero.level)
                {
                    case 0:
                    case 1:
                    case 2:
                        result = seed.Next(1, 20);
                        return result;
                    case 3:
                        result = seed.Next(15, 40);
                        return result;
                    case 4:
                        result = seed.Next(35, 60);
                        return result;
                    case 5:
                        result = seed.Next(55, 80);
                        return result;
                    default:
                        result = seed.Next(1, 100);
                        return result;
                }
            }
            set { }
        }
        public int health
        {
            get { return _health; }
        }
        public int damage
        {
            get { return _damage; }
        }
        public int defence
        {
            get { return _defence; }
        }
        //Methods
        private void initialiseNames()
        {
            //add all of the monster names to the HashTable (mainly as a test if I can use hashtables)
            monsterNames.Add(0, "Dan the Man");
            monsterNames.Add(1, "The Newms of Doom");
            monsterNames.Add(2, "McNuggetly");
            monsterNames.Add(3, "Grue");
            monsterNames.Add(4, "Bollow?");
            monsterNames.Add(5, "A Giant Phallus");
            monsterNames.Add(6, "Your Own Penis");
            monsterNames.Add(7, "Jimmy Saville");
            monsterNames.Add(8, "Colin");
            monsterNames.Add(9, "The Elephant Man");
            monsterNames.Add(10, "Dax the Ax");
            monsterNames.Add(11, "Primordial Sludge");
            monsterNames.Add(12, "Greg Wallace");
            monsterNames.Add(13, "A Fat Man");
            monsterNames.Add(14, "16 Military Wives");
            monsterNames.Add(15, "The VViiU");
            monsterNames.Add(16, "Daniel Beddingfield");
            monsterNames.Add(17, "Hugh Mannittee");
            monsterNames.Add(18, "The Anti-Wallace");
        }
        public void initialise()
        {
            //create the monster
            isAlive = true;
            _health = randomHealth;
            _damage = randomDamage;
            _defence = randomDefence;
            if(monsterNames.Count == 0)
            {
                initialiseNames();
            }
            friendlyName = randomName;
        }
        public Monster()
        {
        }
    }
    class Hero : Creature
    {
        //vars
        public static int level;
        private int maxHealth = 100, maxDamage = 100, maxMana = 100, maxDefence = 100;
        public int[] modifiers = { 0, 0, 0, 0 };
        public ArrayList backpack = new ArrayList();
        public Item head, body, legs, feet;
        private static Item emptyItem = new Item();
        //modifiers, 
        //[0] = health
        //[1] = damage
        //[2] = mana
        //[3] = defence

        //declare get/sets for the various player stats
        public int health
        {
            get
            {
                int retValue = _health + modifiers[0];
                if (retValue > maxHealth)
                {
                    return maxHealth;
                }
                return retValue;
            }
            set
            {
                _health = value;
            }
        }
        public int damage
        {
            get
            {
                int retValue = _damage + modifiers[1];
                if (retValue > maxDamage)
                {
                    return maxDamage;
                }
                return retValue;
            }
            set
            {
                _damage = value;
            }
        }
        public int mana
        {
            get
            {
                int retValue = _mana + modifiers[2];
                if (retValue > maxMana)
                {
                    return maxMana;
                }
                return retValue;
            }
            set
            {
                _mana = value;
            }
        }
        public int defence
        {
            get
            {
                int retValue = _defence + modifiers[3];
                if (retValue > maxDefence)
                {
                    return maxDefence;
                }
                return retValue;
            }
            set
            {
                _defence = value;
            }
        }


        //methods
        public void levelUp()
        {
            level++;
        }
        public void levelUp(int l)
        {
            level += l;
        }
        public void addItem(Item newItem)
        {
            //when an item is acquired, check where it should go
            switch (newItem.type)
            {
                case "head":
                    head = newItem;
                    break;
                case "body":
                    body = newItem;
                    break;
                case "legs":
                    legs = newItem;
                    break;
                case "feet":
                    feet = newItem;
                    break;
                default:
                    backpack.Add(newItem);
                    if (backpack.Contains(emptyItem))
                    {
                        backpack.Remove(emptyItem);
                    }
                    break;
            }
            //update the modifier array
            modifiersUpdate();
        }
        private void modifiersUpdate()
        {
            //initialise (or reinitialise) temporary integers
            int backpackHealthMods = 0, backpackDamageMods = 0, backpackManaMods = 0, backpackDefenceMods = 0;
            //add up the mods in the backpack currently
            foreach (Item i in backpack)
            {
                backpackHealthMods += i.healthMod;
                backpackDamageMods += i.damageMod;
                backpackManaMods += i.manaMod;
                backpackDefenceMods += i.defenceMod;
            }

            //sum up the modifiers across all of the items currently on the player
            int currentHealthModifiers = head.healthMod + body.healthMod + legs.healthMod + feet.healthMod + backpackHealthMods;
            int currentDamageModifiers = head.damageMod + body.damageMod + legs.damageMod + feet.damageMod + backpackDamageMods;
            int currentManaModifiers = head.manaMod + body.manaMod + legs.manaMod + feet.manaMod + backpackManaMods;
            int currentDefenceModifiers = head.defenceMod + body.defenceMod + legs.defenceMod + feet.defenceMod + backpackDefenceMods;

            //set the modifiers equal to the temporary integers
            modifiers[0] = currentHealthModifiers;
            modifiers[1] = currentDamageModifiers;
            modifiers[2] = currentManaModifiers;
            modifiers[3] = currentDefenceModifiers;
        }
        public void initialise(string name)
        {
            //vars
            isAlive = true;
            health = 20;
            damage = 10;
            mana = 10;
            defence = 5;
            emptyItem.initialise(0000, "Empty", "", 0, 0, 0, 0);
            level = 0;

            //logical vars
            friendlyName = name;
            head = emptyItem;
            body = emptyItem;
            legs = emptyItem;
            feet = emptyItem;
            addItem(emptyItem);
        }
        public string getStats()
        {
            string stats = 
@"*****************************************
    You:
        Health:" + this.health + @"    Damage:" + this.damage + @"
        Mana:" + this.mana + @"    Defence:" + this.defence + @"
*****************************************";
            return stats;
        }
        public Hero()
        {
        }
    }
}
