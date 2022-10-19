using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public GameBoardManager gameBoardManager;
    public Piece[] pieces;
    public int belongsTo;
    private Piece selectedPiece;
    public Color pieceColor;
    public int totalPiecesLeft = 6;

    void Start()
    {
        SetPiecesInTheBeginning();
    }

    private void SetPiecesInTheBeginning()
    {
        foreach (Piece piece in pieces)
        {
            piece.pieceValueText.text = piece.pieceValue.ToString();
            setColor(piece);
        }
    }

    public void setSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
        gameBoardManager.setSelectedPiece(piece);
    }

    public int getSelectedPieceValue()
    {
        return selectedPiece.pieceValue;
    }

    public void DisablePieceButton(Piece piece)
    {
        piece.button.interactable = false;
        piece.pieceValueText.enabled = false;
        piece.pieceLeftText.enabled = false;
    }

    public void EnablePieceButton(Piece piece)
    {
        piece.button.interactable = true;
        piece.pieceValueText.enabled = true;
        piece.pieceLeftText.enabled = true;
    }

    public void DisableAllPieceButtons()
    {
        foreach (Piece piece in pieces)
        {
            DisablePieceButton(piece);
        }
    }

    public void EnableAllPieceButtons()
    {
        foreach (Piece piece in pieces)
        {
            if (PieceIsLeft(piece))
                EnablePieceButton(piece);
        }
    }

    private bool PieceIsLeft(Piece piece)
    {
        if(piece.getPieceLeft() != 0)
            return true;
        return false;
    }

    public void setColor(Piece piece)
    {
        piece.image.color = pieceColor;
    }

    public void UsePiece()
    {
        LowerPieceLeft();
        LowerPieceLeftText();
        resetSelectedPiece();
        totalPiecesLeft--;
    }

    private void LowerPieceLeft()
    {
        selectedPiece.setPieceLeft(selectedPiece.getPieceLeft() -1);
    }

    private void LowerPieceLeftText()
    {
        selectedPiece.pieceLeftText.text = "x" + selectedPiece.getPieceLeft().ToString();
    }

    private void resetSelectedPiece()
    {
        selectedPiece = null;
    }

    public void ResetPieces()
    {
        foreach(Piece piece in pieces)
        {
            ResetPieceLeftAndText(piece);
        }
    }

    private void ResetPieceLeftAndText(Piece piece)
    {
        piece.setPieceLeft(2);
        piece.pieceLeftText.text = "x2";
    }
}
