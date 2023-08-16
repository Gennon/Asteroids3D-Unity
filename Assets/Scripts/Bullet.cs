using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // rotate around the z axis
        transform.Rotate(Vector3.forward * 360 * Time.deltaTime);
    }
}