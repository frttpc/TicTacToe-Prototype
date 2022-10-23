using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameManager gameManager;
    public GameBoardManager gameBoardManager;
    public Piece[] pieces;
    private Piece selectedPiece;
    private Color playerColor;
    public int totalPiecesLeft = 6;

    void Start()
    {
        //SetPieceColorsInTheBeginning();
    }

    private void SetPieceColorsInTheBeginning()
    {
        foreach (Piece piece in pieces)
        {
            setPieceColor(piece);
        }
    }

    public void setSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
    }

    public Piece getSelectedPiece()
    {
        return selectedPiece;
    }

    public void DisablePieceButton(Piece piece)
    {
        piece.button.interactable = false;
    }

    public void EnablePieceButton(Piece piece)
    {
        piece.button.interactable = true;
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

    public void setPlayerColor(Color color)
    {
        playerColor = color;
    }

    public Color getPlayerColor()
    {
        return playerColor;
    }

    public void setPieceColor(Piece piece)
    {
        piece.image.color = playerColor; /// NOT THE IMAGE BUT BUTTON COLORS
    }
}
