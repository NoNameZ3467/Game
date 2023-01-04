using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Player
    {
        public string Name { get; set; }
        public static int XP { get; set; }
        public int Level { get; set; }
        public static int HP { get; set; }
        public static int Gold { get; set; }
        
        public List<string> Inventory { get; set; }

        public Player(string name, int xp, int level, int hp, int gold, List<string> inventory)
        {
            Name = name;
            XP = xp;
            Level = level;
            HP = hp;
            Gold = gold;
            Inventory = inventory;
        }

        public void PrintStatistics()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("XP: " + XP);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("HP: " + HP);
            Console.WriteLine("Gold: " + Gold);
            Console.WriteLine("Inventory: " + String.Join(", ", Inventory));
        }


        public static void GainXP(int amount)
        {
            XP += amount;
        }
        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }
        public static void GainGold(int amount)
        {
            Gold += amount;
        }
        public static void GainHP(int amount)
        {
            HP += amount;
        }
        public void GainLevel(int level)
        {
            Level += 1;
        }
        public static void LooseHP(int amount)
        {
            HP -= amount;
        }
        public static void LooseGold(int amount)
        {
            Gold -= amount;
        }

    }




    class Program
    {



        public static void CheckDeath()
        {
            if (Player.HP <= 0)
            {
                Console.WriteLine("You Died!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public static void Town()
        {
            Console.WriteLine("\nWhile looking around town, you came across an agitated stranger");
            Console.WriteLine("\nHe immediately assaults you, dealing 2 HP in damage to you!");
            Player.LooseHP(2);
            CheckDeath();

            Console.WriteLine("\nDo you take out your sword for an attack, or would you like to get your shield out, defend and make a run out of Town?\nWrite SWORD to fight, or SHIELD to defend:\n");
            string choice = Console.ReadLine();
            if (choice == "SWORD")
            {
                Console.WriteLine("\nYou attack with all your might, striking the stranger just above the shoulder.\nHe is immediately cut in half.\nYou gain 15XP\n");
                Player.GainXP(15);
            }
            else if (choice == "SHIELD")
            {
                Console.WriteLine("\nYou decide to defend yourself, and flee the fight.\nFrom bleeding you loose an additional 1 HP");
                Player.LooseHP(1);
                CheckDeath();
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Shutting down game.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public static void Town2()
        {
            Console.WriteLine("\nWhile looking around town again, you came across an ogre");
            Console.WriteLine("\nThe ogre asks you a riddle: What can you catch, but not throw?");
            string answer = Console.ReadLine();
            if (answer == "Cold" || answer == "Disease" || answer == "Sickness" || answer == "Illnes" || answer == "An illnes" || answer == "A cold" || answer == "A disease")
            {
                Console.WriteLine("\nThe answer to the ogre's riddle is correct, you gain 65 XP, and 100 Gold!");
                Console.WriteLine("\nYou are allowed to now enter the Tavern, which until now was blocked by the ogre");
                Player.GainXP(65);
                Player.GainGold(100);
                Console.WriteLine("\nWould you like to enter the Tavern?\nWrite YES, or NO.");
                string enter = Console.ReadLine();
                if (enter == "YES")
                {
                    Console.WriteLine("\nYou enter the Tavern. You can eat, drink or sleep to restore HP\nWrite DRINK to restore 3 HP for 15 Gold, EAT to restore 5 HP for 25 Gold, or Sleep to restore 10 HP for 45 Gold\n Or you can type LEAVE, to go seek another adventure.");
                    string restore = Console.ReadLine();
                    if (restore == "EAT")
                    {
                        Console.WriteLine("\nYou eat a nice warm meal. HP restored by 5!");
                        Player.LooseGold(25);
                        Player.GainHP(5);
                    }
                    else if (restore == "DRINK")
                    {
                        Console.WriteLine("\nYou enjoy a big jug of beer. HP restored by 3!");
                        Player.LooseGold(15);
                        Player.GainHP(3);
                    }
                    else if (restore == "SLEEP")
                    {
                        Console.Write("\nYou rent a room and get a good nights rest. HP restored by 10!");
                        Player.LooseGold(45);
                        Player.GainHP(10);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Shutting down game.");
                        Console.ReadKey();
                        Environment.Exit(0);

                    }
                }
                else if (enter == "NO")
                {
                    Console.WriteLine("\nYou decided to not enter the Tavern, and went to seek other adventures.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Shutting down game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }
            else
            {
                Console.WriteLine("\nWrong answer! You loose 5 HP to magic damage! The ogre prepares for an attack!");

                Player.LooseHP(5);
                CheckDeath();

                Console.WriteLine("\nDo you take out your sword to attack first, or would you like to get your shield out to defend for the ogre's attack?\nWrite SWORD to fight, or SHIELD to defend:\n");
                string choice = Console.ReadLine();
                if (choice == "SWORD")
                {
                    Console.WriteLine("\nYou attack with all your might, striking the ogre. He is wounded severly, but not dead yet.");
                }
                else if (choice == "SHIELD")
                {
                    Console.WriteLine("\nYou decide to take out your SHIELD and defend yourself.\nThe ogres fist strikes your SHIELD and slides off.");
                }
                if (choice == "SWORD")
                {
                    Console.WriteLine("\nThe ogre attacks, but because he is wounded, his attack misses you.\nYou strike again, now hitting the final blow.\nThe ogre falls to the ground, never to move again.\nYou gain 65 XP!");
                    Player.GainXP(65);
                }
                else if (choice == "SHIELD")
                {
                    Console.WriteLine("\nBecause you defended and gathered your thoughts, you notice the ogre's weak point, his ankle!\nYou strike with your sword, instantly killing the ogre.\nYou gain 65 XP!");
                    Player.GainXP(65);
                }
            }
           
        }

        public static void ColouredForest()
        {
            Console.WriteLine("\nAs you head into the weird forest, you start to get nervous.\nYou feel as if someone, or rather something is watching you...\nBecause of this eerie feeling, would you want to go to the Town?\nWrite YES to go back, or NO to stay");
            string goBack = Console.ReadLine();
            if (goBack == "YES")
            {
                Console.WriteLine("\nYou decided that it is safer back in Town.");
            }
            else if (goBack == "NO")
            {
                Console.WriteLine("\nYour insticts were right, a wolf jumps out of nowhere and bites your arm!\nYou loose 3 HP!");
                Player.LooseHP(3);
                CheckDeath();
                Console.WriteLine("\nThe wolf gets scared, and tries to run away.\nDo you want to try to shoot at it with your bow and risk loosing an arrow if you miss?\nWrite YES to shoot, NO to keep arrows:");
                string shoot = Console.ReadLine();
                if (shoot == "YES")
                {
                    Console.WriteLine("\nYou take a shot at the wolf...\nIt's a hit! You get 15 XP, 10 Gold and WolfMeat! (Plus the arrow was recoverable!)");
                    Player.GainGold(10);
                    Player.GainXP(15);
                   
                }
                else if (shoot == "NO")
                {
                    Console.WriteLine("\nYou decided to just let the animal go, and save the arrows");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Shutting down game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Shutting down game.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            CheckDeath();

            Console.WriteLine("\nYou continue deeper and deeper into the forest.\nYou come across a wishing well.\nDo you want to throw in 10 Gold, and try your luck?\nWrite YES, or NO: ");
            string tryluck = Console.ReadLine();
            if (tryluck == "YES")
            {
                Console.WriteLine("You reach into your purse, and throw in 10 Gold.\nThe well starts to shake!\nIt spits out 25 Gold!");
                Player.GainGold(15);
            }
            else if (tryluck == "NO")
            {
                Console.WriteLine("You decide it's not worth 10 Gold, and continue deeper into the forest");

            }
            else
            {
                Console.WriteLine("\nInvalid choice. Shutting down game.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("It's starting to get dark. You decide to head back to that Town.");

        }

        public static void OakForest()
        {
            Console.WriteLine("\nYou hear a waterfall in the distance. \nYou decide to go investigate.\nWhen you arrive, you immediately spot a mermaid in the lake just below the waterfall.\nMermaid tails are very expensive, you could get a nice chuck of gold for it if you were able to hit it with your bow.\nDo you want to try hitting it, or go and talk with the mermaid?\nWrite TALK, or SHOOT: ");
            string mermaid = Console.ReadLine();
            if (mermaid == "SHOOT")
            {
                Console.WriteLine("\nYou take out your bow, load an arrow, aim, and shoot...\nYou missed! The mermaid notices, and screams so loud your eardrums burst!\nYou loose 5 HP, and the mermaid swims up the waterfall!");
                Player.LooseHP(5);
                CheckDeath();
            }
            else if (mermaid == "TALK")
            {
                Console.WriteLine("\nYou decide it's better if you approach the mermaid and talk with it.\nYou say hello, but startle the mermaid who slaps you with it's fin.\nYou loose 2 HP!\nThe mermaid apologizes, and gives you 40 Gold for hitting you before swimming up the waterfall never to be seen again..");
                Player.GainGold(40);
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Shutting down game.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("\nAfter the mermaid swims away, you decide to walk deeper into the forest to explore.\nOn the horizon you begin to see the silhouette of a small town");
            


        }



            static void Main(string[] args)
        {
            
            Console.Write("Hello Traveler, please state your NAME:\n");
            string NamE = Console.ReadLine();
            var player = new Player(NamE, 0, 1, 10, 0, new List<string> { "Sword", "Shield", "Health Potion", "Bow", "3 Arrows" });
            player.PrintStatistics();

            
            List<string> locations = new List<string>
            {
                "Small Town",                        
                "Banker Town",                     
                "The Spooky Town",                  
                "Oak Forest",                     
                "White Forest",                    
                "Red Forest",                   
                "Snowy Town",            
                "Rich Town",                  
            };

           
            Random random = new Random();
            List<string> randomLocations = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                int index = random.Next(locations.Count);
                randomLocations.Add(locations[index]);
                locations.RemoveAt(index);
            }

            

            Console.WriteLine("\nThis is the beginning of your GLORIOUS journey, {0}! Please, select one of our top-tier starting locations: \n", NamE);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine((i + 1) + ". " + randomLocations[i]);
            }


            Console.WriteLine("\nEnter the number of the location you want to start at:");
            int chosedLocation = Convert.ToInt32(Console.ReadLine());
            if (chosedLocation == 1 || chosedLocation == 2 || chosedLocation == 3)
            {
                Console.WriteLine("\nYour starting location is: " + randomLocations[chosedLocation - 1]);
            }
            else
            {
                Console.WriteLine("Invalid location. Shutting down game.");
                Console.ReadKey();
                Environment.Exit(0);

            }





            string chosenLocation = randomLocations[chosedLocation - 1];
            Console.WriteLine($"\nYou wake up from your nap at the {chosenLocation}, and immediately check if you still have everything on you. Thankfully, nothing was stolen, but you have to be careful around these parts.");

            if (chosenLocation == "Small Town" || chosenLocation == "Banker Town" || chosenLocation == "Rich Town" || chosenLocation == "Snowy Town" || chosenLocation == "The Spooky Town")
            {
                Console.WriteLine("\nWould you like to look around Town?");
                Console.WriteLine("Write YES or NO");
                string LookAroundTown = Console.ReadLine();
                if (LookAroundTown == "YES")
                {
                    Console.WriteLine($"\nYou decided to go looking around {chosenLocation}");
                    Town();
                    player.PrintStatistics();
                    CheckDeath();
                    Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                    Console.WriteLine("\nWrite YES or NO");
                    string LookAroundTownAgain = Console.ReadLine();

                    if (LookAroundTownAgain == "YES")
                    {
                        Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                        Town2();
                        player.PrintStatistics();
                        CheckDeath();
                    }
                    else if (LookAroundTownAgain == "NO")
                    {
                        Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                        player.PrintStatistics();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice. Shutting down game.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                }
                else if (LookAroundTown == "NO")
                {
                    if (chosenLocation == "Small Town")
                    {
                        Console.WriteLine("\nYou decided to ignore the Small Town for now, and head out of Town, into the nearest Forest: Red Forest");
                        ColouredForest();
                        player.AddToInventory("WolfMeat");
                        player.PrintStatistics();
                        CheckDeath();
                        if (LookAroundTown == "NO")
                        {
                            Console.WriteLine("\nYou arrived back to the Small Town");
                            Town();
                            player.PrintStatistics();
                            CheckDeath();

                            Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                            Console.WriteLine("\nWrite YES or NO");
                            string LookAroundTownAgain = Console.ReadLine();

                            if (LookAroundTownAgain == "YES")
                            {
                                Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                                Town2();
                                player.PrintStatistics();
                                CheckDeath();
                            }
                            else if (LookAroundTownAgain == "NO")
                            {
                                Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                                player.PrintStatistics();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice. Shutting down game.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (chosenLocation == "Banker Town")
                    {
                        Console.WriteLine("\nYou decided to ignore the Banker Town for now, and head out of Town, into the nearest Forest: Oak Forest");
                        OakForest();
                        player.PrintStatistics();
                        CheckDeath();
                        if (LookAroundTown == "NO")
                        {
                            Console.WriteLine("\nYou arrived back to the Banker Town");
                            Town();
                            player.PrintStatistics();
                            CheckDeath();

                            Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                            Console.WriteLine("\nWrite YES or NO");
                            string LookAroundTownAgain = Console.ReadLine();

                            if (LookAroundTownAgain == "YES")
                            {
                                Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                                Town2();
                                player.PrintStatistics();
                                CheckDeath();
                            }
                            else if (LookAroundTownAgain == "NO")
                            {
                                Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                                player.PrintStatistics();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice. Shutting down game.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (chosenLocation == "Rich Town")
                    {
                        Console.WriteLine("\nYou decided to ignore Rich Town for now, and head out of Town, into the nearest Forest: White Forest");
                        ColouredForest();
                        player.PrintStatistics();
                        CheckDeath();
                        if (LookAroundTown == "NO")
                        {
                            Console.WriteLine("\nYou arrived back to the Rich Town");
                            Town();
                            player.PrintStatistics();
                            CheckDeath();

                            Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                            Console.WriteLine("\nWrite YES or NO");
                            string LookAroundTownAgain = Console.ReadLine();

                            if (LookAroundTownAgain == "YES")
                            {
                                Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                                Town2();
                                player.PrintStatistics();
                                CheckDeath();
                            }
                            else if (LookAroundTownAgain == "NO")
                            {
                                Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                                player.PrintStatistics();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice. Shutting down game.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (chosenLocation == "Snowy Town")
                    {
                        Console.WriteLine("\nYou decided to ignore Snowy Town for now, and head out of Town, into the nearest Forest: White Forest");
                        ColouredForest();
                        player.PrintStatistics();
                        CheckDeath();
                        if (LookAroundTown == "NO")
                        {
                            Console.WriteLine("\nYou arrived back to the Snowy Town");
                            Town();
                            player.PrintStatistics();
                            CheckDeath();

                            Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                            Console.WriteLine("\nWrite YES or NO");
                            string LookAroundTownAgain = Console.ReadLine();

                            if (LookAroundTownAgain == "YES")
                            {
                                Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                                Town2();
                                player.PrintStatistics();
                                CheckDeath();
                            }
                            else if (LookAroundTownAgain == "NO")
                            {
                                Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                                player.PrintStatistics();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice. Shutting down game.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (chosenLocation == "The Spooky Town")
                    {
                        Console.WriteLine("\nYou decided to ignore The Spooky Town for now, and head out of Town, into the nearest Forest: Red Forest");
                        ColouredForest();
                        player.PrintStatistics();
                        CheckDeath();
                        if (LookAroundTown == "NO")
                        {
                            Console.WriteLine("\nYou arrived back to the Spooky Town");
                            Town();
                            player.PrintStatistics();
                            CheckDeath();

                            Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                            Console.WriteLine("\nWrite YES or NO");
                            string LookAroundTownAgain = Console.ReadLine();

                            if (LookAroundTownAgain == "YES")
                            {
                                Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                                Town2();
                                player.PrintStatistics();
                                CheckDeath();
                            }
                            else if (LookAroundTownAgain == "NO")
                            {
                                Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                                player.PrintStatistics();
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice. Shutting down game.");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                
            }
            else if (chosenLocation == "Oak Forest")
            {
                OakForest();
                ColouredForest();
                Console.WriteLine("You enter the town, the one that you saw the silhouette of from the forest.");
                Town();
                player.PrintStatistics();
                CheckDeath();
                Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                Console.WriteLine("\nWrite YES or NO");
                string LookAroundTownAgain = Console.ReadLine();

                if (LookAroundTownAgain == "YES")
                {
                    Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                    Town2();
                    player.PrintStatistics();
                    CheckDeath();
                }
                else if (LookAroundTownAgain == "NO")
                {
                    Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                    player.PrintStatistics();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Shutting down game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else if (chosenLocation == "White Forest")
            {
                ColouredForest();
                Console.WriteLine("You enter the town, the one that you saw the silhouette of from the forest.");
                Town();
                player.PrintStatistics();
                CheckDeath();
                Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                Console.WriteLine("\nWrite YES or NO");
                string LookAroundTownAgain = Console.ReadLine();

                if (LookAroundTownAgain == "YES")
                {
                    Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                    Town2();
                    player.PrintStatistics();
                    CheckDeath();
                }
                else if (LookAroundTownAgain == "NO")
                {
                    Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                    player.PrintStatistics();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Shutting down game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            else if (chosenLocation == "Red Forest")
            {
                ColouredForest();
                Console.WriteLine("You enter the town, the one that you saw the silhouette of from the forest.");
                Town();
                player.PrintStatistics();
                CheckDeath();
                Console.WriteLine("\nAfter this little incident, would you still like to keep looking?");
                Console.WriteLine("\nWrite YES or NO");
                string LookAroundTownAgain = Console.ReadLine();

                if (LookAroundTownAgain == "YES")
                {
                    Console.WriteLine($"\nYou decided to keep looking around {chosenLocation}");
                    Town2();
                    player.PrintStatistics();
                    CheckDeath();
                }
                else if (LookAroundTownAgain == "NO")
                {
                    Console.WriteLine("\nThank you for playing! Here are your final stats: ");
                    player.PrintStatistics();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nInvalid choice. Shutting down game.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }



            Console.ReadKey();
        }

       
    }
}

