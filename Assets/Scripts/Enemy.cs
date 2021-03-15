using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask enemyLayer;
    private Transform enemy;
    public Transform shootingOffset;

    public GameObject bullet;
    public float nextTime = 3;

    [SerializeField] private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // tell enemies when to shoot
        if (Time.time > nextTime)
        {
            if (IsBottom())
            {
                Instantiate(bullet, shootingOffset.position, enemy.rotation);
            }
            nextTime = Time.time + Random.Range(4, 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyAnimator.SetTrigger("Death");
        StartCoroutine(KillOnAnimationEnd());
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

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(enemyAnimator);
        Destroy(gameObject);
    }
}
