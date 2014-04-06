using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        //vars
        private static string SENTINAL = "n";
        public static bool DEBUGENABLED = false;

        //methods
        static void Main(string[] args)
        {
            //start gameloop
            while (true)
            {
                //create, initialise and start a new game object
                Game GameLogic = new Game();
                GameLogic.Initialise();
                GameLogic.Run();
                Console.WriteLine("Your score was {0}, want to play again? (Y/{1})", Game.score, SENTINAL.ToUpper());
                string PlayerInput = Console.ReadLine();
                if (PlayerInput.ToLower() == SENTINAL)
                {
                    break;
                }
            }
        }
    }
    class Game
    {
        //vars
        public static int score;
        Hero hero = new Hero();
        //Hashtable scores = new Hashtable(); //will be used for a scoreboard
        //char[] nodes = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' }; //unnecessary with the enum defined
        //defining the arc map for nodes defined below. Will be used to lay out encounters and items on the adventure.
        bool[,] nodesConnections = {
                                    //a         b       c       d       e       f       g       h
                                /*a*/{false,    true,   false,  false,  false,  false,  false,  false},
                                /*b*/{false,    false,  true,   true,   false,  false,  true,   false},
                                /*c*/{false,    false,  false,  false,  true,   true,   false,  false},
                                /*d*/{false,    false,  false,  false,  false,  false,  true,   false},
                                /*e*/{false,    false,  false,  false,  false,  false,  false,  true},
                                /*f*/{false,    false,  false,  false,  true,   false,  false,  false},
                                /*g*/{false,    false,  false,  false,  true,   false,  false,  true},
                                /*h*/{false,    false,  false,  false,  false,  false,  false,  false},
                                  };
        public enum nodes
        {
            a = 0,
            b = 1,
            c = 2,
            d = 3,
            e = 4,
            f = 5,
            g = 6,
            h = 7
        }

        //methods
        public void Initialise(){
            //initialise the gamestate
            Console.WriteLine("What is your name adventurer?");
            string newName = Console.ReadLine();
            hero.initialise(newName);
            score = 0;
        }
        public static void addScore(int s)
        {
            score += s;
        }
        public void Run()
        {
            //currently debug code to test everything works
            if (Program.DEBUGENABLED)
            {
                Console.WriteLine("Testing Gameloop Works");
                Console.WriteLine("Hero name is: {0}", hero.friendlyName);
                Console.WriteLine("Adding a new item to the hero, and outputting it's damage, and the hero's new damage as a result");
                Item newItem = new Item();
                newItem = ItemsList.getNewItem();
                Console.WriteLine("The item \"{0}\" has: \nID: {1} \nHealth Modifier:{2} \nDamage Modifier: {3} \nMana Modifier: {4} \nDefence modifier: {5} \nAnd goes on the {6}", newItem.friendlyName, newItem.ID, newItem.healthMod, newItem.damageMod, newItem.manaMod, newItem.defenceMod, newItem.type);
                Console.WriteLine("Hero has current stats: \nHealth: {0} \nDamage: {1} \nMana: {2} \nDefence: {3}", hero.health, hero.damage, hero.mana, hero.defence);
                hero.addItem(newItem);
                Console.WriteLine("Added item");
                Console.WriteLine("Hero has current stats: \nHealth: {0} \nDamage: {1} \nMana: {2} \nDefence: {3}", hero.health, hero.damage, hero.mana, hero.defence);
                Console.WriteLine("Creating new monster");
            }
            Monster testerM = new Monster();
            testerM.initialise();
            if (Program.DEBUGENABLED)
            {
                Console.WriteLine("Monster \"{0}\" has: \nhealth: {1} \ndamage: {2} \ndefence: {3}", testerM.friendlyName, testerM.health, testerM.damage, testerM.defence);
                Console.WriteLine("Initialising battle between:{0}, {1}", hero.friendlyName, testerM.friendlyName);
            }
            Battle newBattle = new Battle(hero, testerM);
        }
        

    }

}
