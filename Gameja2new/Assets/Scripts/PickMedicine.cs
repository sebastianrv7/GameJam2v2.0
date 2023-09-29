using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMedicine : MonoBehaviour
{
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
        }
<<<<<<< HEAD:Gameja2new/Assets/Scripts/PickMedicine.cs
    }
=======

        if (collision.CompareTag("Zombie"))
        {
            timerScript.LessTime();
            Destroy(collision.gameObject);
            Debug.Log("Te mordió el zombie");

        }


    }



>>>>>>> sebastian:Gameja2new/Assets/ScriptsSebastianSamuel/PickMedicine.cs
}
