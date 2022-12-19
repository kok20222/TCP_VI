using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace TargetSystem
{
    [System.Serializable]
    [RequireComponent(typeof(BoxCollider))]
    public class Item : MonoBehaviour, ITecnology
    {
        public string description;
        public List<State> states;
        private GameObject target;
        public List<Transform> targets;
        private int targetIndex = 0;

        public int Amount => targets.Count;

        public Vector3 Position
        {
            get
            {
                if(targets.Count > 0)
                    targetIndex = (targetIndex + 1) % targets.Count;
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
        public void Combine() {
            if (target != null)
            {
                GetComponent<Rigidbody>().useGravity = false;
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
            else {
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
        public void Consume(List<State> state)
        {
            this.states = state;
        }
    }
    public enum State
    {
        dry,
        wel,
        crumpled,
        unwrinkled,
        burne,
        frozen,
        cooked,
        crude,
        dirty,
        clean,
        entire,
        broke,
        scratched,
        occupied,
        free
    }
}
