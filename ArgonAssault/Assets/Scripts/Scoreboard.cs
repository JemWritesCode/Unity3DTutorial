using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "0";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }
}
