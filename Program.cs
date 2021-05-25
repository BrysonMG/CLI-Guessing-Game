using System;
using System.Threading;

void Main()
{
    string SecretNumber = new Random().Next(1, 101).ToString();
    int TriesLeft = 4;
    bool UsedHint = false;

    Console.Clear();
    Console.WriteLine(@"
    Guessing Game
    -------------

    Choose your difficulty setting:
    1) Easy
    2) Medium
    3) Hard
    4) Cheater
    ");
    string Difficulty = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(Difficulty))
    {
        Console.WriteLine("Exiting...");
        Environment.Exit(0);
    }
    else if (Difficulty != "1" && Difficulty != "2" && Difficulty != "3" && Difficulty != "4")
    {
        Console.Clear();
        Console.WriteLine("Pick a valid response...");
        Thread.Sleep(1500);
        Main();
    }
    else
    {
        if (Difficulty == "1")
        {
            TriesLeft = 8;
        }
        else if (Difficulty == "2")
        {
            TriesLeft = 6;
        }
        else if (Difficulty == "3")
        {
            TriesLeft = 4;
        }
        else if (Difficulty == "4")
        {
            TriesLeft = 9999;
        }
    }

    Console.Clear();
    Console.WriteLine("I want you to guess a secret number between 1 and 100.");
    Console.WriteLine();
    while (TriesLeft > 0)
    {
        Console.WriteLine($"Attempts Remaining: {TriesLeft}");
        Console.WriteLine();
        Console.Write("What is your guess? - ");
        string Guess = Console.ReadLine();

        bool OnlyContainsDigits(string CheckMe)
        {
            foreach (char x in CheckMe)
            {
                if (!char.IsDigit(x))
                {
                    return false;
                }
            }
            return true;
        };

        if (string.IsNullOrWhiteSpace(Guess))
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }

        if (Guess.ToLower() == "hint")
        {
            Console.Clear();
            Console.WriteLine($"The secret number is: {SecretNumber}");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"You guessed: {Guess}");
            Thread.Sleep(2000);
            Console.Clear();
        }

        if (SecretNumber == Guess)
        {
            if (UsedHint || Difficulty == "4")
            {
                Console.WriteLine("Of course you would win, you dirty cheater...");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Get out of my sight.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Hey, you got it right! Great Job!");
                Environment.Exit(0);
            }
        }
        else if (Guess == "hint")
        {
            Console.Clear();
            Console.WriteLine("Go ahead and 'guess'... cheater.");
            UsedHint = true;
        }
        else if (!OnlyContainsDigits(Guess)) //If user's Guess has anything other than numbers, this section runs
        {
            Console.WriteLine("Please guess with a positive whole number, not with... whatever that was...");
            Thread.Sleep(2000);
        }
        else if (int.Parse(Guess) > 100 || int.Parse(Guess) < 1)
        {
            Console.WriteLine("I told you the number was between 1 and 100...");
            Thread.Sleep(2000);
            Console.WriteLine("If you want to waste an attempt being cheeky or bad with numbers, so be it.");
            TriesLeft--;
            Thread.Sleep(2000);
        }
        else
        {
            string HiLow = string.Empty;

            if (int.Parse(Guess) > int.Parse(SecretNumber))
            {
                HiLow = "lower";
            }
            else
            {
                HiLow = "higher";
            }

            Console.WriteLine($"I'm sorry, that's incorrect. The secret number is {HiLow} than your guess.");
            TriesLeft--;
            Thread.Sleep(2500);
            Console.Clear();
        }
    }
    Console.WriteLine($"Attempts Remaining: {TriesLeft}");
    Console.WriteLine();
    Console.WriteLine("I'm sorry, you ran out of tries...");
    Console.WriteLine("GAME OVER");
    Environment.Exit(0);
}

Main();


