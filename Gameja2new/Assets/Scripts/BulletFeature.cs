using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFeature : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala en unidades por segundo
    float time;
    [SerializeField] float destroyTime = 2.5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time >= destroyTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }

}