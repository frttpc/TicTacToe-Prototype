using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    DRAW,
    PLAYER1WON,
    PLAYER2WON, 
    PLAYER1TURN,
    PLAYER2TURN
}

public class GameManager : MonoBehaviour
{
    public GameState state;
    public GameObject gameBoard;
    private GameBoardManager gameBoardManager;
    public PieceController[] pieceControllers;
    public GameObject[] OutcomeScreens;
    public GameObject[] Canvases;
    public Color[] PlayerColors;

    private void Awake()
    {
        gameBoardManager = gameBoard.GetComponent<GameBoardManager>();
        pieceControllers[0].pieceColor = PlayerColors[0];
        pieceControllers[1].pieceColor = PlayerColors[1];
    }

    public void StartTheGame()
    {
        Canvases[0].SetActive(false);
        Canvases[1].SetActive(true);

        gameBoard.SetActive(true);

        state = GameState.PLAYER1TURN;
        Player1Turn();
    }

    void Player1Turn()
    {
        gameBoardManager.EditWhoseTurn(1, pieceControllers[0]);
        StartCoroutine(Player1Play());
    }

    IEnumerator Player1Play()
    {
        pieceControllers[0].EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed);
        pieceControllers[0].DisableAllPieceButtons();

        if (state == GameState.PLAYER1TURN)
            state = GameState.PLAYER2TURN;
        CallFunctionForState();
    }

    void Player2Turn()
    {
        gameBoardManager.EditWhoseTurn(2, pieceControllers[1]);
        StartCoroutine(Player2Play());
    }

    IEnumerator Player2Play()
    {
        pieceControllers[1].EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed);
        pieceControllers[1].DisableAllPieceButtons();

        if (state == GameState.PLAYER2TURN)
            state = GameState.PLAYER1TURN;
        CallFunctionForState();
    }

    void CallFunctionForState()
    {
        if (state == GameState.PLAYER1TURN)
            Player1Turn();
        else if (state == GameState.PLAYER2TURN)
            Player2Turn();
        else if (state == GameState.PLAYER1WON)
            StartCoroutine(Player1Won());
        else if (state == GameState.PLAYER2WON)
            StartCoroutine(Player2Won());
        else
            StartCoroutine(Draw());
    }

    IEnumerator Player1Won()
    {
        yield return new WaitForSeconds(1f);
        OutcomeScreens[0].SetActive(true);
        gameBoard.SetActive(false);
    }

    IEnumerator Player2Won()
    {
        yield return new WaitForSeconds(1f);
        OutcomeScreens[1].SetActive(true);
        gameBoard.SetActive(false);
    }

    IEnumerator Draw()
    {
        yield return new WaitForSeconds(1f);
        OutcomeScreens[2].SetActive(true);
        gameBoard.SetActive(false);
    }

    public void RestartGame()
    {
        if (state == GameState.PLAYER1WON)
        {
            OutcomeScreens[0].SetActive(false);
            state = GameState.PLAYER2TURN;
        }
        else if (state == GameState.DRAW)
        {
            OutcomeScreens[2].SetActive(false);
            state = GameState.PLAYER1TURN;
        }
        else
        {
            OutcomeScreens[1].SetActive(false);
            state = GameState.PLAYER1TURN;
        }

        gameBoardManager.ResetGameBoard();

        foreach(PieceController pieceController in pieceControllers)
        {
            pieceController.ResetPieces();
        }

        gameBoard.SetActive(true);
        CallFunctionForState();
    }

    public void ReturnToMainMenu()
    {
        Canvases[0].SetActive(true);
        Canvases[1].SetActive(false);
        gameBoard.SetActive(false);
    }
}