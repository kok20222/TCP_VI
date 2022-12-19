using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

public class Tool : MonoBehaviour, ITecnology
{
    public string description;
    public List<State> states;
    private GameObject target;
    public List<Transform> targets;
    private int targetIndex = -1;

    public int Amount => targets.Count;

    public Vector3 Position
    {
        get
        {
            if (targets.Count > 1)
            {
                targetIndex = (targetIndex + 1) % targets.Count;
            }
            else if (targets.Count == 1)
            {
                targetIndex = 0; 
            }
            return targets[targetIndex].transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ITecnology>() != null)
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ITecnology>() != null)
        {
            target = null;
        }
    }
    public void Combine()
    {
        if (target != null)
        {
            if (target.GetComponent<ITecnology>().Amount > 0)
            {
                LeanTween.move(gameObject, target.GetComponent<ITecnology>().Position, .4f);
            }
            if (target.GetComponent<ITecnology>().Amount == 1)
            {

                LeanTween.move(gameObject, target.GetComponent<ITecnology>().Position, .4f);
            }
            target = null;
        }
    }

    public void Use()
    {
    }
}
