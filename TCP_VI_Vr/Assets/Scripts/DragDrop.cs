using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private GameObject target;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Activity"))
        {
            if (other.CompareTag("reposition"))
            {
                target = other.gameObject;
                if (Input.GetMouseButton(0) && Input.mousePresent)
                {
                    other.GetComponent<Tecnology>().occupied = true;
                }
            }
        }
    }

    private void Update()
    {
        if(target != null)
        if (target.GetComponent<Tecnology>().occupied)
        {
            if (Input.GetMouseButtonUp(0))
            {
                target.GetComponent<Tecnology>().occupied = false;
            }
            Vector3 pos = target.transform.position;
            pos = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(5);
            target.transform.position = pos;
        }
    }
}
