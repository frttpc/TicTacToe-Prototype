using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject piece;
    public Tile[] tiles;
    private int selectedPieceValue;

    void Start()
    {
        piece = gameManager.piecePrefab;
    }

    public void CreateSelectedPieceOnClickedTile(Tile tile)
    {
        Instantiate(piece, tile.transform);
    }

    public void setSelectedPieceValue(Piece piece)
    {
        Debug.Log("Selected piece is: " + piece.name);
        selectedPieceValue = piece.pieceValue;
    }

    public int getSelectedPieceValue()
    {
        return selectedPieceValue;
    }

    public void setClickedTile()
    {

    }

    public void ClickedTile(Tile tile)
    {
        if (CheckIfSelectedPieceIsBiggerThanContainingValue(tile))
        {
            tile.setContainingValue(selectedPieceValue);
            CreateSelectedPieceOnClickedTile(tile);
            selectedPieceValue = 0;
        }
        else if (selectedPieceValue == 0)
            Debug.Log("Didn't select a piece to play");
        else
            Debug.Log("Cannot put piece there!");
    }

    private bool CheckIfSelectedPieceIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    void CheckForAnyMatch()
    {

    }
}
