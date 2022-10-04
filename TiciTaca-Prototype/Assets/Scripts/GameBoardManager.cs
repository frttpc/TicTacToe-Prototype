using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    private GameBoardManager instance;
    public GameManager gameManager;
    public Tile[] tiles;

    void Start()
    {
        if (instance != null)
            instance = this;
        else
            Debug.Log("A GameBoard Manager already exists!");
    }

    public void PutSelectedPieceOnClickedTile(Tile tile, Piece piece)
    {
        Instantiate(piece,tile.transform);

    }

    public void getClickedTile(Tile tile)
    {

    }

    void CheckForAnyMatch()
    {

    }
}
