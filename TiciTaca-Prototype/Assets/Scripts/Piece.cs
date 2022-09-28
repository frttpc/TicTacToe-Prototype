using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int pieceValue;
    private Color pieceColor;

    public Piece(Color color, int value)
    {
        pieceValue = value;
        pieceColor = color;
    }
}
