using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public AudioSource bulletSpawnSound;
    public UnityEvent OnFire;

    private float nextFire;

    private void Update()
    {
        // Fire when the player presses the Fire1 button
        // but only if the fireRate time has passed since the last fire

        if (Input.GetButtonDown("Fire1"))
        {
            if (nextFire > fireRate)
            {
                Fire();
                nextFire = 0;
            }
        }
        nextFire += Time.deltaTime;
    }

    private void Fire()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bulletSpawnSound.Play();
        OnFire?.Invoke();
    }
}