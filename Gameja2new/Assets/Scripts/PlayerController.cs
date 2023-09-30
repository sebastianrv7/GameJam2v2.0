using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float defaultSpeed = 12.5f;


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mira hacia la posición del mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;

        // Aplica el movimiento usando Rigidbody2D
        if (verticalInput != 0 || horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * defaultSpeed, verticalInput * defaultSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


    }

    
   
}
