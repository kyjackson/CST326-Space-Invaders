using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    float speed = 5;
    public int modifier = 10;

    // Update is called once per frame
    void Update()
    {
        //move player with arrow keys
        float horizontal = Input.GetAxis("Horizontal"); 
        transform.Translate(transform.right * horizontal * Time.deltaTime * modifier);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            Debug.Log("Bang!");

            Destroy(shot, 3f);
        }
    }
}
