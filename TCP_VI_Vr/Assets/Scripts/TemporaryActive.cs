using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    private GameObject obj = null;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Activity"))
        {
            obj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        obj = null;
    }

    public void PowerOn()
    {
        obj.GetComponent<Activity>().Check();
    }
}
