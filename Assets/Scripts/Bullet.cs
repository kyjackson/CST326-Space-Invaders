using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        this.gameObject.tag = "Bullet";
        
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.mass = 0;
        //myRigidbody2D.velocity = Vector2.up * speed; 
        Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Base")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
