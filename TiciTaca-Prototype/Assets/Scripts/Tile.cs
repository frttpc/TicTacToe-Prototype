using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    private bool isEmpty = false;
    private int containingValue;

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);
        gameBoardManager.CreateSelectedPieceOnClickedTile(gameObject);
    }

    public void setContainingPiece(Piece piece)
    {
        containingValue = piece.pieceValue;
    }
}
