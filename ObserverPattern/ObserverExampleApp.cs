using System;

namespace ObserverPattern;

class ObserverExampleApp
{
    static void Main(string[] args)
    {
        MealPrices prices = new MealPrices();
        MealPriceView view = new MealPriceView(prices);
        view.Update();
        prices.Attach(view);

        ShowCommands();
        Console.ForegroundColor = ConsoleColor.White;
        string[] tokens;
        string command;
        command = AskUser("Command: ");
        while (command.ToLower() != "x")
        {
            tokens = command.Split(' ');
            if (tokens[0].ToLower() == "b")
            {
                prices.BreakfastPrice += Convert.ToDecimal(tokens[1]);
            }
            else if (tokens[0].ToLower() == "l")
            {
                prices.LunchPrice += Convert.ToDecimal(tokens[1]);
            }
            else if (tokens[0].ToLower() == "d")
            {
                prices.DinnerPrice += Convert.ToDecimal(tokens[1]);
            }
            command = AskUser("Command: ");
        }
    }

    static string AskUser(string prompt)
    {
        Console.SetCursorPosition(40, 10);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("+--------------------------------+");
        Console.SetCursorPosition(40, 11);
        Console.Write("|                                |");
        Console.SetCursorPosition(40, 12);
        Console.Write("+--------------------------------+");
        Console.SetCursorPosition(42, 11);
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static void ShowCommands()
    {
        Console.SetCursorPosition(5, 10);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("+--------------------------------+");
        Console.SetCursorPosition(5, 11);
        Console.Write("| COMMANDS                       |");
        Console.SetCursorPosition(5, 12);
        Console.Write("| b <price>                      |");
        Console.SetCursorPosition(5, 13);
        Console.Write("| l <price>                      |");
        Console.SetCursorPosition(5, 14);
        Console.Write("| d <price>                      |");
        Console.SetCursorPosition(5, 15);
        Console.Write("+--------------------------------+");
    }
}
