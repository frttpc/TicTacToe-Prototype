using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    private int containingValue;

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + gameObject.name);
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
}
