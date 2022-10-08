using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI writtenPieceValue;
    private int pieceLeft = 2;
    public int pieceValue;
    private Color pieceColor;

    public int getPieceLeft()
    {
        return pieceLeft;
    }
}
