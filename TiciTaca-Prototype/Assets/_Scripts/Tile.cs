using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameBoardManager gameBoardManager;
    private int lastPlayedBy = -10;
    private int containingValue;

    public void setContainingValue(int value)
    {
        containingValue = value;
    }

    public int getContainingValue()
    {
        return containingValue;
    }

    public void setContainingPieceColor(Color color)
    {

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
