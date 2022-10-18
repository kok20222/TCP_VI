using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tecnology : MonoBehaviour
{
    public Transform target;
    public bool occupied = false;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Tecnology>() != null)
        {
            if (!other.GetComponent<Tecnology>().occupied)
            {
                Combine(other.gameObject);
            }
        }
    }
    public virtual void Combine(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ChangeStatus()
    {
        throw new System.NotImplementedException();
    }
}
