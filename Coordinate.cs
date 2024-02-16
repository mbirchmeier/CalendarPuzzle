using System;
using System.Data;

namespace CalendarPuzzle
{
    public class Coordinate
    {
        public Coordinate (int row, int column)
        {
            Column = column;
            Row = row;
        }
        public int Column {get; set;}
        public int Row {get; set;}
    }
}