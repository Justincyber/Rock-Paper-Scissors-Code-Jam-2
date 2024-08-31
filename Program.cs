using System;
using System.Globalization;

class Program
{
    // ANSI color codes
    public const string Red = "\x1b[31m";
    public const string Green = "\x1b[32m";
    public const string Yellow = "\x1b[33m";
    public const string Reset = "\x1b[0m";

    // I think the code is modularized well since you put different functionalities in different methods
    static void Main()
    {
        // to make the project more fun, I changed the background color of the console
        // in additon, I added some ascii art to the welcome message
        System.Console.BackgroundColor = ConsoleColor.DarkCyan;
        Console.Clear();


        string welcomeMessage = @"
        █▀█ █▀█ █▀▀ █▄▀  
        █▀▄ █▄█ █▄▄ █░█  

        █▀█ ▄▀█ █▀█ █▀▀ █▀█  
        █▀▀ █▀█ █▀▀ ██▄ █▀▄  

        █▀ █▀▀ █ █▀ █▀ █▀█ █▀█ █▀
        ▄█ █▄▄ █ ▄█ ▄█ █▄█ █▀▄ ▄█";

        Console.WriteLine(welcomeMessage);


        Console.WriteLine($"{Red}Welcome to JM Family Rock Paper Scissors where if you lose you Die! {Reset}");

        // Display options
        Console.WriteLine("1. Rock");
        Console.WriteLine("2. Paper");
        Console.WriteLine("3. Scissors");

        int userChoice = GetUserChoice();
        int computerChoice = new Random().Next(1, 4);

        // the text where it says what you and the computer chose had question marks after it
        // if you chose rock due to the rock emoji which rendered as unknown character
        Console.WriteLine($"{Green}\nYou chose: {GetChoiceString(userChoice)}{Reset}");
        Console.WriteLine($"{Yellow}Computer chose: {GetChoiceString(computerChoice)}{Reset}");

        string result = DetermineWinner(userChoice, computerChoice);
        Console.WriteLine($"{Yellow}\n{result}{Reset}");

        Console.WriteLine($"{Yellow}Press Enter to exit.{Reset}");
        Console.ReadLine();
    }

    // I refactored this function to be in a try catch block to handle invalid inputs
    // it is more lines of code but might be easier to understand
    static int GetUserChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 3)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine($"{Red}Invalid choice. Please enter a number between 1 and 3.{Reset}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"{Red}Invalid choice. Please enter a valid number.{Reset}");
            }
        }
    }

    // I added ascii art to the choices to make the game have more designs
    static string GetChoiceString(int choice)
    {

        string rockArt = @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)";

string paperArt = @"
    _______
---'   ____)____
          ______)
          _______)
         _______)
---.__________)
";

        string scissorsArt = @"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)";

        // the rock emoji placed after the rock string rendered as question marks, so I removed it
        // in addition, I added new line characters to seperate the text from ascii art
        return choice switch
        {
            1 => "Rock" + "\n" + rockArt + "\n",
            2 => "Paper" + "\n" + paperArt + "\n",
            3 => "Scissors" + "\n" + scissorsArt + "\n",
            _ => "Unknown"
        };
    }

    // to improve readability here, I added constants for choices
    static string DetermineWinner(int userSelection, int computerSelection)
    {
        if (userSelection == computerSelection)
        {
            return "It's a draw!";
        }

        const int Rock = 1;
        const int Paper = 2;
        const int Scissors = 3;

        // this improves readability since you can see the choice names instead of numbers
        if ((userSelection == Rock && computerSelection == Scissors) ||
            (userSelection == Paper && computerSelection == Rock) ||
            (userSelection == Scissors && computerSelection == Paper))
        {
            return "You win!";
        }

        // if none of the above conditions are met, the user loses
        return "You lose!";
    }
}
