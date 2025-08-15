using Chess.Core.Pieces;

namespace Chess.Core._960;

public static class Chess960Setup
{
    static int boardSize = 8;


    public static Piece[] BoardSetup()
    {
        Random rand = new Random();
        List<int> availableSpaces = Enumerable.Range(0, 8).ToList();     
        
        int space = rand.Next(0, 4) * 2;
        Piece bishop1 = new Bishop('w', 7, space);
        availableSpaces.Remove(space);
        
        space = rand.Next(0, 4) * 2 + 1;
        Piece bishop2 = new Bishop('w', 7, space);
        availableSpaces.Remove(space);
        
        space = availableSpaces[rand.Next(0, availableSpaces.Count)];
        Piece knight1 = new Knight('w',7, space);
        availableSpaces.Remove(space);
        
        space = availableSpaces[rand.Next(0, availableSpaces.Count)];
        Piece knight2 = new Knight('w',7, space);
        availableSpaces.Remove(space);
        
        space = availableSpaces[rand.Next(0, availableSpaces.Count)];
        Piece queen = new Queen('w',7, space);
        availableSpaces.Remove(space);
        
        Piece rook1 = new Rook('w', 7, availableSpaces[0]);
        Piece king = new King('w', 7, availableSpaces[1]);
        Piece rook2 = new Rook('w', 7, availableSpaces[2]);
        
        Piece[] returnPieces = new Piece[8];
        
        returnPieces[0] = bishop1;
        returnPieces[1] = bishop2;
        returnPieces[2] = knight1;
        returnPieces[3] = knight2;
        returnPieces[4] = queen;
        returnPieces[5] = rook1;
        returnPieces[6] = rook2;
        returnPieces[7] = king;
        
        return returnPieces;

    }

    public static Piece[] Get960BlackSetup(Piece[] whitePieces)
    {
        Piece[] blackPieces = new Piece[8];
        blackPieces[0] = new Bishop('b',0,whitePieces[0].CurrentLocation.Column);
        blackPieces[1] = new Bishop('b',0,whitePieces[1].CurrentLocation.Column);
        blackPieces[2] = new Knight('b',0,whitePieces[2].CurrentLocation.Column);
        blackPieces[3] = new Knight('b',0,whitePieces[3].CurrentLocation.Column);
        blackPieces[4] = new Queen('b',0,whitePieces[4].CurrentLocation.Column);
        blackPieces[5] = new Rook('b',0,whitePieces[5].CurrentLocation.Column);
        blackPieces[6] = new Rook('b',0,whitePieces[6].CurrentLocation.Column);
        blackPieces[7] = new King('b',0,whitePieces[7].CurrentLocation.Column);
        
        return blackPieces;
    }
    
    
    
}