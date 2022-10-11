using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI hiScoreText;
    float score;

    int hiScore;

    bool scoreStop = false;

    public float scoreSpeed = 10.0f;

    public float Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"Score : {(int)score}";
        }
    }

    private void Awake()
    {
        scoreText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        hiScoreText = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Inst.Player.onDead += TimeStop;
    }

    private void Update()
    {
        if (!scoreStop)
        {
            Score += scoreSpeed * Time.deltaTime;
        }
    }

    void TimeStop()
    {
        scoreStop = true;
        GameManager.Inst.Score = (int)score;
    }




}
