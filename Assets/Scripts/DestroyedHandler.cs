using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyedHandler : MonoBehaviour
{
    public UnityEvent<GameObject> OnDestroyed;

    public void Destroy()
    {
        OnDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}