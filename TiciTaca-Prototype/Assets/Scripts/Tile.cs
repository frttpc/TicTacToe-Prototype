using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    private bool isEmpty = false;
    private int containingValue = 0;

    private void OnMouseDown()
    {
        Debug.Log("Clicked on " + name);

        gameBoardManager.getClickedTile();
    }

    public int getContainingValue()
    {
        return containingValue;
    }
}
