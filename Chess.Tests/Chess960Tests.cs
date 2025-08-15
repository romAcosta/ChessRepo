using Chess.Core;
using Chess.Core._960;
using Chess.Core.Pieces;

namespace Chess.Tests;

public class Chess960Tests
{
    [Fact]
    public void PieceSetupSuccessfulTest()
    {
        
        try
        {
            Piece[] pieces = Chess960Setup.BoardSetup();
            Assert.True(true);
        }
        catch (Exception e)
        {
            Assert.True(false);
        }
    }
    
    [Fact]
    public void KingBetweenRooksTest()
    {
        int r1Position = 0;
        int r2Position = 0;
        int kPosition = 0;
        bool success = false;
        int phase = 0;
        Piece[] pieces = Chess960Setup.BoardSetup();
        foreach (Piece piece in pieces)
        {
            if (piece is Rook)
            {
                if (phase == 0)
                {
                    r1Position = piece.CurrentLocation.Column;
                    phase = 1;
                }
                else
                {
                    r2Position = piece.CurrentLocation.Column;
                }
            }

            if (piece is King)
            {
                kPosition = piece.CurrentLocation.Column;
            }
        }

        if ((r1Position < kPosition && r2Position > kPosition) || (r1Position > kPosition && r2Position < kPosition))
        {
            success = true;
        }
        
        Assert.True(success);
    }
    
    [Fact]
    public void BishopOppositeColorTest()
    {
        
        int b1Position = 0;
        int b2Position = 0;
        bool success = false;
        int phase = 0;
        Piece[] pieces = Chess960Setup.BoardSetup();
        foreach (Piece piece in pieces)
        {
            if (piece is Bishop)
            {
                if (phase == 0)
                {
                    b1Position = piece.CurrentLocation.Column;
                    phase = 1;
                }
                else
                {
                    b2Position = piece.CurrentLocation.Column;
                }
            }
        }

        if ((b1Position % 2) != (b2Position % 2))
        {
            success = true;
        }
        Assert.True(success);
        
    }
    
    [Fact]
    public void BlackMatchWhitePositionTest()
    {
        
        Piece[] whitePieces = Chess960Setup.BoardSetup();
        Piece[] blackPieces = Chess960Setup.Get960BlackSetup(whitePieces);
        bool success = true;

        for (int i = 0; i < whitePieces.Length; i++)
        {
            bool matchPosition = whitePieces[i].CurrentLocation.Column == blackPieces[i].CurrentLocation.Column;
            
            if (!matchPosition)
            {
                success = false;
            }
        }
        
        Assert.True(success);
        
        
    }
    
    [Fact]
    public void BlackIsBlackTest()
    {
        
        Piece[] whitePieces = Chess960Setup.BoardSetup();
        Piece[] blackPieces = Chess960Setup.Get960BlackSetup(whitePieces);
        bool success = true;

        foreach (Piece piece in blackPieces)
        {
            if (piece.Color != 'b')
            {
                success = false;
            } 
        }
        
        Assert.True(success);
        
        
    }
    
    
    
}