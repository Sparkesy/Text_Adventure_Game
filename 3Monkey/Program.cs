using System;

namespace _3Monkey
{
    class Program
    {
        // attributes
        static bool haswood = false;
        static bool hasnote = false;
        static bool haskeys = false;
        static bool hasmatches = false;


        // main method
        static void Main(string[] args)
        {
            do
            {
                haswood = false;
                hasnote = false;
                haskeys = false;
                hasmatches = false;

               
                CaveEnter();


                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Press 'x' to exit or any other key to play again.");
            }
            while (Console.ReadKey().KeyChar != 'x');
        }


        static string GetInput()
        {
            // ask for input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter a command or 'help': ");
            return Console.ReadLine().ToLower();
        }


        // help
        static void DrawHelp()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Commands");

            Console.Write("help");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - show valid commands.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("go (left, right, forward, back)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - move to a next room");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("pick up (item name)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - collect an item and add to inventory.");

            Console.Write("Inventory");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - Shows current inventory. ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        static void inventory() { 
            bool askAgain = true;

            while (askAgain)
            {
            string userCommand = GetInput();
            Console.Write("Here is all the junk you picked up: ");
            Console.WriteLine();
                if (haswood == true)
                {
                    Console.WriteLine("You have a plank of wood.");
                }
                else if (haskeys == true)
                {
                    Console.WriteLine("You have a set of keys.");
                }
                else if (hasmatches == true)
                {
                    Console.WriteLine("You have a box of matches.");
                }
                else if (hasnote == true)
                {
                    Console.WriteLine("You have a note.");
                }
                else if (userCommand == "go back")
                {
                    askAgain = false;
                    Console.WriteLine("See shoulda been taking note of what you picked up, as a result your punishment shall be going back to the start. :-)");
                    CaveEnter();
                }

            }
        
          }
        // Cave 
        static void CaveEnter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You are at the Cave Opening ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("There is a sign infront of you saying 'beware ahead dangerous pirates lurk within!!!' ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Ahead is a split in the path left takes you to a river, right a blocked passage!!!");
            Console.WriteLine();

            if (haswood == false)
            {
                Console.WriteLine();
                Console.WriteLine("Below the sign is a blank of wood!!! ");
            }
            // loop while user input is not valid
            bool askAgain = true;

            while (askAgain)
            {

                // get user input
                string userCommand = GetInput();
                // test for valid action
                if (userCommand == "go left")
                {
                    // draw river room
                    askAgain = false;
                    RiverRoom();
                }
                else if (userCommand == "go right")
                {
                    // draw blocked path
                    askAgain = false;
                    PassRoom();
                }
                else if (userCommand == "pick up wood")
                {
                    //put wood in inventory

                    haswood = true;
                    Console.WriteLine("You picked up the wood");
                }
                else if (userCommand == "help")
                {
                    askAgain = false;
                    DrawHelp();

                }
                else if (userCommand == "inventory")
                {
                    askAgain = false;
                    inventory();
                }

                else
                {
                    askAgain = false;
                    Console.Write("You cocked it up, try again: ");
                    Broke();
                }
            }
        }

