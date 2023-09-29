using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RatioOneThird : MonoBehaviour
{
    public Transform player;

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

        // Calculate the target position for the object to look at.
        Vector3 targetPosition = player.position + (mouseWorldPos - player.position) * distanceRatio;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
