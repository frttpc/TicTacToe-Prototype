using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public Piece[] pieces;
    private Piece selectedPiece;

    private void Start()
    {
        SetPieceValuesInTheBeginning(pieces);
    }

    private void SetPieceValuesInTheBeginning(Piece[] pieces)
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].writtenPieceValue.text = pieces[i].pieceValue.ToString();
        }
    }

    public void setSelectedPiece(Piece piece)
    {
        Debug.Log("Selected piece is: " + piece.name);
        selectedPiece = piece;
    }

    public Piece getSelectedPiece()
    {
        return selectedPiece;
    }

    public void resetSelectedPiece()
    {
        selectedPiece = null;
    }

    public bool PieceIsSelected()
    {
        if (selectedPiece != null)
            return true;
        else
            return false;
    }

    public void DisablePiece(Piece piece)
    {
        piece.button.interactable = false;
        piece.writtenPieceValue.enabled = false;
    }

    public void EnablePiece(Piece piece)
    {
        piece.button.interactable = true;
        piece.writtenPieceValue.enabled = true;
    }
}
