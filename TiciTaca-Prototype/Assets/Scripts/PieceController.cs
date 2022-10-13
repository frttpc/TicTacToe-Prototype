using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public GameBoardManager gameBoardManager;
    public Piece[] pieces;
    public int belongsTo;
    private Piece selectedPiece;
    public Color pieceColor;

    private void Start()
    {
        SetPiecesInTheBeginning(pieces);
    }

    private void SetPiecesInTheBeginning(Piece[] pieces)
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].pieceValueText.text = pieces[i].pieceValue.ToString();
            setColor(pieces[i]);
        }
    }

    public void setSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
        Debug.Log(selectedPiece);

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
        for (int i = 0; i < pieces.Length; i++)
        {
            DisablePieceButton(pieces[i]);
        }
    }

    public void EnableAllPieceButtons()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (PieceIsLeft(pieces[i]))
                EnablePieceButton(pieces[i]);
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
    }

    private void LowerPieceLeft()
    {
        selectedPiece.setPieceLeft(selectedPiece.getPieceLeft() -1);
    }

    private void LowerPieceLeftText()
    {
        selectedPiece.pieceLeftText.text = "x" + selectedPiece.getPieceLeft().ToString();
    }

    public void resetSelectedPiece()
    {
        selectedPiece = null;
    }
}
