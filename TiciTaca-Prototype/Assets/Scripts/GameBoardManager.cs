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

    public void CreateSelectedPieceOnClickedTile(GameObject tile)
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

    void CheckForAnyMatch()
    {

    }
}
