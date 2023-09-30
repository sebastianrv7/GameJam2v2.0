using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    private Transform transformPlayer;

    private void Start()
    {
        Transform transformPlayer = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2((mousePos.x - transform.position.x)/3, (mousePos.y - transform.position.y)/3);
        transform.Translate(direction);
    }
}
