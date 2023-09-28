using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float defaultSpeed = 12.5f;


    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Here are the inputs for the movement of the character

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // This creates a rotation on the Player to always look at the mouse.

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;


        // This is the conditions for the movement to happen 

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
