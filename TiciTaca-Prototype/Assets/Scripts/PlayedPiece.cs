using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayedPiece : MonoBehaviour
{
    public TextMeshPro valueText;

    public void setValueText(int value)
    {
        valueText.text = value.ToString();
    }
}
