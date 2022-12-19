using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

public class Equipment : MonoBehaviour, ITecnology
{
    public string description;
    public List<State> states;
    private GameObject target;
    public List<Transform> targets;
    private int targetIndex = 0;

    public int Amount => targets.Count;

    public Vector3 Position => targets[targetIndex].transform.position;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ITecnology>() != null)
        {
            target = other.gameObject;
        }
    }
    public void Combine()
    {
        if (target != null)
        {
            if (target.GetComponent<ITecnology>().Amount > 0)
            {
                targetIndex = (targetIndex + 1) % target.GetComponent<ITecnology>().Amount;
                LeanTween.move(gameObject, target.GetComponent<ITecnology>().Position, .4f);
            }
            if (target.GetComponent<ITecnology>().Amount == 1)
            {

                LeanTween.move(gameObject, target.GetComponent<ITecnology>().Position, .4f);
            }
            target = null;
        }
    }
    public void SwitchOn()
    {
        throw new System.NotImplementedException();
    }
    public void SwitchOff()
    {
        throw new System.NotImplementedException();
    }

    void ITecnology.Combine()
    {
        throw new System.NotImplementedException();
    }
}