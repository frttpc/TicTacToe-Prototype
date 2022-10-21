using UnityEngine;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    public Tile[] tiles;
    public GameObject[] lines;
    [HideInInspector]public GameObject activeLine;
    private PieceController selectedPieceController;
    private GameObject piecePrefab;
    private List<GameObject> playedPiecesList;
    private Piece selectedPiece;
    private int whoseTurn;
    private int turnCount;
    private bool pieceIsPlayed;

    void Start()
    {
        playedPiecesList = new List<GameObject>();

        pieceIsPlayed = false;
    }

    public void ClickedTile(Tile tile)
    {
        if (selectedPiece == null)
            Debug.Log("Didn't select a piece to play");
        else if(!SelectedPieceValueIsBiggerThanContainingValue(tile))
            Debug.Log("Cannot put piece there!");
        else
        {
            if (tile.getContainingValue() > 0)
                EditPlayedPiece(tile);
            else
                CreateSelectedPieceOnClickedTile(tile);
            

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

    private void EditPlayedPiece(Tile tile)
    {
        tile.setContainingPieceColor(selectedPieceController.pieceColor);
    }

    private bool SelectedPieceValueIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPiece.pieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    public void CreateSelectedPieceOnClickedTile(Tile tile)
    {
        GameObject newPiece = Instantiate(piecePrefab, tile.transform);
        playedPiecesList.Add(newPiece);
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
    }

    public void EditWhoseTurn(int turnOfPlayer, PieceController pieceController)
    {
        whoseTurn = turnOfPlayer;
        selectedPieceController = pieceController;
    }

    public void setSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
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
        foreach(Tile tile in tiles)
        {
            if (tile.getLastPlayedBy() == -10)
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
            activeLine = lines[0];
        }
        else
        {
            lines[pos-3].SetActive(true);
            activeLine = lines[pos - 3];
        }
    }

    public void ResetGameBoard()
    {
        foreach(Tile tile in tiles)
        {
            ResetTile(tile);
        }
        foreach(GameObject playedPiece in playedPiecesList)
        {
            Destroy(playedPiece);
        }
        activeLine.SetActive(false);
    }

    private void ResetTile(Tile tile)
    {
        tile.setLastPlayedBy(-10);
        tile.setContainingValue(0);
    }
}
