using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TargetSystem;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tecnology_ : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Tecnology>() != null)
        //{
        //    switch (other.GetComponent<Tecnology>().occupation)
        //    {
        //        case TEC_STATE.tool:
        //            target = other.gameObject;
        //            break;
        //        case TEC_STATE.equipment:
        //            target = other.gameObject;
        //            break;
        //    }
        //}
    }


    public void Combine()
    {
        //if (target != null)
        //{
        //    if (target.GetComponent<Tecnology>() != null)
        //    {
        //        if (target.GetComponent<Tecnology>().targets.Count > 0)
        //        {
        //            targetIndex = (targetIndex + 1) % target.GetComponent<Tecnology>().targets.Count;
        //            LeanTween.move(gameObject, target.GetComponent<Tecnology>().targets[targetIndex].transform.position, .4f);
        //        }
        //        target = null;
        //    }
        //}
    }

    public virtual void ChangeStatus()
    {
        throw new System.NotImplementedException();
    }
}
