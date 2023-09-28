using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFeature : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala en unidades por segundo
    

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        DestrouOutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }

    private void DestrouOutOfBounds()
    {
        if (gameObject.transform.position.x >50 || gameObject.transform.position.x > 50 || gameObject.transform.position.y > 50 || gameObject.transform.position.y < 50)
        {
            Destroy(gameObject);
        }
    }
}
