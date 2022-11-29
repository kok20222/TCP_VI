using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    public UnityEvent e = new UnityEvent();

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && other.CompareTag("Active"))
        {
            e.Invoke();
        }
    }
}
