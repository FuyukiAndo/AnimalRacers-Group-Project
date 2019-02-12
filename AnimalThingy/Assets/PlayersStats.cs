﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public GameObject character;
    public bool playerIsActive = false;
    public bool playerIsReady = false;
}
public class PlayersStats : MonoBehaviour {

    public static PlayersStats Instance { get; private set; }

    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;
    public List<Player> players;

    public int[] levels;
    public List<int> usedLevels;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        player1 = new Player();
        player2 = new Player();
        player3 = new Player();
        player4 = new Player();
        players = new List<Player>();
        usedLevels = new List<int>();
    }
}
