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
    DRAW
}

public class GameManager : MonoBehaviour
{
    public GameState state;
    public GameObject gameBoard;
    public GameObject piecePrefab;
    public PieceController player1PieceController;
    public PieceController player2PieceController;
    public RoundIndicatorController roundIndicatorController;

    void Start()
    {
        state = GameState.PLAYER1TURN;
        //Player1Turn();
        Debug.Log(state);
    }

    void Player1Turn()
    {
        roundIndicatorController.changePositionOfRoundIndicator();
        StartCoroutine(Player1Play());
    }

    IEnumerator Player1Play()
    {
        yield return new WaitUntil(player1PieceController.PieceIsSelected);

        //yield return new WaitUntil();
    }

    void Player2Turn()
    {
        roundIndicatorController.changePositionOfRoundIndicator();
        StartCoroutine(Player2Play());
    }

    IEnumerator Player2Play()
    {
        yield return null;
    }
}