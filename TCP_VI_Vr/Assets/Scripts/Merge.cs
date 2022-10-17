using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

public class Merge: MonoBehaviour
{
    public Transform target;
    public bool occupied = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("reposition"))
        {
            if (!other.GetComponent<Merge>().occupied)
            {
                Combine(other.gameObject);
            }
        }
    }
    public virtual void Combine(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
