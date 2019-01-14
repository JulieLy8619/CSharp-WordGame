using System;
using System.IO;

namespace lab03_wordgame
{
    public class Program
    {
        /// <summary>
        /// main program that starts it off
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = "../../../WordFile.txt";
            CreateFile(path);
            Console.WriteLine("Welcome to the Word Guessing game");
            MainMenuSelection();
            Console.ReadLine(); //so prog doesn't auto quit
        }

        //sets up default word list
        /// <summary>
        /// Creates the file of default words
        /// </summary>
        /// <param name="path">Path where one wants to save the file</param>
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

        /// <summary>
        /// read words from file
        /// </summary>
        /// <param name="path">path where file is located</param>
        /// <returns>returns an array of the words from the file</returns>
        private static string[] ReadFile(string path)
        {
            string[] linesFromFile = File.ReadAllLines(path);
            return linesFromFile;
        }

        /// <summary>
        /// prints words to screen(console) 
        /// </summary>
        /// <param name="list">takes in an array of words</param>
        private static void PrintFile(string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        /// <summary>
        /// adds a word to the file
        /// </summary>
        /// <param name="path">path of the file location</param>
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

        /// <summary>
        /// deletes word from file
        /// </summary>
        /// <param name="path">needs location of file to read</param>
        private static void DeleteWordFromFile(string path)
        {
            string[] listDeleteWord = ReadFile("../../../WordFile.txt");
            PrintFile(listDeleteWord);
            Console.WriteLine("What word would you like to delete?");
            string userDeleteChoice = Console.ReadLine();
            string userDeleteChoiceCap = userDeleteChoice.ToUpper();
            string[] listRevised = new string[listDeleteWord.Length];
            for (int i = 0; i < listDeleteWord.Length; i++)
            {
                //Console.WriteLine("made it to for loop");
                if (listDeleteWord[i] != userDeleteChoiceCap)
                {
                    listRevised[i] = listDeleteWord[i];
                }
                else if (listDeleteWord[i] == userDeleteChoiceCap)
                {
                    listRevised[i] = "======Deleted Word Spot======";
                }
                else //I don't seem to hit this ELSE
                {
                    //word isn't in list
                    Console.WriteLine("You chose a word not in the list, we have exited without taking any actions.");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                }
            }

            //this should write over the old file with the new file with the revised list of words
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                for (int j = 0; j < listRevised.Length; j++)
                {
                    streamWriter.WriteLine(listRevised[j]);
                }
            }
            Console.WriteLine("Revised list:  (if you selected a word from the list)");
            for (int k = 0; k < listRevised.Length; k++)
            {
                Console.WriteLine(listRevised[k]);
            }
        }

        //show main menu
        /// <summary>
        /// shows the opening menu
        /// </summary>
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
        /// <summary>
        /// shows the admin menu
        /// </summary>
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
                                DeleteWordFromFile("../../../WordFile.txt");
                                break;
                            default: // go back to main menu
                                MainMenuSelection();
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
        
        /// <summary>
        /// generates a random number
        /// </summary>
        /// <param name="topRange">takes in ceiling of range to pick a random number from 0 to ceiling</param>
        /// <returns>returns the random number</returns>
        public static int RandomNum(int topRange)
        {
            Random rand = new Random();
            return rand.Next(topRange);
        }

        /// <summary>
        /// prints word to screen
        /// </summary>
        /// <param name="arr">takes in an array of letters that make up the word</param>
        private static void printArray(char[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write(arr[k] + " ");
            }
        }

        /// <summary>
        /// this is THE game, it will pick the word, it will continuously ask the user for letters until puzzle is solved then ask if they want to play again or not
        /// </summary>
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

            //new array to hold user's guesses
            char[] userLetterGuessesSoFar = new char[26]; // only 26 letters in alphabet
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
                            }
                        }
                    }
                    userLetterGuessesSoFar[guessCounter] = userLetterGuessChar;
                    guessCounter++;
                }
            } while (gameSolved == false);
        }

        /// <summary>
        /// checks for a winner in the game
        /// </summary>
        /// <param name="correctWord">needs to know what is the right word</param>
        /// <param name="testWord">needs to know what word the user has guessed</param>
        /// <returns>true or false for if the user is a winner</returns>
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
            return answerToReturn;
        }
    }
}


//currently it doesn't verify they are guessing ONlY letters
//poss solution is an array of 26 letters that we compare against, but it doesn't stop them from guessing a 10 times over
//unless i remove it from the array as they guess...
