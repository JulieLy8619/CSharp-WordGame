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
            MainMenuSelection();
            //CreateFile(path); //create the file when they choose to play a game
            //ReadFile(path); // when in admin and want to see the word list
            //AddWordToFile(path);
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
            for (int i = 0; i < linesFromFile.Length; i++)
            {
                Console.WriteLine(linesFromFile[i]); //just for testing for now
            }
            return linesFromFile;
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

                    if (userChoiceInt > 4)
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
                Console.WriteLine("There was an error reading your input, please try again.");
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
                                string[] list = ReadFile("../../../WordFile.txt");

                                break;
                            case 2: //add a word
                                AddWordToFile("../../../WordFile.txt");
                                Console.WriteLine("Confirmed added to list");

                                break;
                            case 3: //delete a word
                                Console.WriteLine("just for testing, in option 3");
                                Console.WriteLine("Confirmed deleted from list");
                                break;
                            default: // exit
                                Console.WriteLine("just for testing, in option 4");
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

        private static void Game()
        {
            //create list
            //read file
            //using random function (range of readarray length) to pick a number/word from list
            //display _ for length of word
            //ask user for a letter guess
            //check if letter is in the word if yes display letter else _
            //ask for another until word == word
            //then ask if want to play again, which recalls this function or go back to main menu
        }

                //public static int Test(int num)
                //{
                //    return num;
                //}
    }
}
