using System;
using System.Threading;

namespace Unit01
{
    class Program
    {
        //array with 0-9 where zero is not used, declare variables
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //player # 1 is set
        static int choice; //user mark position
        //flag's variable checks the winner if its value is 1, it has won
        //if -1 the match is tied if 0 the match is still running
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();//clear the screen to start over
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking the player's chance
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board();//call board Function
                choice = int.Parse(Console.ReadLine());//take users' choice
                //check whether the position is marked (with X or O) or not
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //if it's player 2's turn, mark O, otherwise mark X
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //if there is any position where the user wants to execute
                // if it's already checked, show the message and load the board again
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait a minute, the board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// call of check win
            }
            while (flag != 1 && flag != -1);
            //this loop will execute until all cells in the grid are unmarked.
              //X and O or some player does not win
            Console.Clear();//clear the console
            Board();//fill the board again
            if (flag == 1)
            //if the value of the flag is 1, there is a winner or
              //means who played marked the last time he won
            {
                Console.WriteLine("Player {0} has won!!!", (player % 2) + 1);
            }
            else//if the flag's value is -1, the match is tied and there is no winner
            {
                Console.WriteLine("Good game. Thanks for playing!");
            }
            Console.ReadLine();
        }
        // Board method which creats board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Check if a player has won or not
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //win's condition for first row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //win's condition for second row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //win's condition for third row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //win's condition for first column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //win's condition for second column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //win's condition for third column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            //if all the cells or values are filled with X's or O's, someone wins the match.
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
