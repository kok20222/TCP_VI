using InstructionSystem;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

namespace ActivitSystem
{
    public abstract class Duraction : MonoBehaviour
    {
        [HideInInspector] public float start;
        [HideInInspector] public float end;
    }
    [System.Serializable]
    public class Steps
    {
        public string name;
        private bool check = false;
        [SerializeField] public List<Instruction> instructions;

        public bool Check
        {
            get { return check; }
            set { check = value; }
        }
    }
    [RequireComponent(typeof(BoxCollider))]
    public class Activity : Duraction
    {
        public List<Steps> steps;
        private ActivityState state;
        private float timeAmount;
        private Dictionary<string, Collider> targets;
        private int amount = 0;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            targets = new Dictionary<string, Collider>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Activity"))
            {
                if (other.CompareTag("reposition"))
                {
                    targets[other.name] = other;
                }
            }
        }
        public void Check()
        {
            foreach (Steps s in steps)
            {
                foreach (Instruction i in s.instructions)
                {
                    int verified = 0;
                    foreach (Mandatory mandatory in i.destiction.mandatory)
                    {
                        if (targets.ContainsKey(mandatory.element.name))
                        {
                            verified++;
                            if (verified == i.destiction.mandatory.Count)
                            {
                                s.Check = true;
                                MakeThis(i.destiction);
                            }
                        }
                        else
                        {
                            verified--;
                        }
                    }
                }
                if (!s.Check)
                {
                    Punshiument();
                }
            }
        }
        private void MakeThis(Destiction destiction)
        {
            foreach (Mandatory mandatory in destiction.mandatory)
            {
                if (mandatory.target)
                {
                    if (mandatory.element.GetComponent<Item>() != null)
                    {
                        targets[mandatory.element.name].GetComponent<Item>().Consume(destiction.nextState);
                    }
                    if (mandatory.element.GetComponent<Tool>() != null)
                    {
                        targets[mandatory.element.name].GetComponent<Tool>().Use();
                        targets[mandatory.element.name].GetComponent<Tool>().ChangeStatus();
                    }
                    if (mandatory.element.GetComponent<Equipment>() != null)
                    {
                        targets[mandatory.element.name].GetComponent<Equipment>().SwitchOn();
                        targets[mandatory.element.name].GetComponent<Equipment>().ChangeStatus();
                    }
                }
            }
            //foreach (GameObject go in destiction.bonus)
            //{
            //    if (go.GetComponent<Item>() != null)
            //    {
            //        go.GetComponent<Item>().Consume(destiction.nextState);
            //    }
            //    if (go.GetComponent<Tool>() != null)
            //    {
            //        go.GetComponent<Tool>().Use();
            //        go.GetComponent<Tool>().ChangeStatus();
            //    }
            //    if (go.GetComponent<Equipment>() != null)
            //    {
            //        go.GetComponent<Equipment>().SwitchOn();
            //        go.GetComponent<Equipment>().ChangeStatus();
            //    }
            //}
        }
        private void Interrupt()
        {
            throw new System.NotImplementedException();
        }
        private void Punshiument()
        {
            throw new System.NotImplementedException();
        }
        private void Feedback()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface Tecnology
    {
        public void Combine(GameObject target);
        public void ChangeStatus();
    }

    public enum ActivityState
    {
        to_do, does, done
    }
}