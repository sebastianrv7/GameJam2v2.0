using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMedicine : MonoBehaviour
{
    public GameObject time;
    private Timer timerScript;


    private void Start()
    {
        timerScript = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Medicine"))
        {
            timerScript.AddTime();
            Destroy(collision.gameObject);
            Debug.Log("hay colision");

        }


    }

}
