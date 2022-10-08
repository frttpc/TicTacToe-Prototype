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
    public GameBoardManager gameBoardManager;
    public GameObject piecePrefab;
    public PieceController player1PieceController;
    public PieceController player2PieceController;
    public RoundIndicatorController roundIndicatorController;

    void Start()
    {
        state = GameState.PLAYER1TURN;
        Player1Turn();
    }

    void Player1Turn()
    {
        roundIndicatorController.changePositionOfRoundIndicator(1);
        StartCoroutine(Player1Play());
    }

    IEnumerator Player1Play()
    {
        player1PieceController.EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed); 
        player1PieceController.DisableAllPieceButtons();

        state = GameState.PLAYER2TURN;
        Player2Turn();
    }

    void Player2Turn()
    {
        roundIndicatorController.changePositionOfRoundIndicator(2);
        StartCoroutine(Player2Play());
    }

    IEnumerator Player2Play()
    {
        player2PieceController.EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed);
        player2PieceController.DisableAllPieceButtons();

        state = GameState.PLAYER1TURN;
        Player1Turn();
    }
}