using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        // Create a variable lowNumber == 1 and variable highNumber == 1024.
        // Create a variable called newGuess set it equal to (lowNumber+highNumber)/2.
        static int lowNumber = 1;
        static int highNumber = 1024;
        static int newGuess = (lowNumber + highNumber) / 2;
        static string userInput = "";
        static int guessCounter = 0;
        static int gameCount = 0;

        // Create ShowGreeting method that tells user to think of a number between 1 and 1024.
        static void ShowGreeting()
        {
            Console.WriteLine("Welcome to the Guessing Game!");
        }

        static void BragWhenCorrect()
        {
            Console.WriteLine("See! I told you I'd get it right!");
        }

        static void ComputeNewLowIfTooLow()
        {
            lowNumber = newGuess;
            newGuess = (highNumber + lowNumber) / 2;
        }

        static void ComputeNewHighIfTooHigh()
        {
            highNumber = newGuess;
            newGuess = (highNumber + lowNumber) / 2;
        }

        static string PromptForString()
        {
            Console.WriteLine($"Is your number {newGuess}? Answer higher, lower, or correct. ");
            userInput = Console.ReadLine();
            return userInput;
        }

        static void PlayAgain()
        {
            ShowGreeting();

            Console.WriteLine("Think of a number greater than 1. Now tell me a number that's higher than the number you're thinking of. ");

            highNumber = Int32.Parse(Console.ReadLine());

            newGuess = (lowNumber + highNumber) / 2;
            guessCounter = 0;

            PromptForString();

            while (userInput != "correct")
            {
                // PromptForString();
                if (userInput == "higher")
                {
                    ComputeNewLowIfTooLow();
                    guessCounter = guessCounter + 1;
                    PromptForString();
                }
                else if (userInput == "lower")
                {
                    ComputeNewHighIfTooHigh();
                    guessCounter = guessCounter + 1;
                    PromptForString();
                }
                else
                {
                    Console.WriteLine("Please enter a valid answer: higher, lower, or correct.");
                    PromptForString();
                }
            }
            BragWhenCorrect();
            guessCounter = guessCounter + 1;
        }

        static void Main(string[] args)
        {
            var guessesList = new List<int>();
            int sumGuesses = 0;
            Console.WriteLine("Would you like to play a number guessing game? yes or no?");
            while (Console.ReadLine() != "no")
            {
                PlayAgain();
                guessesList.Add(guessCounter);
                gameCount = gameCount + 1;
                Console.WriteLine($"It took me {guessCounter} tries!");
                Console.WriteLine("Would you like to play again? yes or no?");
            }

            for (var guess = 0; guess < guessesList.Count; guess++)
            {
                sumGuesses = sumGuesses + guessesList[guess];
            }
            int averageGuesses = sumGuesses / guessesList.Count;
            Console.WriteLine($"I averaged {averageGuesses} guesses to get the correct answer!");
        }
    }
}

/*

Adventure Mode

    Allow the user to choose the maximum number for their range.
    Tell them the most number of guesses your code will need!
    Prompt the user to play again at the end of the game.

    Keep track of how many guesses each game has taken and show the average number of guesses your code has used. 
    For instance, if you've played three games and took 4, 6, and 2 guesses, your average would be 4.


Algorithm: 


Set guessCounter = 0.
A loop that Display newGuess and ask user if number is higher or lower than the guess until "correct"
Create ComputeNewLowIfTooLow method that assigns the highNumber equal to the newGuess. ComputeNewLowIfTooLow {
            highNumber = newGuess;
            newGuess = (highNumber+lowNumber)/2;
        }
Create ComputeNewLowIfTooLow method that assigns the lowNumber equal to the newGuess. ComputeNewLowIfTooLow {
            lowNumber = newGuess;
            newGuess = (highNumber+lowNumber)/2;
Create notValidInput that returns "That's not a good input. Say higher, lower, or correct.
Create BragWhenCorrect method that returns "I told you I'd get it!".





*/