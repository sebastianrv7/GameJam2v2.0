using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Zombie : MonoBehaviour
{
    [SerializeField] 
    float moveSpeed = 2f;

    Transform tarjet;
    Rigidbody2D rb;
    Vector3 moveDirection;
    private GameManager gameManager;
    public GameObject medicine;


    [SerializeField]
    int health = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        tarjet = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("le diste");
            gameManager.AddZombieLoopCount();
            
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
        }
    }

    void InfectPlayer()
    {
        //// Restar x al tiempo restante de conversión a zombie
        //// Zombie make an attack animation if collied with player
    }
}
