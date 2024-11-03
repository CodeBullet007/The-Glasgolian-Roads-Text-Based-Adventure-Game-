using System;
using System.Security.Cryptography.X509Certificates;

namespace Text_based_adventure
{

    internal class Program
    {
        public class shop
        {
            public static void LoadShop(player p)
            {
                RunShop(p);
            }

            public static void RunShop(player p)
            {
                int bandageP;
                int gearP;
                int weaponP;
                int difP;
                while (true)
                {
                    bandageP = 20 + 10 * p.mods;
                    gearP = 100 * (p.armourValue + 1);
                    weaponP = 100 * p.weaponValue;
                    difP = 300 + 100 * p.mods;

                    Console.Clear();
                    Console.WriteLine("         Shop            ");
                    Console.WriteLine("======================");
                    Console.WriteLine("(B)andages:         $" + bandageP);
                    Console.WriteLine("(G)ear:             $" + gearP);
                    Console.WriteLine("(W)eapon:           $" + weaponP);
                    Console.WriteLine("(D)ifficulty Mod:   $" + difP);
                    Console.WriteLine("======================");
                    Console.WriteLine("(E)xit");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(p.name + "'s Stats");
                    Console.WriteLine("======================");
                    Console.WriteLine("Money " + p.Money);
                    Console.WriteLine("Health " + p.Health);
                    Console.WriteLine("Weapon Strength " + p.weaponValue);
                    Console.WriteLine("Gear Protection Level " + p.armourValue);
                    Console.WriteLine("Bandages " + p.Bandages);
                    Console.WriteLine("Difficulty Mods " + p.mods);
                    Console.WriteLine("======================");

                    string input = Console.ReadLine().ToLower();
                    if (input == "b" || input == "bandages")
                    {
                        TryBuy("bandages", bandageP, p);
                    }
                    else if (input == "w" || input == "weapon")
                    {
                        TryBuy("weapon", weaponP, p);
                    }
                    else if (input == "g" || input == "gear")
                    {
                        TryBuy("gear", gearP, p);
                    }
                    else if (input == "d" || input == "difficulty mod")
                    {
                        TryBuy("dif", difP, p);
                    }
                    else if (input == "e" || input == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
            static void TryBuy(string item, int cost, player p)
            {
                if (p.coins >= cost)
                {
                    if (item == "bandages")
                    {
                        p.Bandages++;
                    }
                    else if (item == "gear")
                    {
                        p.armourValue++;
                    }
                    else if (item == "weapon")
                    {
                        p.weaponValue++;
                    }
                    else if (item == "difficulty mod")
                    {
                        p.mods++;
                    }
                    p.coins -= cost;
                }
                else
                {
                    Console.WriteLine("You dont got enough dough");
                    Console.ReadKey();
                }


            }

            static Random rand = new Random();

            public class encounters
            {
                public static string GetName()
                {
                    switch (rand.Next(0, 9))
                    {
                        case 0:
                            return "Bandit Crook";
                        case 1:
                            return "Bandit Chief";
                        case 2:
                            return "Bandit scout";
                        case 3:
                            return "Bandit Leader";
                        case 4:
                            return "Goblin Cheif";
                        case 5:
                            return "Goblin scout";
                        case 6:
                            return "Goblin thug";
                        case 7:
                            return "traffic warden";
                        case 8:
                            return "Goblin Shark";
                        default:
                            return "Human";
                    }
                }

                public static Random rand = new Random();

                //Encounter Generic


                //Encounters
                public static void FirstEncounter()
                {
                    Console.WriteLine("You Ride out of the garage and onto the open road.");
                    Console.WriteLine("                            ___\r\n                          /~   ~\\\r\n                         |_      |\r\n                         |/     __-__\r\n                          \\   /~     ~~-_\r\n                           ~~ -~~\\       ~\\\r\n                            /     |        \\\r\n               ,           /     /          \\\r\n             //   _ _---~~~    //-_          \\\r\n           /  (/~~ )    _____/-__  ~-_       _-\\             _________\r\n         /  _-~\\\\0) ~~~~         ~~-_ \\__--~~   `\\  ___---~~~        /'\r\n        /_-~                       _-/'          )~/               /'\r\n        (___________/           _-~/'         _-~~/             _-~\r\n     _ ----- _~-_\\\\\\\\        _-~ /'      __--~   (_ ______---~~~--_\r\n  _-~         ~-_~\\\\\\\\      (   (     -_~          ~-_  |          ~-_\r\n /~~~~\\          \\ \\~~       ~-_ ~-_    ~\\            ~~--__-----_    \\\r\n;    / \\ ______-----\\           ~-__~-~~~~~~--_             ~~--_ \\    .\r\n|   | \\((*)~~~~~~~~~~|      __--~~             ~-_               ) |   |\r\n|    \\  |~|~---------)__--~~                      \\_____________/ /    ,\r\n \\    ~-----~    /  /~                             )  \\    ~-----~    /\r\n  ~-_         _-~ /_______________________________/    `-_         _-~\r\n     ~ ----- ~                                            ~ ----- ~  ");
                    Console.ReadKey();
                    Console.WriteLine("You see a group of crooked neck bandits ahead.");
                    Console.ReadKey();
                    Combat(false, "Bandit Crook", 1, 4);
                }
                public static void BasicFightEncounter()
                {
                    Console.Clear();
                    Console.WriteLine("You ride around for a few hours and in the road encounter...");
                    Console.ReadKey();
                    Combat(true, "", 0, 0);
                }
                public static void BikeEncounter()
                {
                    Console.WriteLine("While riding you see a bike in the distance");
                    Console.WriteLine("As it approaches you identify it as a threat");
                    Console.ReadKey();
                    Combat(false, "Ghost Rider", 1, 4);
                }

                //Encounter Tools
                public static void RandomEncounter()
                {
                    switch (rand.Next(0, 2))
                    {
                        case 0:
                            BasicFightEncounter();
                            break;
                        case 1:
                            BikeEncounter();
                            break;
                    }
                }

                public static void Combat(bool random, string name, int power, int health)
                {
                    string n = "";
                    int p = program.currentPlayer.GetPower();
                    int h = program.currentPlayer.GetHealth();
                    if (random)
                    {
                        n = GetName();
                        p = rand.Next(1, 5);
                        h = rand.Next(1, 8);
                    }
                    else
                    {
                        n = name;
                        p = power;
                        h = health;
                    }
                    while (h > 0)
                    {
                        Console.Clear();
                        Console.WriteLine(n);
                        Console.WriteLine(p + "/" + h);
                        Console.WriteLine("=====================");
                        Console.WriteLine("| (A)ttack  (D)efend |");
                        Console.WriteLine("| (R)un     (H)eal   |");
                        Console.WriteLine("=====================");
                        Console.WriteLine(" Fuel: " + program.currentPlayer.Fuel + " Health: " + program.currentPlayer.Health);
                        string input = Console.ReadLine();
                        if (input.ToLower() == "a") //Attack
                        {
                            //Attack
                            Console.WriteLine("Ripping down the road you attack the bandits with your Motorcycle, the " + n + " places spikes in the road");
                            int damage = p - program.currentPlayer.Fuel;
                            if (damage < 0)
                                damage = 0;
                            int attack = rand.Next(0, program.currentPlayer.weaponValue) + rand.Next(1, 4);
                            Console.WriteLine("You lose " + damage + "health and you deal " + attack + " damage");
                            program.currentPlayer.Health -= damage;
                            h -= attack;
                        }
                        else if (input.ToLower() == "d") //Defend
                        {
                            //Defend
                            Console.WriteLine("As the " + n + " Prepares to strike you tear your seat and ready it as a shield ");
                            int damage = (p / 4) - program.currentPlayer.Fuel;
                            if (damage < 0)
                                damage = 0;
                            int attack = rand.Next(0, program.currentPlayer.weaponValue) / 2;
                            Console.WriteLine("You lose " + damage + " health and you deal " + attack + " damage");
                            program.currentPlayer.Health -= damage;
                            h -= attack;
                        }

                        else if (input.ToLower() == "h") //Heal
                        {

                        }

                        else if (input.ToLower() == "r") //Run
                        {
                            //Run
                            if (rand.Next(0, 2) == 0)
                            {
                                Console.WriteLine("As you ride away from the " + n + ", his strike catches you in the back sending you flying");
                                int damage = p - program.currentPlayer.Fuel;
                                if (damage < 0)
                                    damage = 0;
                                Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("you use your untapped potential of martial arts to escape the " + n + " and ride away, sucessfully escaping");
                                Console.ReadKey();
                                shop.LoadShop(program.currentPlayer);
                            }
                        }
                        else
                        {
                            //heal
                            if (program.currentPlayer.Bandages == 0)
                            {
                                Console.WriteLine("as you desperatley grasp for some bandages in your satchel all that you can feel are the empty rolls from encounters");
                                int damage = p - program.currentPlayer.Fuel;
                                if (damage < 0)
                                    damage = 0;
                                Console.WriteLine("The " + n + " Strikes you with a devastating blow and you lose " + damage + " health");
                            }
                            else
                            {
                                Console.WriteLine("You reach into your bag and retrieve your bandage. you wrap it around your wounds");
                                int bandageValue = 5;
                                Console.WriteLine("You gain " + bandageValue + "health");
                                program.currentPlayer.Health += bandageValue;
                                Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                                int damage = (p / 2) - program.currentPlayer.Fuel;
                                if (damage < 0)
                                    damage = 0;
                                Console.WriteLine("You lose " + damage + " health");
                            }
                            Console.ReadKey();
                        }
                        if (program.currentPlayer.Health <= 0)
                        {
                            //Death Code
                            Console.WriteLine("As the " + n + " stands menacingly and comes down to strike you have been murdered by " + n);
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        Console.ReadKey();
                    }
                    int c = program.currentPlayer.GetMoney();
                    Console.WriteLine("As you stand victorious over the" + n + ", their wallet falls from him releasing " + c + " dollars");
                    program.currentPlayer.Money += c;
                    Console.ReadKey();
                }
            }
            public class player
            {
                Random rand = new Random();

                public string name;
                public int Health = 10;
                public int Damage = 1;
                public int Money = 2000;
                public int Fuel = 100;
                public int weaponValue = 1;
                public int Bandages = 3;

                public int mods = 0;
                internal int armourValue;
                internal int coins;

                public int GetHealth()
                {
                    int upper = (2 * mods + 7);
                    int lower = (mods + 2);
                    return rand.Next(lower, upper);
                }

                public int GetPower()
                {
                    int upper = (2 * mods + 2);
                    int lower = (mods + 1);
                    return rand.Next(lower, upper);
                }
                public int GetMoney()
                {
                    int upper = (10 * mods + 50);
                    int lower = (15 * mods + 10);
                    return rand.Next(lower, upper);
                }
            }
            public class program
            {
                public static player currentPlayer = new player();
                public static bool mainLoop = true;
                static void Main(string[] args)
                {
                    Start();
                    encounters.FirstEncounter();
                    while (mainLoop)
                    {
                        encounters.RandomEncounter();
                    }
                }

                public static void Start()
                {
                    Console.WriteLine("Welcome to the Garage");
                    Console.WriteLine("What's your name?");
                    currentPlayer.name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("You look around the shop.");
                    Console.ReadKey();
                    Console.WriteLine("like a tardis you had just walked into a tiny shop and yet an expansive floor,");
                    Console.WriteLine("of many petrol filled wears litter the space,");
                    Console.ReadKey();
                    Console.WriteLine("You see a goblin staring at you with a grin.");
                    Console.WriteLine("             ,      ,\r\n            /(.-\"\"-.)\\\r\n        |\\  \\/      \\/  /|\r\n        | \\ / =.  .= \\ / |\r\n        \\( \\   o\\/o   / )/\r\n         \\_, '-/  \\-' ,_/\r\n           /   \\__/   \\\r\n           \\ \\__/\\__/ /\r\n         ___\\ \\|--|/ /___\r\n       /`    \\      /    `\\\r\n      /       '----'       \\");
                    if (currentPlayer.name == "")
                        Console.WriteLine("He says 'Welcome to the Garage, stranger.'");


                    else
                        Console.WriteLine("He says 'Welcome to the Garage, " + currentPlayer.name + ".'");

                    Console.ReadKey();
                    Console.WriteLine("You look around the garage till you find your match");

                    Console.WriteLine("What would you like to buy? " + "you have $" + currentPlayer.Money);
                    Console.WriteLine("Yamaha R1 - $1500");
                    Console.WriteLine("                                 `   `.\r\n           <```--...       .---.//  < `.\r\n            `..     `.___ /       ___`.'\r\n              _`_ .      `      .'\\\\__\r\n            .'---`.`.          / .'---`.\r\n           /.'  _`.\\_\\        / /.'\\\\ `.\\\r\n           ||  <__||_|        | ||  ~  ||\r\n           \\`.___.'/ /________\\ \\`.___.'/\r\n            `.___.'              `.___.'");
                    Console.WriteLine("Ninja h2 - $2000");
                    Console.WriteLine("                       ;~\\.\r\n        .              _._\\\")\r\n        I\\___        ,;)))}^\\\r\n        I `%%^\\%%%%.::q::    `\\.\r\n      .*//*.    OOO  }}} ))    .\\8^8*.\r\n   =LIEF()ZIMMERMAN(((((()'    --(*)--\r\n      \"*oo*\"                   \"*ooo*\"");
                    Console.WriteLine("Ducati Panigale - $2500");
                    Console.WriteLine("          r==\r\n        _  //\r\n       |_)//(''''':\r\n         //  \\_____:_____.-----.P\r\n        //   | ===  |   /        \\\r\n    .:'//.   \\ \\=|   \\ /  .:'':.\r\n   :' // ':   \\ \\ ''..'--:'-.. ':\r\n   '. '' .'    \\:.....:--'.-'' .'\r\n    ':..:'                ':..:'");
                    string choice = Console.ReadLine();

                    if (choice.ToLower() == "yamaha r1")
                    {
                        currentPlayer.Money -= 1500;
                        Console.WriteLine("You have bought the Yamaha R1");
                        Console.WriteLine("You now have $" + currentPlayer.Money);
                    }
                    else if (choice.ToLower() == "ninja h2")
                    {
                        currentPlayer.Money -= 2000;
                        Console.WriteLine("You have bought the ninja h2");
                        Console.WriteLine("You now have $" + currentPlayer.Money);
                    }
                    else if (choice.ToLower() == "ducati panigale")
                    {
                        currentPlayer.Money -= 2500;
                        Console.WriteLine("YOU DONT HAVE ENOUGH MONEY FOR THIS BIKE - screams the Goblin Shark");
                    }
                    else
                    {
                        Console.WriteLine("You have not bought anything");
                    }

                    Console.ReadKey();
                }
            }
        }
    }
}

