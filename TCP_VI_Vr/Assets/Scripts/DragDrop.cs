using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour
{
    private bool check = false;
    private GameObject target;
    //private Vector3 distance;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grab") /* && Input.GetMouseButtonDown(0)*/ )
        {
            //distance = other.transform.position-transform.position;
            //target = other.gameObject;
            // drag();
        }
        else if (other.GetComponent<ITecnology>() != null && other.gameObject.layer != LayerMask.NameToLayer("Grab")) {
            target = other.gameObject;
        }
    }

    public void drop()
    {
        //check = false;
        target.GetComponent<ITecnology>().Combine();
        target = null;

    }

    // public void drag()
    // {
    //     check = true;
    // }

 
    // private void Update()
    // {
    //     if (check)
    //     {
    //         if (Input.GetMouseButtonUp(0))
    //         {
    //             drop();
    //         }
    //         Transform t = target.GetComponent<Transform>().transform;
    //         t.position = transform.position + distance;
    //     }
    // }
}
