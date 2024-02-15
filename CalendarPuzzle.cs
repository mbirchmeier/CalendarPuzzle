using System;

namespace calendar
{
    public class CalendarPuzzle
    {
        char[][] board = new char[8][];

        public CalendarPuzzle() 
        {
            for (int x = 0; x != 8; x++)
            {
                board[x] = new char[7];
                for (int y = 0; y != 7; y++)
                {
                    board[x][y] = '_';
                }
            }
            board[0][6] = '*';
            board[1][6] = '*';
            board[7][0] = '*';
            board[7][1] = '*';
            board[7][2] = '*';
            board[7][3] = '*';
        }

        public void DisplayBoard() {
            for (int x = 0; x != 8; x++)
            {
                Console.WriteLine(new string(board[x]));
            }
        }
    }
}