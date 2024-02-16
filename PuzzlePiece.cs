using System;

namespace CalendarPuzzle
{
    public class PuzzlePiece
    {
        /// <summary>
        /// this is a list of coordinates that the piece inhabits
        /// </summary>
        List<Tuple<int,int>> pieceMap = new List<Tuple<int, int>>();
        /// <summary>
        /// Allows pieces to be constructed with lists of strings '*' for the piece and ' ' for whitespace
        /// </summary>
        /// <param name="constructor"></param>
        public PuzzlePiece(string[] constructor)
        {
            for(int x = 0; x != constructor.Length; x++)
            {
                for (int y = 0; y != constructor[x].Length; y++)
                {
                    if (constructor[x][y] == '*')
                    {
                        pieceMap.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
        }
    }
}