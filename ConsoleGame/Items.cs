using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class ItemsList
    {
        //Vars
        //a list of item names
        static string[] miscNames = { "Daniel's Nose", "Nicolas Cage Mask", "Jar of Methylamine", "Donald Trump Seal of Approval", "Landmine", "Bootleg Copy of Face-Off", "Mechanics Book", "Bust of Tommy Wiseau", "Box of Baguettes", "Ever Shining Sun" };
        static string[] headNames = { "Ushanka", "Towering Pillar of Hats", "Bald Cap", "Miniature Dog", "Bowl", "Jeremy Clarkson Wig", "Straw Hat", "Leather Hat", "Fedora", "Steel Helmet", "Golden Crown" };
        static string[] bodyNames = { "Imitation Leather Trenchcoat", "T-Shirt", "Fishnet Vest", "Biker Jacket", "Steel Breastplate", "Bra", "Old Woolen Cardigan", "Cardboard Box" };
        static string[] legsNames = { "Pair of Jeans", "Pair of Lederhosen", "Pair of Pyjama Bottoms", "Pair of Leather Chaps", "Pair of Pants", "Steel Legging", "Craffs"};
        static string[] feetNames = { "Pair of Steel Boots", "Pair of Cowboy Boots", "Pair of Rainbow Socks", "Pair of Sandals", "Shoelace"};
        //how many item types (head, body...) there are
        static int NUMBERITEMTYPES = 5;
        //the max modifier the item can have (from 0 to X where X is the variable defined below)
        static int COMMONITEMMAXMOD = 10;
        static int UNCOMMONITEMMAXMOD = 20;
        static int RAREITEMMAXMOD = 50;
        //random number generator
        static Random rng = new Random();
        //ID counter, to keep track of all of the items produced
        private static int IDCounter = 0001;

        //Methods
        public static Item getNewItem()
        {
            //Vars
            int itemTypeSelector = rng.Next(1,NUMBERITEMTYPES);
            int itemRaritySelector = rng.Next(1,10);
            int healthMod;
            int damageMod;
            int manaMod;
            int defenceMod;
            Item returnItem = new Item();

            //Code
            switch (itemRaritySelector)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    //Common
                    healthMod = rng.Next(0,COMMONITEMMAXMOD);
                    damageMod = rng.Next(0,COMMONITEMMAXMOD);
                    manaMod = rng.Next(0,COMMONITEMMAXMOD);
                    defenceMod = rng.Next(0,COMMONITEMMAXMOD);
                    if (Program.DEBUGENABLED) Console.WriteLine("You got a Common Item!");
                    break;
                case 7:
                case 8:
                case 9:
                    //Uncommon
                    healthMod = rng.Next(0,UNCOMMONITEMMAXMOD);
                    damageMod = rng.Next(0,UNCOMMONITEMMAXMOD);
                    manaMod = rng.Next(0,UNCOMMONITEMMAXMOD);
                    defenceMod = rng.Next(0,UNCOMMONITEMMAXMOD);
                    if (Program.DEBUGENABLED) Console.WriteLine("You got an Uncommon Item!");
                    break;
                case 10:
                    //Rare
                    healthMod = rng.Next(0,RAREITEMMAXMOD);
                    damageMod = rng.Next(0,RAREITEMMAXMOD);
                    manaMod = rng.Next(0,RAREITEMMAXMOD);
                    defenceMod = rng.Next(0,RAREITEMMAXMOD);
                    if (Program.DEBUGENABLED) Console.WriteLine("You got a Rare Item!");
                    break;
                default:
                    healthMod = 0;
                    damageMod = 0;
                    manaMod = 0;
                    defenceMod = 0;
                    break;
            }

            switch (itemTypeSelector)
            {
                case 1:
                    int itemNameSelector = rng.Next(0,headNames.Length);
                    returnItem.initialise(IDCounter,headNames[itemNameSelector],"Head",healthMod,damageMod,manaMod,defenceMod);
                    break;

                case 2:
                    itemNameSelector = rng.Next(0,bodyNames.Length);
                    returnItem.initialise(IDCounter,bodyNames[itemNameSelector],"Body",healthMod,damageMod,manaMod,defenceMod);
                    break;

                case 3:
                    itemNameSelector = rng.Next(0,legsNames.Length);
                    returnItem.initialise(IDCounter,legsNames[itemNameSelector],"Legs",healthMod,damageMod,manaMod,defenceMod);
                    break;

                case 4:
                    itemNameSelector = rng.Next(0,feetNames.Length);
                    returnItem.initialise(IDCounter,feetNames[itemNameSelector],"Feet",healthMod,damageMod,manaMod,defenceMod);
                    break;

                default:
                    itemNameSelector = rng.Next(0,miscNames.Length);
                    returnItem.initialise(IDCounter,miscNames[itemNameSelector],"Misc",healthMod,damageMod,manaMod,defenceMod);
                    break;

            }
            //increment the ID counter (static)
            if (Program.DEBUGENABLED) Console.WriteLine("ID for random item generator is currently: {0}", IDCounter);
            IDCounter++;
            return returnItem;
        }


        //public static Hashtable commonItems = new Hashtable();
        //public static Hashtable uncommonItems = new Hashtable();
        //public static Hashtable rareItems = new Hashtable();
        //public ItemsList()
        //{
        //    //create items
            
        //    //Common
        //    Item _0001 = new Item();
        //    Item _0002 = new Item();
        //    Item _0003 = new Item();
        //    Item _0004 = new Item();
        //    Item _0005 = new Item();
        //    Item _0006 = new Item();
        //    Item _0007 = new Item();
        //    Item _0008 = new Item();
        //    Item _0009 = new Item();
        //    Item _0010 = new Item();
        //    Item _0011 = new Item();
        //    Item _0012 = new Item();
        //    Item _0013 = new Item();
        //    Item _0014 = new Item();
        //    Item _0015 = new Item();
        //    Item _0016 = new Item();
        //    Item _0017 = new Item();
        //    Item _0018 = new Item();
        //    Item _0019 = new Item();
        //    Item _0020 = new Item();

        //    //Uncommon

        //    Item _0101 = new Item();
        //    Item _0102 = new Item();
        //    Item _0103 = new Item();
        //    Item _0104 = new Item();
        //    Item _0105 = new Item();
        //    Item _0106 = new Item();
        //    Item _0107 = new Item();
        //    Item _0108 = new Item();
        //    Item _0109 = new Item();
        //    Item _0110 = new Item();
        //    //Rare

        //    Item _0201 = new Item();
        //    Item _0202 = new Item();
        //    Item _0203 = new Item();
        //    Item _0204 = new Item();
        //    Item _0205 = new Item();

        //    //Common
        //    _0001.initialise(0001, "", "", 1, 1, 0, 0);
        //    _0002.initialise(0002, "", "", 1, 2, 0, 0);
        //    _0003.initialise(0003, "", "", 0, 0, 5, 0);
        //    _0004.initialise(0004, "", "", 9, 1, 0, 2);
        //    _0005.initialise(0005, "", "", 1, 1, 0, 0);
        //    _0006.initialise(0006, "", "", 1, 1, 0, 0);
        //    _0007.initialise(0007, "", "", 1, 1, 0, 0);
        //    _0008.initialise(0008, "", "", 1, 1, 0, 0);
        //    _0009.initialise(0009, "", "", 1, 1, 0, 0);
        //    _0010.initialise(0010, "", "", 1, 1, 0, 0);
        //    _0011.initialise(0011, "", "", 1, 1, 0, 0);
        //    _0012.initialise(0012, "", "", 1, 1, 0, 0);
        //    _0013.initialise(0013, "", "", 1, 1, 0, 0);
        //    _0014.initialise(0014, "", "", 1, 1, 0, 0);
        //    _0015.initialise(0015, "", "", 1, 1, 0, 0);
        //    _0016.initialise(0016, "", "", 1, 1, 0, 0);
        //    _0017.initialise(0017, "", "", 1, 1, 0, 0);
        //    _0018.initialise(0018, "", "", 1, 1, 0, 0);
        //    _0019.initialise(0019, "", "", 1, 1, 0, 0);
        //    _0020.initialise(0020, "", "", 1, 1, 0, 0);

        //    //Uncommon
        //    _0101.initialise(0101, "", "", 1, 1, 0, 0);
        //    _0102.initialise(0102, "", "", 1, 1, 0, 0);
        //    _0103.initialise(0103, "", "", 1, 1, 0, 0);
        //    _0104.initialise(0104, "", "", 1, 1, 0, 0);
        //    _0105.initialise(0105, "", "", 1, 1, 0, 0);
        //    _0106.initialise(0106, "", "", 1, 1, 0, 0);
        //    _0107.initialise(0107, "", "", 1, 1, 0, 0);
        //    _0108.initialise(0108, "", "", 1, 1, 0, 0);
        //    _0109.initialise(0109, "", "", 1, 1, 0, 0);
        //    _0110.initialise(0110, "", "", 1, 1, 0, 0);

        //    //Rare

        //    _0201.initialise(0201, "", "", 1, 1, 0, 0);
        //    _0202.initialise(0202, "", "", 1, 1, 0, 0);
        //    _0203.initialise(0203, "", "", 1, 1, 0, 0);
        //    _0204.initialise(0204, "", "", 1, 1, 0, 0);
        //    _0205.initialise(0205, "", "", 1, 1, 0, 0);
        //    //add items

        //}
    }
    struct Item
    {
        //vars
        public string type;
        public int ID;
        public string friendlyName;
        public int healthMod, damageMod, manaMod, defenceMod;

        //methods
        public void initialise(int inID, string inFriendlyName, string inType, int inHealthMod, int inDamageMod, int inManaMod, int inDefenceMod)
        {
            ID = inID;
            friendlyName = inFriendlyName;
            type = inType;
            healthMod = inHealthMod;
            damageMod = inDamageMod;
            manaMod = inManaMod;
            defenceMod = inDefenceMod;
        }
    }
}
