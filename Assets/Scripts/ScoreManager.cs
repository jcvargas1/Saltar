using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Script to manage the hiscore system within the game
// Score increases with every second alive and resets when falls off platform.
// Hiscore is supposed to be kept


public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") != null)
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);

    }


    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
        gameObject.SetActive(false);
    }

}
