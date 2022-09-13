using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score1 : Score
{
    TextMeshProUGUI TextScore;

    private void Awake()
    {
        TextScore = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        KillZone kill = GameObject.FindObjectOfType<KillZone>();
        kill.UpScore1 += setScore;
    }

    void setScore(int value)
    {
        TextScore.text = value.ToString();
    }
}
