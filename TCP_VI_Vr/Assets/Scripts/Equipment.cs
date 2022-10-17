using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Merge, Tecnology
{
    public void SwitchOn()
    {
        throw new System.NotImplementedException();
    }
    public void SwitchOff()
    {
        throw new System.NotImplementedException();
    }

    public override void Combine(GameObject target)
    {
        LeanTween.move(target, base.target.position,0);
    }

    public void ChangeStatus()
    {
        throw new System.NotImplementedException();
    }
}