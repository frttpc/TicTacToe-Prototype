using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public Piece[] pieces;

    private void Start()
    {
        SetPieceValues(pieces);
    }

    private void SetPieceValues(Piece[] pieces)
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].writtenPieceValue.text = pieces[i].pieceValue.ToString();
        }
    }

    public void getTheSelectedPieceValue()
    {
        
    }

    private void DisablePiece(Piece piece)
    {
        piece.button.interactable = false;
        piece.writtenPieceValue.enabled = false;
    }

    private void EnablePiece(Piece piece)
    {
        piece.button.interactable = true;
        piece.writtenPieceValue.enabled = true;
    }
}
