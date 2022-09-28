using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    private GameBoardManager instance;
    public Tile[] tiles;

    void Start()
    {
        if (instance != null)
            instance = this;
        else
            Debug.Log("A GameBoard Manager already exists!");
    }

    void CheckForAnyMatch()
    {

    }
}
