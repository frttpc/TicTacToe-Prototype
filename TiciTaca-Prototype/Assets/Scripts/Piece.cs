using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Piece : MonoBehaviour
{
    public int pieceValue;
    private Color pieceColor;
    public TMPro.TextMeshProUGUI writtenPieceValue;

    public Piece(Color color, int value)
    {
        pieceValue = value;
        pieceColor = color;
    }

    private void SetPieceValue(int value)
    {
        writtenPieceValue.text = value.ToString();
    }
}
