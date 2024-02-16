// See https://aka.ms/new-console-template for more information
using CalendarPuzzle;

var x = new calendar.CalendarPuzzle(DateTime.Today);

List<PuzzlePiece> allPieces = new List<PuzzlePiece>();
#region Declare Pieces
allPieces.Add(new PuzzlePiece(new string[] {"****"}));

allPieces.Add(new PuzzlePiece(new string[] {"** ", 
                                            " **"}));

allPieces.Add(new PuzzlePiece(new string[] {"*  ", 
                                            "***",
                                            "  *"}));

allPieces.Add(new PuzzlePiece(new string[] {"***", 
                                            "*  "}));

allPieces.Add(new PuzzlePiece(new string[] {"****", 
                                            "*   "}));

allPieces.Add(new PuzzlePiece(new string[] {"**", 
                                            "***"}));

allPieces.Add(new PuzzlePiece(new string[] {"*  ", 
                                            "***",
                                            "*  "}));

allPieces.Add(new PuzzlePiece(new string[] {"***", 
                                            "*   ",
                                            "*   "}));

allPieces.Add(new PuzzlePiece(new string[] {"*** ",
                                            "  **"}));

allPieces.Add(new PuzzlePiece(new string[] {"* *", 
                                            "***"}));


#endregion
x.DisplayBoard();
