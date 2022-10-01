using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    PLAYER1TURN,
    PLAYER2TURN,
    PLAYER1WON,
    PLAYER2WON,
}

public class GameManager : MonoBehaviour
{
    public GameState state;
    public GameObject gameBoard;

    void Start()
    {
        state = GameState.PLAYER1TURN;
        Player1Turn();
    }

    void Player1Turn()
    {

    }
}
