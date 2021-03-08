using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static float playerScore = 0;
    public static float playerHiScore = 0;
    public Text scoreText;
    public Text hiScoreText;
    public GameObject score;
    public GameObject hiScore;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
        scoreText = score.GetComponent<Text>();

        hiScore = GameObject.Find("HiScore");
        hiScoreText = hiScore.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score\n " + playerScore.ToString("0000");

        if(playerScore >= playerHiScore)
        {
            playerHiScore = playerScore;    
        }

        hiScoreText.text = "Hi-Score\n " + playerHiScore.ToString("0000");
    }
}
