using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public static bool isPlayerDead = false;
	private Text gameOver;
	private float time;

	void Start()
	{
		gameOver = GetComponent<Text>();
		gameOver.enabled = false;
	}

	void Update()
	{
		if (isPlayerDead)
		{
			//Time.timeScale = 0;
			//time = Time.time + 3f;
			gameOver.enabled = true;

			StartCoroutine(Reset());
		}
	}

	IEnumerator Reset()
    {
		yield return new WaitForSeconds(3);

		PlayerScore.playerScore = 0;
		GameOver.isPlayerDead = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
