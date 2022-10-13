using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameManager gameManager;
    public Tile[] tiles;
    private PieceController selectedPieceController;
    private GameObject piecePrefab;
    private PlayedPiece playedPiece;
    private Piece selectedPiece;
    private int whoseTurn;
    private int turnCount;
    private bool pieceIsPlayed;

    void Start()
    {
        piecePrefab = gameManager.piecePrefab;
        playedPiece = piecePrefab.GetComponent<PlayedPiece>();

        pieceIsPlayed = false;
    }

    public void ClickedTile(Tile tile)
    {
        if (selectedPiece.pieceValue == 0)
            Debug.Log("Didn't select a piece to play");
        else if(!SelectedPieceValueIsBiggerThanContainingValue(tile))
            Debug.Log("Cannot put piece there!");
        else
        {
            if (tile.getContainingValue() > 0)
                EditPlayedPiece(tile);
            else
                CreateSelectedPieceOnClickedTile(tile);

            EditClickedTile(tile);

            selectedPieceController.UsePiece();
            selectedPieceController.resetSelectedPiece();
            turnCount++;

            if(turnCount > 4)
            {
                CheckForMatch();
                if (turnCount > 8)
                    if(gameManager.state != GameState.PLAYER1WON && gameManager.state != GameState.PLAYER2WON)
                        CheckForDraw();
            }
            pieceIsPlayed = true;
        }
    }

    private void EditPlayedPiece(Tile tile)
    {
        tile.setContainingPlayedPieceValue(selectedPiece.pieceValue);
        tile.setContainingPlayedPieceColor(selectedPieceController.pieceColor);
    }

    private bool SelectedPieceValueIsBiggerThanContainingValue(Tile tile)
    {
        if (selectedPiece.pieceValue > tile.getContainingValue())
            return true;
        return false;
    }

    public void CreateSelectedPieceOnClickedTile(Tile tile)
    {
        playedPiece.setValueText(selectedPiece.pieceValue);
        playedPiece.ChangeColor(selectedPieceController.pieceColor);
        Instantiate(piecePrefab, tile.transform);
    }

    public bool PieceIsPlayed()
    {
        if (pieceIsPlayed)
        {
            pieceIsPlayed = false;
            return true;
        }
        else
            return false;
    }

    private void EditClickedTile(Tile tile)
    {
        tile.setContainingValue(selectedPiece.pieceValue);
        tile.setLastPlayedBy(whoseTurn);
    }

    public void EditWhoseTurn(int turnOfPlayer, PieceController pieceController)
    {
        whoseTurn = turnOfPlayer;
        selectedPieceController = pieceController;
    }

    public void setSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
    }

    void CheckForMatch()
    {
        int s1 = tiles[0].getLastPlayedBy() + tiles[1].getLastPlayedBy() + tiles[2].getLastPlayedBy();
        int s2 = tiles[3].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[5].getLastPlayedBy();
        int s3 = tiles[6].getLastPlayedBy() + tiles[7].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int s4 = tiles[0].getLastPlayedBy() + tiles[3].getLastPlayedBy() + tiles[6].getLastPlayedBy();
        int s5 = tiles[1].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[7].getLastPlayedBy();
        int s6 = tiles[2].getLastPlayedBy() + tiles[5].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int s7 = tiles[0].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[8].getLastPlayedBy();
        int s8 = tiles[2].getLastPlayedBy() + tiles[4].getLastPlayedBy() + tiles[6].getLastPlayedBy();
        int[] solutions = {s1 , s2, s3, s4, s5 ,s6, s7, s8};

        for(int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3)
            {
                gameManager.state = GameState.PLAYER1WON;
                return;
            }
            else if (solutions[i] == 6)
            {
                gameManager.state = GameState.PLAYER2WON;
                return;
            }
        }
    }

    void CheckForDraw()
    {
        for(int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].getLastPlayedBy() == -10)
                return;
        }
        gameManager.state = GameState.DRAW;
    }
}
