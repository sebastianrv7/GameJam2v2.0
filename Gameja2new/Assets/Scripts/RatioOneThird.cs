using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RatioOneThird : MonoBehaviour
{
    public Transform player;
    public float maxRange = 20.0f;

    // Adjust this factor to control the distance
    [SerializeField] private float distanceRatio = 0.33f;

    Transform focalTransform;

    private void LateUpdate()
    {
        if (player != null)
        {
            LocateFocalInThird();
        }
    }

    void LocateFocalInThird()
    {
        // Get the mouse position in screen space.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z - player.position.z);

        // Convert the screen space mouse position to world space.
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // This is the distance between the player and the mouse.

        float distanceMtP = (mouseWorldPos - player.position).magnitude;

        // Calculate the target position for the object to look at.

        if (-maxRange < distanceMtP && distanceMtP < maxRange)
        {
            Vector3 targetPosition = player.position + (mouseWorldPos - player.position) * distanceRatio;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
        else
        {
            Vector3 targetPosition = player.position + (mouseWorldPos - player.position).normalized * maxRange * distanceRatio;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }


    }
}
