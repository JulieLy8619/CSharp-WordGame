using System;
using System.IO;

namespace lab03_wordgame
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../WordFile.txt";
            MainMenuSelection();
            //CreateFile(path); //create the file when they choose to play a game
            //ReadFile(path); // when in admin and want to see the word list
            Console.ReadLine(); //so prog doesn't auto quit
        }

        //sets up default word list
        private static void CreateFile(string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                //defaul word list
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

        private static void ReadFile(string path)
        {
            string[] linesFromFile = File.ReadAllLines(path);
            for (int i = 0; i < linesFromFile.Length; i++)
            {
                Console.WriteLine(linesFromFile[i]);
            }
        }

        private static void AppendToFile(string path)
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
            Console.WriteLine("Make a selection");
            Console.WriteLine("1: Start a new game");
            Console.WriteLine("2: Admin");
            Console.WriteLine("3: Exit");
            try
            {
                string userChoice = Console.ReadLine();
                int userChoiceInt = Convert.ToInt32(userChoice);

                if (userChoiceInt > 4)
                {
                    Console.WriteLine("That isn't an option");
                    MainMenuSelection();
                }
                else if (userChoiceInt < 0)
                {
                    Console.WriteLine("That isn't an option");
                    MainMenuSelection();
                }
                else //couldnt do while loop because I could enter bad code on first entry
                {
                    switch (userChoiceInt)
                    {
                        case 1: //Start
                            Console.WriteLine("just for testing, in option 1");
                            break;
                        case 2: //Admin
                            Console.WriteLine("just for testing, in option 2");
                            AdminMenuSelection();
                            break;
                        default: // exit
                            Console.WriteLine("just for testing, in option 3");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                    }
                }
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
            Console.WriteLine("Make a selection");
            Console.WriteLine("1: View word list");
            Console.WriteLine("2: Add a word");
            Console.WriteLine("3: Delete a word");
            Console.WriteLine("4: Exit Admin");
            try
            {
                string userChoice = Console.ReadLine();
                int userChoiceInt = Convert.ToInt32(userChoice);

                if (userChoiceInt > 4)
                {
                    Console.WriteLine("That isn't an option");
                    AdminMenuSelection();
                }
                else if (userChoiceInt < 0)
                {
                    Console.WriteLine("That isn't an option");
                    AdminMenuSelection();
                }
                else //couldnt do while loop because I could enter bad code on first entry
                {
                    switch (userChoiceInt)
                    {
                        case 1: //view list
                            Console.WriteLine("just for testing, in option 1");
                            break;
                        case 2: //add a word
                            Console.WriteLine("just for testing, in option 2");
                            break;
                        case 3: //delete  word
                            Console.WriteLine("just for testing, in option 3");
                            break;
                        default: // exit
                            Console.WriteLine("just for testing, in option 4");
                            Console.ReadLine();
                            MainMenuSelection();
                            //Environment.Exit(0);
                            break;
                    }
                }
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


                //public static int Test(int num)
                //{
                //    return num;
                //}
    }
}
