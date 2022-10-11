using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Piece : MonoBehaviour
{
    public Button button;
    public Image image;
    public TextMeshProUGUI pieceValueText;
    public TextMeshProUGUI pieceLeftText;
    public int pieceValue;
    private int pieceLeft = 2;

    public int getPieceLeft()
    {
        return pieceLeft;
    }

    public void setPieceLeft(int number)
    {
        pieceLeft = number;
    }
}
