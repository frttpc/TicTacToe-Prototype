using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundIndicatorController : MonoBehaviour
{
    private Vector2 player1RoundIndicatorPosition;
    private Vector2 player2RoundIndicatorPosition;

    private void Awake()
    {
        player1RoundIndicatorPosition = gameObject.transform.localPosition;
        player2RoundIndicatorPosition = gameObject.transform.localPosition + new Vector3(0, 3);
    }

    public void changePositionOfRoundIndicator(int i)
    {
        if (i == 1)
            gameObject.transform.localPosition = player1RoundIndicatorPosition;
        else
            gameObject.transform.localPosition = player2RoundIndicatorPosition;
    }
}
