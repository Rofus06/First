using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();

    }
}

class Game
{
    private Player player;
    private List<Zombie> zombies;
    private int day = 1;

    public Game()
    {
        player = new Player();
        zombies = new List<Zombie>();
    }
    

    public void Start()
    {
        Console.WriteLine("Welcome to the Zombie Survival Game!");
        Console.WriteLine("Press TAB to open inventory");
        Console.WriteLine("10 to start the day.");
        Console.WriteLine("equip something from inventory with 1-5");
        Console.WriteLine("For more information about an object press 8");

        while (true)
        {
            string input = Console.ReadLine();   
            ConsoleKeyInfo key = Console.ReadKey(true); // Read key without displaying it
            if (key.Key == ConsoleKey.Tab)
            {
                player.ShowInventory();
            }
            else if (input == "10")
            {
                StartDay();
            }
            else if (input == "8")
            {
                Display();
            }
        }
        
    }

    private void StartDay()
    {
        Console.WriteLine($"\nDay {day} begins!");
        zombies.Clear();
        zombies.Add(new Zombie(30));
        zombies.Add(new Zombie(50));

        foreach (var zombie in zombies)
        {
            Console.WriteLine($"A zombie is {zombie.Distance} meters away.");
        }
    }
    public void Display()
    {
        Console.WriteLine("Do for example *info pistol* for more information about pistol.");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item.Name} (Range: {item.Range}m) ");
        }
    }
}

class Player
{
    private Inventory inventory;

    public Player()
    {
        inventory = new Inventory();
        inventory.AddItem(new Weapon("Pistol", 100));
    }

    public void ShowInventory()
    {
        Console.WriteLine("\nYour Inventory:");
        Inventory.DrawRectangles();
    }
}

class Inventory
{
    
    private List<Weapon> items = new List<Weapon>();
    

    public static void DrawRectangles()
    {
        string[] rectangle =
        {
            "+-----------+  +-----------+  +-----------+  +-----------+  +-----------+",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|    GUN    |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|__________1|  |__________2|  |__________3|  |__________4|  |__________5|",

            "+-----------+  +-----------+  +-----------+  +-----------+  +-----------+",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|___________|  |___________|  |___________|  |___________|  |___________|",

            "+-----------+  +-----------+  +-----------+  +-----------+  +-----------+",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|           |  |           |  |           |  |           |  |           |",
            "|___________|  |___________|  |___________|  |___________|  |___________|"
        };
        
        foreach (string line in rectangle)
        {
            Console.WriteLine(line);
        }
    }

    public void AddItem(Weapon item)
    {
        items.Add(item);
    }
}

class Zombie
{
    public int Distance { get; private set; }

    public Zombie(int distance)
    {
        Distance = distance;
    }
}

class Weapon
{
    public string Name { get; private set; }
    public int Range { get; private set; }

    public Weapon(string name, int range)
    {
        Name = name;
        Range = range;
    }
}
