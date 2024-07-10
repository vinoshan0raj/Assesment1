using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    int score;
    public static GameManeger inst;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
