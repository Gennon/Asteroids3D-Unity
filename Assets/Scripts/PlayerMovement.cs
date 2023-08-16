using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float moveSpeed = 50f;
    public AudioSource movementSound = null;

    // Update is called once per frame
    private void Update()
    {
        var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        var forward = Input.GetAxis("Vertical") * moveSpeed;
        forward *= Time.deltaTime;
        transform.Translate(0, 0, forward);
        if (forward != 0 && !movementSound.isPlaying)
        {
            movementSound.Play();
        }
        else if (forward == 0 && movementSound.isPlaying)
        {
            movementSound.Stop();
        }
    }
}