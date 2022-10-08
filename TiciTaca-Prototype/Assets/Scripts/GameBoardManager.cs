using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    private GameObject piece;
    private PlayedPiece played;
    public Tile[] tiles;
    private int selectedPieceValue;
    private bool pieceIsPlayed;

    void Start()
    {
        piece = gameManager.piecePrefab;
        played = piece.GetComponent<PlayedPiece>();

        pieceIsPlayed = false;
        setTileIndexes();
    }

    public void setTileIndexes()
    {
        for(int i=0; i<tiles.Length; i++)
        {
            tiles[i].tileIndex = i+1;
        }
    }

    public void setSelectedPieceValue(Piece piece)
    {
        selectedPieceValue = piece.pieceValue;
    }

    public void ClickedTile(Tile tile)
    {
        if (selectedPieceValue == 0)
            Debug.Log("Didn't select a piece to play");
        else if(!SelectedPieceValueIsBiggerThanContainingValue(tile))
            Debug.Log("Cannot put piece there!");
        else
        {
            if (tile.getContainingValue() > 0)
                tile.setContainingPlayedPieceValue(selectedPieceValue);
            else
                CreateSelectedPieceOnClickedTile(tile);

            tile.setContainingValue(selectedPieceValue);
            pieceIsPlayed = true;
            selectedPieceValue = 0;
        }
    }

    private bool SelectedPieceValueIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    public void CreateSelectedPieceOnClickedTile(Tile tile)
    {
        played.setValueText(selectedPieceValue);
        Instantiate(piece, tile.transform);
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

    void CheckForAnyMatch()
    {

    }
}
