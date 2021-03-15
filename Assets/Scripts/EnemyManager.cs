using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed = 0.1f;

    public GameObject bullet;
    public Text winText;
    public float time;

    void Start()
    {
        // make bullets not collide with enemy parent
        Physics2D.IgnoreLayerCollision(0, 1);
        enemyHolder = GetComponent<Transform>();
        InvokeRepeating("MoveEnemy", 0.2f, 0.2f);

    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        if(enemyHolder.position.x < -4 || enemyHolder.position.x > 4)
        {
            speed = -speed;
            enemyHolder.position += Vector3.down * 0.25f;
        }

        if (enemyHolder.position.y <= 7)
        {
            GameOver.isPlayerDead = true;
            Time.timeScale = 0;
        }

        //foreach (Transform enemy in enemyHolder)
        //{
        //    if (enemy.position.x < -5 || enemy.position.x > 5)
        //    {
        //        speed = -speed;
        //        enemyHolder.position += Vector3.down * 0.25f;
        //    }

        //    if (enemy.position.y <= -1.5)
        //    {
        //        GameOver.isPlayerDead = true;
        //        Time.timeScale = 0;
        //    }
        //}

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.1f);
        }

        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;

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
