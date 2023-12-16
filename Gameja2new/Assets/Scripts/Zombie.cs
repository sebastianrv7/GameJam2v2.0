using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Zombie : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = 2f;
    private Animator animator;
    [SerializeField] GameObject medicine;

    int bingo;

    Transform tarjet;
    Timer timerScript;
    Rigidbody2D rb;
    Vector3 moveDirection;
    private GameManager gameManager;
    


    [SerializeField]
    int health = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        timerScript = FindAnyObjectByType<Timer>();
        animator = GetComponent<Animator>();

        tarjet = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage();
        }

        if (collision.CompareTag("Player"))
        {
            InfectPlayer();
        }
    }


    void ChasePlayer()
    {
        if (tarjet)
        {
            Vector3 direction = (tarjet.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Deg2Rad;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            // Put some animations, sounds  and juice HERE
            
            Destroy(gameObject);
            animator.SetBool("death", true);
            bingo = Random.Range(0, 3);
            switch (bingo) {
                case 2: 
                    Instantiate(medicine,transform.position, Quaternion.identity);
                    break;
            }
        }
    }

    void InfectPlayer()
    {
        timerScript.SubstractTime();
    }
}
