using System;
using System.IO;

namespace lab03_wordgame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../WordFile.txt";
            CreateFile(path);
            Console.WriteLine("Welcome to the Word Guessing game");
            MainMenuSelection();
            Console.ReadLine(); //so prog doesn't auto quit
        }

        //sets up default word list
        private static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                //default word list
                streamWriter.WriteLine("SEATTLE");
                streamWriter.WriteLine("BAT");
                streamWriter.WriteLine("WASHINGTON");
                streamWriter.WriteLine("FIDDLE");
                streamWriter.WriteLine("SQUASH");
                streamWriter.WriteLine("MISSISSIPPI");
                streamWriter.WriteLine("SCIENTIST");
                streamWriter.WriteLine("TEN");
                streamWriter.WriteLine("CLASS");
                streamWriter.WriteLine("STUDENT");
            }
        }

        private static string[] ReadFile(string path)
        {
            string[] linesFromFile = File.ReadAllLines(path);
            //for (int i = 0; i < linesFromFile.Length; i++)
            //{
            //    Console.WriteLine(linesFromFile[i]);
            //}
            return linesFromFile;
        }

        private static void PrintFile(string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private static void AddWordToFile(string path)
        {
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                Console.WriteLine("What word would you like to add to the list?");
                string userChoice = Console.ReadLine();
                string userChoiceCap = userChoice.ToUpper();
                streamWriter.WriteLine(userChoiceCap);
            }
        }

        //show main menu
        public static void MainMenuSelection()
        {
            bool loopMainMenu = true;
            try
            {
                do
                {
                    Console.WriteLine("Make a selection");
                    Console.WriteLine("1: Start a new game");
                    Console.WriteLine("2: Admin");
                    Console.WriteLine("3: Exit");
                    string userChoice = Console.ReadLine();
                    int userChoiceInt = Convert.ToInt32(userChoice);

                    if (userChoiceInt > 3)
                    {
                        Console.WriteLine("That isn't an option");
                        loopMainMenu = true;
                    }
                    else if (userChoiceInt < 0)
                    {
                        Console.WriteLine("That isn't an option");
                        loopMainMenu = true;
                    }
                    else
                    {
                        switch (userChoiceInt)
                        {
                            case 1: //Start
                                Game();
                                loopMainMenu = false;
                                break;
                            case 2: //Admin
                                AdminMenuSelection();
                                loopMainMenu = false;
                                break;
                            default: // exit
                                Console.WriteLine("just for testing, in option 3");
                                Console.ReadLine();
                                loopMainMenu = false;
                                Environment.Exit(0);
                                break;
                        }
                    }
                } while (loopMainMenu == true);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You didn't make an entry. Try again.");
                MainMenuSelection();
            }
            catch (FormatException)
            {
                Console.WriteLine("There was an error reading your input, RESTART");
                MainMenuSelection();
            }
            catch (Exception) //general
            {
                Console.WriteLine("Something went wrong");
            }
        }

        //show admin menu
        public static void AdminMenuSelection()
        {
            bool loopAdminMenu = true;
            try
            {
                do
                {
                    Console.WriteLine("Make a selection");
                    Console.WriteLine("1: View word list");
                    Console.WriteLine("2: Add a word");
                    Console.WriteLine("3: Delete a word");
                    Console.WriteLine("4: Go Back to Main Menu");
                    string userChoice = Console.ReadLine();
                    int userChoiceInt = Convert.ToInt32(userChoice);

                    if (userChoiceInt > 4)
                    {
                        Console.WriteLine("That isn't an option");
                        loopAdminMenu = true;
                    }
                    else if (userChoiceInt < 0)
                    {
                        Console.WriteLine("That isn't an option");
                        loopAdminMenu = true;
                    }
                    else 
                    {
                        switch (userChoiceInt)
                        {
                            case 1: //view list
                                string[] listView = ReadFile("../../../WordFile.txt");
                                PrintFile(listView);
                                break;
                            case 2: //add a word
                                AddWordToFile("../../../WordFile.txt");
                                Console.WriteLine("Confirmed added to list");

                                break;
                            case 3: //delete a word
                                //Console.WriteLine("just for testing, in option 3");
                                //might be able to move this to a function later
                                string[] listDeleteWord = ReadFile("../../../WordFile.txt");
                                PrintFile(listDeleteWord);
                                Console.WriteLine("What word would you like to delete?");
                                string userDeleteChoice = Console.ReadLine();
                                string userDeleteChoiceCap = userDeleteChoice.ToUpper();
                                //need to check word is in the list, if yes, delete, else reask for word to delete or exit and say did nothing.
                                string[] listRevised = new string[listDeleteWord.Length-1]; 
                                //because of how I set up the IF, I actually try to fill in more indexes than I have (because new is one less
                                //for (int i = 0; i < listDeleteWord.Length; i++)
                                //{
                                //    Console.WriteLine("made it to for loop");
                                //    Console.WriteLine("============ i ==========" + i);
                                //    if (listDeleteWord[i] != userDeleteChoiceCap)
                                //    {
                                //        Console.WriteLine("in if when word not match");
                                //        listRevised[i] = listDeleteWord[i];
                                //    }
                                //    else if (listDeleteWord[i] == userDeleteChoiceCap)
                                //    {
                                //        Console.WriteLine("in if when word match");
                                //        //for now I will just might have a blank space in my list
                                //        listRevised[i] = "deleted word spot";
                                //    }
                                //    else //i don't get to this situation
                                //    {
                                //        Console.WriteLine("in if when word not in list");
                                //        //word isn't in list
                                //        Console.WriteLine("You chose a word not in the list, we have exited without taking any actions.");
                                //        //AdminMenuSelection();

                                //    }
                                //}
                                Console.WriteLine("Confirmed deleted from list");
                                break;
                            default: // go back to main menu
                                //Console.WriteLine("just for testing, in option 4");
                                MainMenuSelection();
                                //Environment.Exit(0);
                                break;
                        }
                    }
                } while (loopAdminMenu == true);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You didn't make an entry. Try again.");
                AdminMenuSelection();
            }
            catch (FormatException)
            {
                Console.WriteLine("There was an error reading your input, please try again.");
                AdminMenuSelection();
            }
            catch (Exception) //general
            {
                Console.WriteLine("Something went wrong");
            }
        }
        
        public static int RandomNum(int topRange)
        {
            Random rand = new Random();
            return rand.Next(topRange); //verified random numbers are generating
        }

        //public static string[] TrackLetters(string[] arr, string guess)
        //{
        //    string[] guessArr = new string[26]; //only 26 letters in alphabet
        //}

        private static void printArray(char[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write(arr[k] + " ");
            }
        }

        private static void Game()
        {
            //read file
            string[] gameList = ReadFile("../../../WordFile.txt");
            //using random function (range of readarray length) to pick a number/word from list
            int gameWordIndex = RandomNum(gameList.Length);
            string gameWord = gameList[gameWordIndex];

            //convert the word to a char array
            char[] gameWordChar = gameWord.ToCharArray(); //this is the answer key
            char[] gameWordGuessChar = new char[gameWordChar.Length]; //this is the array user will see

            //fill in what user will see for word with _
            for (int i = 0; i < gameWordGuessChar.Length; i++)
            {
                gameWordGuessChar[i] = Convert.ToChar("_");
            }
            //printArray(gameWordGuessChar);
            //Console.WriteLine();


            //new array to hold user's guesses
            char[] userLetterGuessesSoFar = new char[26]; // only 26 letters in alphabet
            //set up for do while
            //bool gameSolved = false;
            bool gameSolved = false;
            int guessCounter = 0;

            do
            {
                gameSolved = CheckedForWinner(gameWordChar, gameWordGuessChar);
                //check if word matches otherwise do the rest of this loop
                if (gameSolved == true)
                {
                    printArray(gameWordGuessChar);
                    Console.WriteLine();
                    bool playAgainBoolLoop = true;
                    Console.WriteLine("Congrats you won!!!");
                    try
                    {
                        do
                        {
                            Console.WriteLine("Would you like to play again?");
                            Console.WriteLine("1: Yes please");
                            Console.WriteLine("2: No thank you");
                            string userPlayChoice = Console.ReadLine();
                            int userPlayChoiceInt = Convert.ToInt32(userPlayChoice);
                            if (userPlayChoiceInt > 2)
                            {
                                Console.WriteLine("That isn't an option");
                                playAgainBoolLoop = true;
                            }
                            else if (userPlayChoiceInt < 0)
                            {
                                Console.WriteLine("That isn't an option");
                                playAgainBoolLoop = true;
                            }
                            else
                            {
                                switch (userPlayChoiceInt)
                                {
                                    case 1: //Yes
                                        playAgainBoolLoop = false;
                                        Game();
                                        break;
                                    case 2: //No
                                        Environment.Exit(0);
                                        break;
                                }
                            }
                        } while (playAgainBoolLoop == true);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("You didn't make an entry. Try again.");
                        AdminMenuSelection();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("There was an error reading your input, please try again.");
                        AdminMenuSelection();
                    }
                    catch (Exception) //general
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                else
                {
                    Console.WriteLine("Word you are trying to guess: ");
                    printArray(gameWordGuessChar);
                    Console.WriteLine(); //just because I like space
                    Console.WriteLine("Letters you have guessed so far: ");
                    printArray(userLetterGuessesSoFar);
                    Console.WriteLine(); //just because I like space
                                         //ask user for a letter guess
                    Console.WriteLine("Guess a letter?");
                    string userLetterGuess = Console.ReadLine();
                    string userLetterGuessCap = userLetterGuess.ToUpper();
                    char userLetterGuessChar = Convert.ToChar(userLetterGuessCap);

                    //check if the letter is in the word
                    bool letterInWord = gameWord.Contains(userLetterGuessCap);
                    //walk through word array and if letter matches print letter, else _
                    if (letterInWord == true)
                    {
                        for (int j = 0; j < gameWordChar.Length; j++)
                        {
                            if (gameWordChar[j] == userLetterGuessChar)
                            {
                                gameWordGuessChar[j] = userLetterGuessChar;
                                //userLetterGuessesSoFar[guessCounter] = userLetterGuessChar;
                                //guessCounter++;
                            }
                        }
                    }
                    userLetterGuessesSoFar[guessCounter] = userLetterGuessChar;
                    guessCounter++;
                }
            } while (gameSolved == false);


            //if game solved true then say congrats and something for if they want to play again
            //need to figure out where to add their guess to the array

            //check if user input was a letter and a letter they haven't guessed before
            //check if letter is in the word if yes display letter else _
            //ask for another until word == word
            //then ask if want to play again
            //currently it doesn't verify they are guessing ONlY letters
            //poss solution is an array of 26 letters that we compare against, but it doesn't stop them from guessing a 10 times over
            //unless i remove it from the array as they guess...

        }
        private static bool CheckedForWinner(char[] correctWord, char[] testWord)
        {
            bool answerToReturn = true;
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (correctWord[i] != testWord[i])
                {
                    answerToReturn = false;
                    break;
                }
            }
            Console.WriteLine("===========" + answerToReturn);
            return answerToReturn;
        }
    }
}

