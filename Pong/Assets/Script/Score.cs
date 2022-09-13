using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI TextScore;

    private void Awake()
    {
        TextScore = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        KillZone kill = GameObject.FindObjectOfType<KillZone>();
        kill.Upscore += setScore;
    }

    void setScore(int value)
    {
        TextScore.text = value.ToString();
    }
}
