using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public Button button;
    private bool isSelected = false;
    public int pieceValue;
    private Color pieceColor;
    public TextMeshProUGUI writtenPieceValue;

    public Piece(Color color, int value)
    {
        pieceValue = value;
        pieceColor = color;
    }
}
