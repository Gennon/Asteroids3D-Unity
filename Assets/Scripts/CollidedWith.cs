using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidedWith : MonoBehaviour
{
    public string tagToCollideWith = "Asteroid";
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCollideWith))
        {
            gameObject.GetComponent<DestroyedHandler>()?.Destroy();
            other.gameObject.GetComponent<DestroyedHandler>()?.Destroy();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}