        static void RiverRoom()
        {
            // draw river room
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You are by a river running across your path about 20ft wide. Find a Way Across!! ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("There is a half broken bridge ending in the middle of the river find a way over to it:   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();

            bool askagain = true;
            while (askagain)
            {
                // capture user input
                string userCommand = GetInput();

                // test for valid action

                if (userCommand == "go back")
                {
                    askagain = false;
                    CaveEnter();
                }
                else if (userCommand == "go forward")
                {
                    if (haswood == true)
                    {
                        askagain = false;
                        RiverOtherSide();
                    }
                    else if (haswood == false)
                    {
                        Console.WriteLine("Sorry you need something to help you cross");
                    }
                    else if (userCommand == "help")
                    {
                        askagain = false;
                        DrawHelp();

                    }
                    else
                    {
                        askagain = false;
                        Console.Write("You cocked it up, try again: ");
                        Broke();
                    }
                }
            }

        }

        static void RiverOtherSide()
        {
            Console.Clear();
            Console.WriteLine("As you pass over the bridge you find a piece of paper letting you know that on the other side there is another split in the road left takes you to a grog chamber, right takes you to the other side of the blocked passage you encountered earlier on.  ");
            Console.WriteLine();

            bool askagain = true;
            while (askagain)
            {
                string userCommand = GetInput();

                if (userCommand == "go left")
                {
                    // go to grog room
                    askagain = false;
                    GrogRoom();
                }
                else if (userCommand == "go right")
                {
                    // go to blocked passage
                    askagain = false;
                    PassRoom();
                }
                else if (userCommand == "pick up note")
                {
                    hasnote = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You have the note it says:");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine();
                    Console.WriteLine("Whoever finds this beware the door ahead requires a key but for the life of me i can't find the bloody thing. Sorry :-)");
                }
                else if (userCommand == "help")
                {
                    askagain = false;
                    DrawHelp();

                }
                else
                {
                    askagain = false;
                    Console.Write("You cocked it up, try again: ");
                    Broke();
                }
            }
        }
        static void GrogRoom()
        {
            // draw grog room
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You are in a room with lots of barrels of NotLeChucks Grog! ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("There is nowhere to go in this room although there is a small box full of keys of all different shapes along with some matches!!   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            bool askagain = true;
            while (askagain)
            {
                // capture user input
                string userCommand = GetInput();
                // test for valid action
                if (userCommand == "go back")
                {
                    // go back to river room
                    askagain = false;
                    RiverOtherSide();
                }
                else if (userCommand == "pick up items")
                {
                    hasmatches = true;
                    haskeys = true;
                    // put keys in inventory
                    Console.WriteLine("Yay, yet more crap to carry!!!");
                }
                else if (userCommand == "help")
                {
                    askagain = false;
                    DrawHelp();

                }
                else
                {
                    askagain = false;
                    Console.Write("You cocked it up, try again: ");
                    Broke();
                }
            }
        }

        static void PassRoom()
        {
            // draw blocked passage
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("You are in the dark barely able to see the rubble infront of you!! ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You can make out something wooden infront of you, it is a door not mentioned on the note from earlier.:   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("You try the door and it is locked, See if one of the keys in your inventory will open it.  ");
            Console.WriteLine();

            bool askagain = true;
            while (askagain)
            {
                string userCommand = GetInput();
                // test for valid action
                if (userCommand == "go back")
                {
                    askagain = false;
                    // Go Back
                    RiverRoom();
                }
                else if (userCommand == "go through door")
                {
                    if (haskeys == false)
                    {
                        Console.WriteLine("Sorry bud no can do, doors locked and you don't have the key!!!");
                    }
                    else if (haskeys == true)
                    {
                        askagain = false;
                        Exit();
                    }
                    else if (userCommand == "help")
                    {
                        askagain = false;
                        DrawHelp();

                    }
                    else
                    {
                        askagain = false;
                        Console.Write("You cocked it up, try again: ");
                        Broke();
                    }
                }
            }


            static void Exit()
            {

                // draw blocked passage
                bool askagain = true;
                while (askagain)
                {
                    String userCommand = GetInput();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You have found your way out ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Good on you");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Now you can throw all that crap you picked up in the nearest bin");
                    Console.WriteLine();
                    Console.ReadKey();
                    if (userCommand == "Restart")
                    {
                        // Go Back#
                        askagain = false;
                        CaveEnter();
                    }
                    else if (userCommand == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (userCommand == "help")
                    {
                        askagain = false;
                        DrawHelp();

                    }
                    else
                    {
                        askagain = false;
                        Console.Write("You cocked it up, try again: ");
                        Broke();
                    }
                    // go to exit
                }
            }
        }

        static void Broke()
        {
            bool askagain = true;
            while (askagain)
            {
                string userCommand = GetInput();
                Console.Clear();
                Console.Write("You Broke it, try again: ");
                Console.Write("Press Y to start again or N to Exit");
                if (userCommand == "Y")
                {
                    CaveEnter();
                }
                else if (userCommand == "N")
                {
                    Environment.Exit(0);
                }
                else if (userCommand == "help")
                {
                    askagain = false;
                    DrawHelp();

                }
                else
                {
                    askagain = false;
                    Console.Write("You broke it, try again: ");
                    Broke();
                }
            }
        }
        
    }
}

   

