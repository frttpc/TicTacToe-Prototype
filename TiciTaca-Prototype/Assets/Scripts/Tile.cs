using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    private int lastPlayedBy;
    private int containingValue;

    private void OnMouseDown()
    {
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

    public void setContainingPlayedPieceColor(Color color)
    {
        transform.GetChild(0).GetComponent<PlayedPiece>().ChangeColor(color);
    }

    public void setLastPlayedBy(int playedBy)
    {
        lastPlayedBy = playedBy;
    }

    public int getLastPlayedBy()
    {
        return lastPlayedBy;
    }
}
