using InstructionSystem;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;
using UnityEngine.Events;

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
        public int level;
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
        public UnityEvent eventFeedback;
        public UnityEvent eventInterrupt;
        private Dictionary<string, Collider> targets;
        private float countTime = -1;
        private float currentLife;
        private ActivityState currente = ActivityState.to_do;
        private Destiction destiction;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            targets = new Dictionary<string, Collider>();
        }
        private void Update()
        {
            switch (currente)
            {
                case ActivityState.to_do:
                    break;
                case ActivityState.does:
                    {
                        countTime -= Time.deltaTime;
                        if (countTime < 0)
                        {
                            currente = ActivityState.done;
                            MakeThis();
                        }
                        break;
                    }
                case ActivityState.done:
                    currente = ActivityState.to_do;
                    Feedback();
                    break;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Grab"))
            {



                targets[other.name] = other;

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
                        if (targets.ContainsKey(mandatory.element.name) && i.level <= s.level)
                        {
                            verified++;
                            if (verified == i.destiction.mandatory.Count)
                            {
                                s.Check = true;
                                countTime = i.life;
                                currentLife = i.life;
                                destiction = i.destiction;
                                currente = ActivityState.does;
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
        private void MakeThis()
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
            eventInterrupt.Invoke();
            Punshiument();
        }
        private void Punshiument()
        {
            throw new System.NotImplementedException();
        }
        private void Feedback()
        {
            eventFeedback.Invoke();
        }
        public float GetCurrentTimeActivity() {
            if (currentLife - countTime > currentLife)
                return currentLife;
            return currentLife - countTime;
        }
    }

    public enum ActivityState
    {
        to_do, does, done
    }
}