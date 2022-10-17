using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    public UnityEvent e = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        e.Invoke();
    }
}
