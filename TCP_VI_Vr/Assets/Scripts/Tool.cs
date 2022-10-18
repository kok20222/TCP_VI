using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

public class Tool : Tecnology
{
    public override void ChangeStatus()
    {
        throw new System.NotImplementedException();
    }

    public override void Combine(GameObject target)
    {
        LeanTween.move(target, base.target.position, .4f);
    }

}
