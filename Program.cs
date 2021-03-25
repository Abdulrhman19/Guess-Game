using System;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guessing Game");

            var number = new Random();
            // level specified by the user.
            int level = 0;

            // range based on level
            int range = 0;

            // flag for game status
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Select difficulty level");
                Console.WriteLine("\t1- Easy");
                Console.WriteLine("\t2- Intermediate");
                Console.WriteLine("\t3- Pro");
                Console.Write("Level: ");
                level = int.Parse(Console.ReadLine());

                // pass by 'ref' to be able to change its value from other functions
                setLevelValue(ref level);

                if (validateLevel(level))
                {
                    // it mean's that level is true;
                    range = setRange(level);
                    int randInt = number.Next(1, range + 1); // 1, 50
                    bool winner = true;
                    while (winner)
                    {
                        Console.Write("Guess a number between 0 and {0}: ", range);
                        int guessedNumber = int.Parse(Console.ReadLine());
                        if (isWin(guessedNumber, randInt))
                        {
                            winner = false;
                        }
                        else
                        {
                            Console.WriteLine("try again");
                        }
                    }
                }
                else
                {
                    continue;
                }

                Console.Write("Would you like to play again [y/n]? ");
                char answer = char.Parse(Console.ReadLine().ToLower());
                if (answer == 'y')
                {
                    continue;
                }
                else if (answer == 'n')
                {
                    Console.WriteLine("Good luck");
                    flag = false;
                }
            }
        }

        static void setLevelValue(ref int level)
        {
            if (level < 1 || level > 3)
            {
                Console.WriteLine("{0} is out of range! please try again.", level);
                // Reset 'range' to 0
                level = 0;
            }
        }

        static bool validateLevel(int level)
        {
            if (level >= 1 && level <= 3)
            {
                return true;
            }
            return false; // otherwise

        }

        static int setRange(int level)
        {
            int range = 0;
            switch (level)
            {
                case 1:
                    range = 25;
                    break;
                case 2:
                    range = 50;
                    break;
                default:
                    range = 100;
                    break;
            }
            return range;
        }


        static bool isWin(int guessedNumber, int randInt)
        {
            if (randInt > guessedNumber)
            {
                Console.WriteLine("{0} is to low, try higher.", guessedNumber);
                return false;
            }
            else if (randInt < guessedNumber)
            {
                Console.WriteLine("{0} is to high, try lower.", guessedNumber);
                return false;
            }
            else
            {
                Console.WriteLine("You got it. Congratulations.");
                return true;
            }
        }
    }
}
