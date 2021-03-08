using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public LayerMask enemyLayer;
    public int direction = 1;
    public float speed = 0.1f;
    public float bulletSpeed = 5;
    public float nextTime = 3;
    public int hp = 10;
    public float bossBounce = 6;

    void Start()
    {
        // make bullets not collide with enemy parent
        Physics2D.IgnoreLayerCollision(0, 1);

        // set enemy healths
        if(this.gameObject.tag == "Enemy1")
        {
            this.hp = 10;
        }

        if (this.gameObject.tag == "Enemy2")
        {
            this.hp = 20;
        }

        if (this.gameObject.tag == "Enemy3")
        {
            this.hp = 30;
        }

        if (this.gameObject.tag == "Enemy4")
        {
            this.hp = 40;
        }
    }

    void Update()
    {

        // move the enemy parent left/right and down
        if (this.gameObject.tag == "EnemyMover")
        {

            transform.Translate(transform.right * Time.deltaTime * direction);
            transform.Translate(-1*transform.up * Time.deltaTime * speed);

        }

        if (this.gameObject.tag == "Enemy4")
        {
            transform.Translate(transform.right * Time.deltaTime * direction * 2);
            
            if(Time.time > bossBounce)
            {
                this.direction *= -1;
                bossBounce = Time.time + 6;
            }
        }

        // tell enemies when to shoot
        if (this.gameObject.tag != "EnemyMover" && this.gameObject.tag != "Enemy4")
        {
            if(IsBottom())
            {
                if(Time.time > nextTime)
                {
                    GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
                    Debug.Log("Bang!");
                    shot.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;

                    Destroy(shot, 3f);

                    nextTime = Time.time + Random.Range(3, 7);
                }             
            }           
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // set boundaries for the enemy parent's movement
        if (collision.gameObject.tag == "Boundary" && (this.tag == "EnemyMover" || this.tag == "Enemy4"))
        {
            this.direction *= -1;
        }

        // lower enemy health when hit by bullet and destroy when 0
        if (collision.gameObject.tag == "Bullet" && this.tag == "Enemy1")
        {
            this.hp -= 10;

            if(this.hp <= 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                PlayerScore.playerScore += 10;
                speed += 0.1f;
            }
        }
        else if(collision.gameObject.tag == "Bullet" && this.tag == "Enemy2")
        {
            this.hp -= 10;

            if (this.hp <= 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                PlayerScore.playerScore += 20;
                speed += 0.1f;
            }
        }
        else if (collision.gameObject.tag == "Bullet" && this.tag == "Enemy3")
        {
            this.hp -= 10;

            if (this.hp <= 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                PlayerScore.playerScore += 30;
                speed += 0.1f;
            }
        }
        else if (collision.gameObject.tag == "Bullet" && this.tag == "Enemy4")
        {
            this.hp -= 10;

            if (this.hp <= 0)
            {
                Debug.Log("Enemy Destroyed");
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                PlayerScore.playerScore += 40;
                speed += 0.1f;
            }
        }
    }

    // check if the enemy is on the bottom row
    bool IsBottom()
    {
        Vector2 position = transform.position;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 direction = Vector2.down;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, enemyLayer);
        //Debug.DrawRay(position, direction, Color.green);
        //Debug.Log(hit);

        if (hit.collider)
        {
            return false;
        }

        return true;
    }
}
