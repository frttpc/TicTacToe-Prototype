using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundIndicatorController : MonoBehaviour
{
    private Vector2 player1RoundIndicatorPosition;
    private Vector2 player2RoundIndicatorPosition;

    void Start()
    {
        player1RoundIndicatorPosition = gameObject.transform.localPosition;
        player2RoundIndicatorPosition = player1RoundIndicatorPosition + new Vector2(0,3f);
    }

    public void changePositionOfRoundIndicator()
    {
        if (gameObject.transform.localPosition.y == player2RoundIndicatorPosition.y)
            gameObject.transform.Translate(player1RoundIndicatorPosition);
        else
            gameObject.transform.Translate(player2RoundIndicatorPosition);
    }
}
