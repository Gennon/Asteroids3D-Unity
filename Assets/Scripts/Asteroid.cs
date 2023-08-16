using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 rotationSpeedBounds = new Vector2(50f, 100f);
    public Vector2 moveSpeedBounds = new Vector2(10f, 20f);
    public bool isBig = true;
    public List<GameObject> asteroids = new List<GameObject>();

    private float rotationSpeed = 0f;
    private float movementSpeed = 0f;

    private void Start()
    {
        // Set random rotation on the y axis
        transform.Rotate(0, Random.Range(0, 360), 0);

        // Set random rotation speed
        rotationSpeed = Random.Range(rotationSpeedBounds.x, rotationSpeedBounds.y);
        // Set random forward speed
        movementSpeed = Random.Range(moveSpeedBounds.x, moveSpeedBounds.y);
        // Set random scale
        var scale = isBig ? Random.Range(.9f, 1.1f) : Random.Range(0.5f, 0.8f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void Update()
    {
        // Move forward
        var forward = movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, forward);
        // Rotate
        var rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }
}