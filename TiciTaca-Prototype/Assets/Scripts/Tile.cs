using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    public int tileIndex;
    private int containingValue;

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name + " with Index: " + tileIndex);
        gameBoardManager.ClickedTile(this);
    }

    public void setContainingValue(int value)
    {
        containingValue = value;
    }

    public int getContainingValue()
    {
        return containingValue;
    }

    public void setContainingPlayedPieceValue(int value)
    {
        transform.GetChild(0).GetComponent<PlayedPiece>().setValueText(value);
    }
}
