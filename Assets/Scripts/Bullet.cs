using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed;

        if (bullet.position.y >= 10)
            Destroy(gameObject);
    }

    private void Fire()
    {
        myRigidbody2D.mass = 0;
        Debug.Log("Wwweeeeee");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy1")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 10;
        }
        else if (other.tag == "Enemy2")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 20;
        }
        else if (other.tag == "Enemy3")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 30;
        }
        else if (other.tag == "Enemy4")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 40;
        }
        else if (other.tag == "Base")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
