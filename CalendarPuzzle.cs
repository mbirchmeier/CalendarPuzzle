using System;
using CalendarPuzzle;

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

        public CalendarPuzzle(DateTime targetDate) : this()
        {
            int month = targetDate.Month;
            int day = targetDate.Day;
            int weekDay = (int)targetDate.DayOfWeek;

            int monthRow = (month - 1) / 6;
            int monthColumn = (month - 1) % 6;

            int dayRow = (day-1) /7 + 2 ;
            int dayColumn = (day - 1) % 7;

            board[monthRow][monthColumn] = 'M';
            board[dayRow][dayColumn] = 'D';

            if (weekDay <=3)
            {
                board[6][3 + weekDay] = 'W';
            }
            else
            {
                board[7][weekDay] = 'W';
            }
        }
        public void DisplayBoard() {
            for (int x = 0; x != 8; x++)
            {
                Console.WriteLine(new string(board[x]));
            }
        }



        private bool FillBoard(ref List<PuzzlePiece> pieces, ref List<bool> piecePlaced, char pieceCharacter)
        {
            //uncomment to see the logic in action
            //this.DisplayBoard();

            //break recursion if all pieces are placed
            if (piecePlaced.All( x=> x))
            {
                return true;
            }

            int firstEmptyRow = -1;
            int firstEmptyColumn = -1;
            //first find the first coordinate that needs filled
            for(int x = 0; x != board.Length && firstEmptyColumn == -1; x++)
            {
                for (int y = 0; y != board[x].Length && firstEmptyColumn == -1; y++)
                {
                    if (board[x][y] == '_')
                    {
                        firstEmptyRow = x;
                        firstEmptyColumn = y;
                    }
                }
            }

            for (int pieceIndex = 0; pieceIndex != pieces.Count; pieceIndex++)
            {
                if (piecePlaced[pieceIndex] == false)
                {
                    var pieceOrientations = pieces[pieceIndex].GetUniqueOrientations();
                    foreach (var orientation in pieceOrientations)
                    {
                        //find out if we can place the piece
                        var canPlace = orientation.All(o => 
                                    firstEmptyRow + o.Row >= 0 &&
                                    firstEmptyRow + o.Row < board.Length && 
                                    firstEmptyColumn + o.Column >= 0 &&
                                    firstEmptyColumn + o.Column < board[0].Length &&
                                    board[firstEmptyRow + o.Row][firstEmptyColumn + o.Column] == '_');

                        //if so place it
                        if (canPlace)
                        {
                            foreach(var c in orientation)
                            {
                                board[firstEmptyRow + c.Row][firstEmptyColumn + c.Column] = pieceCharacter;
                            }
                            piecePlaced[pieceIndex] = true;
                            char nextCharacter = (char)(pieceCharacter + 1);
                            //if successful break
                            if (FillBoard(ref pieces, ref piecePlaced, nextCharacter))
                            {
                                return true;
                            }

                            piecePlaced[pieceIndex] = false;
                            foreach(var c in orientation)
                            {
                                board[firstEmptyRow + c.Row][firstEmptyColumn + c.Column] = '_';
                            }
                            //otherwise remove the piece and continue;    
                        }
                    }
                }
            }

            return false;
        }
        public void FillBoard(List<PuzzlePiece> pieces)
        {
            List<bool> isPlaced = pieces.Select((_) => false).ToList();
            FillBoard(ref pieces, ref isPlaced, 'a');
        }
    }
}