using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour
{
    private GameObject target;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grab"))
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePresent)
            {
                target = other.gameObject;
                other.GetComponent<Tecnology>().occupied = true;
            }
        }
    }

    private void Update()
    {
        if (target != null)
            if (target.GetComponent<Tecnology>().occupied)
            {
                Vector3 pos = target.transform.position;
                pos = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(5);
                target.transform.position = pos;
                if (Input.GetMouseButtonUp(0))
                {
                    target.GetComponent<Tecnology>().occupied = false;
                    target = null;
                }
            }
    }
}
