using System;
using System.Security.Cryptography.X509Certificates;

namespace CalendarPuzzle
{
    public class PuzzlePiece
    {
        /// <summary>
        /// this is a list of coordinates that the piece inhabits
        /// </summary>
        List<Coordinate> pieceMap = new List<Coordinate>();
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
                        pieceMap.Add(new Coordinate(x, y));
                    }
                }
            }
        }


        public List<List<Coordinate>> uniqueOrientations;
        public List<List<Coordinate>> GetUniqueOrientations()
        {
            if (uniqueOrientations == null)
            {
                uniqueOrientations = new List<List<Coordinate>>();
                uniqueOrientations.Add(pieceMap);

                // first mirror on the Columns
                var mirrored = uniqueOrientations.Select(orientation => orientation.Select(coord => new Coordinate(coord.Row, coord.Column * -1)).ToList()).ToList();
                uniqueOrientations.AddRange(mirrored);

                // then mirror on the Rows
                mirrored = uniqueOrientations.Select(orientation => orientation.Select(coord => new Coordinate(coord.Row * -1, coord.Column)).ToList()).ToList();
                uniqueOrientations.AddRange(mirrored);
                
                // then invert rows and columns
                var inverted = uniqueOrientations.Select(orientation => orientation.Select(coord => new Coordinate(coord.Column, coord.Row)).ToList()).ToList();
                uniqueOrientations.AddRange(inverted);
                
                // Normalize the orientations
                // Shift the map so that the piece 
                // * inhabits 0,0
                // * does not have any negative values on the row
                // * any negative columns are in non-zero rows
                foreach (var orientation in uniqueOrientations)
                {
                    int shiftRows = 0;
                    int shiftColumns = 0;

                    shiftRows = orientation.Min(m => m.Row) * -1;

                    foreach(var coord in orientation)
                    {
                        coord.Row += shiftRows;
                    }

                    shiftColumns = orientation.Where(c => c.Row == 0).Min(c => c.Column) * -1;

                    foreach(var coord in orientation)
                    {
                        coord.Column += shiftColumns;
                    }
                }

                // TODO: Identiy Remove any duplicates for efficiency sake
            }

            // Save and return
            return uniqueOrientations;
        }
    }
}