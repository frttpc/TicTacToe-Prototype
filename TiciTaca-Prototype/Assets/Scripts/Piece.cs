using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public Button button;
    protected bool isSelected = false;
    public int pieceValue;
    private Color pieceColor;
    public TextMeshProUGUI writtenPieceValue;

    public Piece(Color color, int value)
    {
        pieceValue = value;
        pieceColor = color;
    }

    public void getPieceValue()
    {
        button.Select();
    }


}
