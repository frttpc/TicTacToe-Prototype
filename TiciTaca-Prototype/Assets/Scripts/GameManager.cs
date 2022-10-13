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
    public GameBoardManager gameBoardManager;
    public GameObject piecePrefab;
    public PieceController player1PieceController;
    public PieceController player2PieceController;
    public Image player1WinScreen;
    public Image player2WinScreen;
    public Image drawScreen;

    void Start()
    {
        state = GameState.PLAYER1TURN;
        Player1Turn();
    }

    void Player1Turn()
    {
        gameBoardManager.EditWhoseTurn(1,player1PieceController);
        StartCoroutine(Player1Play());
    }

    IEnumerator Player1Play()
    {
        player1PieceController.EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed); 
        player1PieceController.DisableAllPieceButtons();

        if (state == GameState.PLAYER1TURN)
            state = GameState.PLAYER2TURN;
        CallFunctionForState();
    }

    void Player2Turn()
    {
        gameBoardManager.EditWhoseTurn(2,player2PieceController);
        StartCoroutine(Player2Play());
    }

    IEnumerator Player2Play()
    {
        player2PieceController.EnableAllPieceButtons();
        yield return new WaitUntil(gameBoardManager.PieceIsPlayed);
        player2PieceController.DisableAllPieceButtons();

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
            Player1Won();
        else if (state == GameState.PLAYER2WON)
            Player2Won();
        else
            Draw();
    }

    void Player1Won()
    {
        player1WinScreen.enabled = true;
    }

    void Player2Won()
    {
        player2WinScreen.enabled = true;
    }

    void Draw()
    {
        drawScreen.enabled = true;
    }

}