using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private void FixedUpdate()
    {
        // Wrap the object around the screen if it goes out of bounds on the x-z plane
        // Get the object's position in the world
        var position = transform.position;
        // Get the object's position in the viewport
        var viewportPosition = Camera.main.WorldToViewportPoint(position);

        var x = Mathf.Repeat(viewportPosition.x, 1f);
        var y = Mathf.Repeat(viewportPosition.y, 1f);

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(x, y, viewportPosition.z));
    }
}