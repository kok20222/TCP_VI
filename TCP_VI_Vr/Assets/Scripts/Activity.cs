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
    [System.Serializable]
    public class IndetifiedFeedback
    {
        public Instruction id;
        public UnityEvent FeedbackEvent;
    }
    [RequireComponent(typeof(BoxCollider))]
    public class Activity : Duraction
    {
        public List<Steps> steps;
        public UnityEvent eventFeedback;
        public List<IndetifiedFeedback> indetifiedFeedback;
        private Dictionary<string, UnityEvent> keyValuePairs = new Dictionary<string, UnityEvent>();
        public UnityEvent eventInterrupt;
        private Dictionary<string, Collider> targets;
        private float countTime = -1;
        private float currentLife;
        private ActivityState currente = ActivityState.to_do;
        private Destiction destiction;
        private string instruction;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            targets = new Dictionary<string, Collider>();

            foreach (IndetifiedFeedback IF in indetifiedFeedback)
            {
                keyValuePairs[IF.id.name] = IF.FeedbackEvent;
            }
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
            foreach (var v in targets.Keys)
            {
                Debug.Log("targets " + targets[v].name);
            }
            foreach (Steps s in steps)
            {
                foreach (Instruction i in s.instructions)
                {
                    int verified = 0;
                    foreach (Mandatory mandatory in i.destiction.mandatory)
                    {
                        //em vez de imperdir que uma tarefa seja feita é preferivel não pontuar
                        Debug.Log("mandatorio " + mandatory.element.name);
                        if (targets.ContainsKey(mandatory.element.name) && i.level <= s.level)
                        {
                            verified++;
                            if (verified == i.destiction.mandatory.Count)
                            {
                                s.Check = true;
                                countTime = i.life;
                                currentLife = i.life;
                                destiction = i.destiction;
                                instruction = i.name;
                                currente = ActivityState.does;
                                return;
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
                    //if (mandatory.element.GetComponent<Tool>() != null)
                    //{
                    //    targets[mandatory.element.name].GetComponent<Tool>().Use(destiction.nextState);
                    //}
                }

            }
            foreach (GameObject go in destiction.bonus)
            {
                // coleta os bonos e aplica seus valores a atividade
            }
        }
        private void Interrupt()
        {
            if (keyValuePairs.ContainsKey(instruction))
            {
                Punshiument();
            }
        }
        private void Punshiument()
        {
            throw new System.NotImplementedException();
        }
        private void Feedback()
        {
            if (keyValuePairs.ContainsKey(instruction))
            {
                keyValuePairs[instruction].Invoke();
            }
            else
            {
                eventFeedback.Invoke();
            }
        }
        public float GetCurrentTimeActivity()
        {
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