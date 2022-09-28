using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public Button button;
    private bool isEnabled;
    public int pieceValue;
    private Color pieceColor;
    public TextMeshProUGUI writtenPieceValue;

    public Piece(Color color, int value)
    {
        pieceValue = value;
        pieceColor = color;
    }

    private void Start()
    {
        SetPieceValue(pieceValue);
    }

    private void SetPieceValue(int value)
    {
        writtenPieceValue.text = value.ToString();
    }

    private void DisablePiece()
    {
        button.interactable = false;
        writtenPieceValue.enabled = false;
    }

    private void EnablePiece()
    {
        button.interactable = true;
        writtenPieceValue.enabled = true;
    }
}
