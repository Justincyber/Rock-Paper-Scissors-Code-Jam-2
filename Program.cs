using System;

class Program
{
    // ANSI color codes
    public const string Red = "\x1b[31m";
    public const string Green = "\x1b[32m";
    public const string Yellow = "\x1b[33m";
    public const string Reset = "\x1b[0m";

    static void Main()
    {
        Console.Clear();
        Console.WriteLine($"{Red}Welcome to JM Family Rock Paper Scissors where if you lose you Die! {Reset}");



        // Display options
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Paper");
        Console.WriteLine("3. Scissors");

        int userChoice = GetUserChoice();
        int computerChoice = new Random().Next(1, 4);

        Console.WriteLine($"{Green}\nYou chose: {GetChoiceString(userChoice)}{Reset}");
        Console.WriteLine($"{Yellow}Computer chose: {GetChoiceString(computerChoice)}{Reset}");

        string result = DetermineWinner(userChoice, computerChoice);
        Console.WriteLine($"{Yellow}\n{result}{Reset}");

        Console.WriteLine($"{Yellow}Press Enter to exit.{Reset}");
        Console.ReadLine();
    }

    static int GetUserChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
            {
                return choice;
            }
            Console.WriteLine($"{Red}Invalid choice. Please enter a number between 1 and 3.{Reset}");
        }
    }

    static string GetChoiceString(int choice)
    {
        return choice switch
        {
            1 => "Rock 🪨",
            2 => "Paper",
            3 => "Scissors",
            _ => "Unknown"
        };
    }

    static string DetermineWinner(int userChoice, int computerChoice)
    {
        if (userChoice == computerChoice) return "It's a draw!";
        if ((userChoice == 1 && computerChoice == 3) ||
            (userChoice == 2 && computerChoice == 1) ||
            (userChoice == 3 && computerChoice == 2))
        {
            return "You win!";
        }
        return "You lose!";
    }
}
