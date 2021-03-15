using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float maxBound, minBound;

    [SerializeField] private Animator playerAnimator;

    public GameObject bullet;
    public Transform shootingOffset;
    public float fireRate;
    private float nextFire;
    //public int bulletSpeed = 5;

    private void Start()
    {
        player = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //move player with arrow keys
        float horizontal = Input.GetAxis("Horizontal"); 

        if(player.position.x < minBound && horizontal < 0)
        {
            horizontal = 0;
        }
        else if(player.position.x > maxBound && horizontal > 0)
        {
            horizontal = 0;
        }
        //transform.Translate(transform.right * horizontal * Time.deltaTime * modifier);

        player.position += Vector3.right * horizontal * speed;
        
    }

    private void Update()
    {
        // fire bullet
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            playerAnimator.SetTrigger("Shoot");

            nextFire = Time.time + fireRate;
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
            //shot.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
            Debug.Log("Bang!");

            Destroy(shot, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerAnimator.SetTrigger("Death");
        StartCoroutine(KillOnAnimationEnd());
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(playerAnimator);
        Destroy(gameObject);
    }
}
