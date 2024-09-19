using System;

class Program
{
    static ConsoleColor[] szinek = { ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Red };
    static string[] szinNevek = { "Fehér", "Kék", "Sárga", "Zöld", "Piros" };
    static int aktualisSzinIndex = 0;
    static ConsoleColor aktualisSzin = ConsoleColor.White;

    static void Main(string[] args)
    {
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 1); 
        Console.Write("Start: Enter  |  Szín választás: C");


        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
        }

        Console.Clear();
        Console.WriteLine("Rajzoláshoz használd a nyílbillentyűket. Színválasztáshoz nyomd meg a 'C' billentyűt.");

        int cursorX = 0;
        int cursorY = 0;
        Console.SetCursorPosition(cursorX, cursorY);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

              
                if (key == ConsoleKey.C)
                {
                    SzintValaszt();
                }

                
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (cursorX > 0)
                            cursorX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX < Console.WindowWidth - 1)
                            cursorX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursorY > 0)
                            cursorY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY < Console.WindowHeight - 1)
                            cursorY++;
                        break;
                }

                Console.SetCursorPosition(cursorX, cursorY);
                Console.ForegroundColor = aktualisSzin;
                Console.Write("█");
                Console.ResetColor();
            }
        }
    }

    static void SzintValaszt()
    {
        int valasztottSzin = 0;
        bool szinKivalasztva = false;

        Console.Clear();
        Console.WriteLine("Nyílbillentyűkkel válassz egy színt, majd nyomj Enter-t:");

        while (!szinKivalasztva)
        {
            
            for (int i = 0; i < szinek.Length; i++)
            {
                if (i == valasztottSzin)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.ForegroundColor = szinek[i];
                Console.Write("  {0}  ", szinNevek[i]);
                Console.ResetColor();
                Console.WriteLine();
            }

           
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (valasztottSzin > 0)
                        valasztottSzin--;
                    break;
                case ConsoleKey.DownArrow:
                    if (valasztottSzin < szinek.Length - 1)
                        valasztottSzin++;
                    break;
                case ConsoleKey.Enter:
                    aktualisSzinIndex = valasztottSzin;
                    aktualisSzin = szinek[aktualisSzinIndex];
                    szinKivalasztva = true;
                    break;
            }

            
            Console.Clear();
            Console.WriteLine("Nyílbillentyűkkel válassz egy színt, majd nyomj Enter-t:");
        }

        
        Console.Clear();
        Console.WriteLine("Rajzoláshoz használd a nyílbillentyűket. Színválasztáshoz nyomd meg a 'C' billentyűt.");
    }
}
