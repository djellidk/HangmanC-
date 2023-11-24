using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Program
    {
        //main method
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman !");

            //Choose a word
            Console.WriteLine("Enter the word to be guessed : ");
            string wordToGuess = Console.ReadLine().ToUpper();//convert small letter to capital

            char[] guessedWord = new char[wordToGuess.Length];
            for(int i=0; i<wordToGuess.Length; i++)
            {
                guessedWord[i] = '_';
            }

            List<char> guessedLetters = new List<char>();
            int attemptsLeft = 6;

            while (true)
            {
                DisplayWord(guessedWord);

                Console.WriteLine("\nAttempts left: "+attemptsLeft);

                Console.WriteLine("\nGuess a letter: ");
                char guess = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine("");

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter. Try again.");
                    continue;
                }

                guessedLetters.Add(guess);

                if (wordToGuess.Contains(guess))
                {
                    Console.WriteLine("\nGood guess!");
                    UpdateGuessedWord(wordToGuess, guessedWord, guess);
                }
                else
                {
                    Console.WriteLine("\nIncorrect guess!");
                    attemptsLeft--;
                }

                if (attemptsLeft != 6)
                {
                    Console.WriteLine("___");
                    Console.WriteLine("   |");
                    switch (attemptsLeft)
                    {       
                        case 5:
                            Console.WriteLine("   O");
                            break;
                        case 4:
                            Console.WriteLine("   O");
                            Console.WriteLine("   |");
                            break;
                        case 3:
                            Console.WriteLine("   O");
                            Console.WriteLine("  /|");
                            break;
                        case 2:
                            Console.WriteLine("   O");
                            Console.WriteLine("  /|\\");
                            break;
                        case 1:
                            Console.WriteLine("   O");
                            Console.WriteLine("  /|\\");
                            Console.WriteLine("  /");
                            break;
                        case 0:
                            Console.WriteLine("   O");
                            Console.WriteLine("  /|\\");
                            Console.WriteLine("  / \\");
                            break;
                        default:
                            break;
                    }
                }

                if(attemptsLeft == 0)
                {
                    Console.WriteLine("\nGame over! The word was :" + wordToGuess);
                    break;
                }
                
                if(wordToGuess.Equals(string.Join("", guessedWord)))
                {
                    Console.WriteLine("\nCongradulations! You guessed the word: " + wordToGuess);
                    break;
                }
            }
            Console.ReadKey();
        }

        //method that displays the word found
        static void DisplayWord(char[] word)
        {
            Console.Write("Word: ");
            foreach (char letter in word)
            {
                Console.Write(letter + " ");
            }
        }

        //method that Update the guessed word
        static void UpdateGuessedWord(string wordToGuess, char[] guessedWord, char guess)
        {
            for(int i=0; i<wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guess)
                {
                    guessedWord[i] = guess;
                }
            }
        }
    }
}
