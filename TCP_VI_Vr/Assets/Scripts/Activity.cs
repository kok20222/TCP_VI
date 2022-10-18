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
        private Dictionary<string, Collider> targets;

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
                }

            }
            foreach (GameObject go in destiction.bonus)
            {
                // coleta os bonos e aplica seus valores a atividade
            }
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

    public enum ActivityState
    {
        to_do, does, done
    }
}