using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    public Tile[] tiles;
    private PieceController selectedPieceController;
    private GameObject piecePrefab;
    private PlayedPiece playedPiece;
    private Piece selectedPiece;
    private int whoseTurn;
    private bool pieceIsPlayed;

    void Start()
    {
        piecePrefab = gameManager.piecePrefab;
        playedPiece = piecePrefab.GetComponent<PlayedPiece>();

        pieceIsPlayed = false;
    }

    public void ClickedTile(Tile tile)
    {
        if (selectedPiece.pieceValue == 0)
            Debug.Log("Didn't select a piece to play");
        else if(!SelectedPieceValueIsBiggerThanContainingValue(tile))
            Debug.Log("Cannot put piece there!");
        else
        {
            if (tile.getContainingValue() > 0)
                EditPlayedPiece(tile);
            else
                CreateSelectedPieceOnClickedTile(tile);

            EditTileOnClick(tile);

            selectedPieceController.UsePiece();
            selectedPieceController.resetSelectedPiece();
            pieceIsPlayed = true;
        }
    }

    private void EditPlayedPiece(Tile tile)
    {
        tile.setContainingPlayedPieceValue(selectedPiece.pieceValue);
        tile.setContainingPlayedPieceColor(selectedPieceController.pieceColor);
    }

    private bool SelectedPieceValueIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPiece.pieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    public void CreateSelectedPieceOnClickedTile(Tile tile)
    {
        playedPiece.setValueText(selectedPiece.pieceValue);
        playedPiece.ChangeColor(selectedPieceController.pieceColor);
        Instantiate(piecePrefab, tile.transform);
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

    private void EditTileOnClick(Tile tile)
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

    }
}
