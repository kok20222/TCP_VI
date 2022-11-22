using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TargetSystem;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tecnology : MonoBehaviour
{
    public List<Transform> targets;
    private int targetIndex = 0;
    private GameObject target;
    public TEC_STATE occupation = TEC_STATE.item;
    public enum TEC_STATE { item, tool, equipment }

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Tecnology>() != null)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.GetComponent<Tecnology>() != null)
        {
            targetIndex = (targetIndex + 1) % target.GetComponent<Tecnology>().targets.Count;
        }
    }
    public void Combine()
    {
        if (target.GetComponent<Tecnology>().targets.Count > 0)
        {
            LeanTween.move(gameObject, target.GetComponent<Tecnology>().targets[targetIndex].transform.position, .4f);
        }
        target = null;
    }

    public virtual void ChangeStatus()
    {
        throw new System.NotImplementedException();
    }
}
