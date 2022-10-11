using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    Player player;

    int score;
    int hiScore;

    public int Score { get => score; set => score = value; }
    public int HiScore { get => hiScore; }


    public Player Player { get => player; }

    protected override void Initialize()
    {
        player = FindObjectOfType<Player>();
    }

}
