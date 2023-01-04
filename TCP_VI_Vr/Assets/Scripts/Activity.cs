using InstructionSystem;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
        private string taskName;
        public bool auxMaquina=false;
        contagemRegressiva Contador1 = new contagemRegressiva();
        contagemRegressiva Contador2 = new contagemRegressiva();
        contagemRegressiva Contador3 = new contagemRegressiva();



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
                        if(taskName=="maquina"){
                            Maquina.instance.lavarroupa1.text =Contador1.FormatarTempo((int)countTime);
                            Maquina.instance.SETAS[0].SetActive(false);
                            Maquina.instance.SETAS[1].SetActive(false);
                            AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[4]);
                            if(auxMaquina==false){
                                AudioController.instance.maquina.Play();
                                auxMaquina=true;
                            }
                            AudioController.instance.maquina.Play();
                        }
                        if(taskName=="varal"){
                            Varal.instance.secarRoupa.text =Contador2.FormatarTempo((int)countTime);
                        }
                        if(taskName=="comidaLavar"||taskName=="comidaCortar"||taskName=="comidaCozinhar"){
                            Fogao.instance.comidaText.text =Contador3.FormatarTempo((int)countTime);
                        }
                        if (countTime < 0)
                        {
                            currente = ActivityState.done;
                             if(taskName=="maquina"){
                                Maquina.instance.roupas=2;
                                AudioController.instance.maquina.Stop();
                             }
                             if(taskName=="varal")Varal.instance.roupas=2;
                             if(taskName=="comidaLavar")Fogao.instance.comida=2;
                             if(taskName=="comidaCortar")Fogao.instance.comida=3;
                             if(taskName=="comidaCozinhar")Fogao.instance.comida=4;
                            MakeThis();
                        }else{
                             if(taskName=="maquina")Maquina.instance.roupas=1;
                             if(taskName=="varal")Varal.instance.roupas=1;
                             if(taskName=="comidaLavar"||taskName=="comidaCortar"||taskName=="comidaCozinhar"){
                                Fogao.instance.comida=1;
                             }

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
        public void Check(string nameTask)
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
                        //em vez de imperdir que uma tarefa seja feita � preferivel n�o pontuar
                        Debug.Log("mandatorio " + mandatory.element.name);
                        if (targets.ContainsKey(mandatory.element.name) && i.level <= s.level)
                        {
                            verified++;
                            if (verified == i.destiction.mandatory.Count)
                            {
                                taskName = nameTask;
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