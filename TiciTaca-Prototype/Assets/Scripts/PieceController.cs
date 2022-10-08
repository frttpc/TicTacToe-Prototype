using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public GameBoardManager gameBoardManager;
    public Piece[] pieces;
    private Piece selectedPiece;

    private void Start()
    {
        SetPieceValuesInTheBeginning(pieces);
        DisableAllPieceButtons();
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

    public void DisableAllPieceButtons()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            DisablePieceButton(pieces[i]);
        }
    }

    public void EnableAllPieceButtons()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            EnablePieceButton(pieces[i]);
        }
    }

    public void DisablePieceButton(Piece piece)
    {
        piece.button.interactable = false;
        piece.writtenPieceValue.enabled = false;
    }

    public void EnablePieceButton(Piece piece)
    {
        piece.button.interactable = true;
        piece.writtenPieceValue.enabled = true;
    }
}
