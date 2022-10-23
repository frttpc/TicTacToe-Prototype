using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    public Tile[] tiles;
    public GameObject[] lines;
    private GameObject matchLine;
    private PieceController selectedPieceController;
    private Piece selectedPiece;
    private int whoseTurn;
    private int turnCount;
    private bool pieceIsPlayed = false;

    public void ClickedTile(Tile tile)
    {
        if (!canGetSelectedPieceFromPieceController())
            Debug.Log("Please select a piece to play");
        else if(!isSelectedPieceValueIsBiggerThanContainingValue(tile))
            Debug.Log("Cannot put piece there!");
        else
        {
            EditClickedTile(tile);
            selectedPieceController.UsePiece();
            turnCount++;

            if(turnCount > 4)
            {
                CheckForMatch();
                if (turnCount > 8)
                    if(gameManager.state != GameState.PLAYER1WON && gameManager.state != GameState.PLAYER2WON)
                        CheckForDraw();
            }
            pieceIsPlayed = true;
            selectedPiece = null;
        }
    }

    private bool isSelectedPieceValueIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPiece.pieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    public bool PieceIsPlayed()
    {
        if (pieceIsPlayed)
        {
            pieceIsPlayed = false;
            return true;
        }
        else
            return false;
    }

    private void EditClickedTile(Tile tile)
    {
        tile.setContainingValue(selectedPiece.pieceValue);
        tile.setLastPlayedBy(whoseTurn);
        tile.image.sprite = selectedPiece.image.sprite;
        tile.image.color = selectedPieceController.getPlayerColor();
    }

    public void EditWhoseTurn(int turnOfPlayer, PieceController pieceController)
    {
        whoseTurn = turnOfPlayer;
        selectedPieceController = pieceController;
    }

    public bool canGetSelectedPieceFromPieceController()
    {
        selectedPiece = selectedPieceController.getSelectedPiece();
        if (selectedPiece)
            return true;
        return false;
    }

    void CheckForMatch()
    {
        int s1 = tiles[1].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[7].getLastPlayedBy();
        int s2 = tiles[2].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[6].getLastPlayedBy();
        int s3 = tiles[3].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[5].getLastPlayedBy();
        int s4 = tiles[0].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int s5 = tiles[0].getLastPlayedBy() + tiles[1].getLastPlayedBy() + tiles[2].getLastPlayedBy();
        int s6 = tiles[0].getLastPlayedBy() + tiles[3].getLastPlayedBy() + tiles[6].getLastPlayedBy();
        int s7 = tiles[2].getLastPlayedBy() + tiles[5].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int s8 = tiles[6].getLastPlayedBy() + tiles[7].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int[] solutions = {s1 , s2, s3, s4, s5 ,s6, s7, s8};

        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3)
            {
                gameManager.state = GameState.PLAYER1WON;
                setMatchLine(i);
                return;
            }
            else if (solutions[i] == 6)
            {
                gameManager.state = GameState.PLAYER2WON;
                setMatchLine(i);
                return;
            }
        }
    }

    void CheckForDraw()
    {
        int num = selectedPieceController.totalPiecesLeft;
        foreach (Tile tile in tiles)
        {
            if (tile.getLastPlayedBy() == -10 && num > 0)
                return;
        }
        gameManager.state = GameState.DRAW;
    }

    void setMatchLine(int pos)
    {
        if (pos < 4)
        {
            lines[0].transform.Rotate(0, 0, -pos * 45);
            lines[0].SetActive(true);
            matchLine = lines[0];
        }
        else
        {
            lines[pos-3].SetActive(true);
            matchLine = lines[pos - 3];
        }
    }

    public void ResetGameBoard()
    {
        foreach(Tile tile in tiles)
        {
            ResetTile(tile);
        }
        matchLine.SetActive(false);
    }

    private void ResetTile(Tile tile)
    {
        tile.setLastPlayedBy(-10);
        tile.setContainingValue(0);
        tile.image = null;
    }

    public void ResetMacthline()
    {
        matchLine.SetActive(false);
    }
}
