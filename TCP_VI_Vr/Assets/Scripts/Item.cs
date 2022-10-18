using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TargetSystem
{
    [System.Serializable]
    [RequireComponent(typeof(BoxCollider))]
    public class  Item: Tecnology
    {
        public string description;
        public List<State> state;
        public string classification;
        public float amount;

        public void Consume(List<State> state)
        {
            this.state = state;
        }

        public void Use()
        {
            throw new System.NotImplementedException();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
    public enum State {
        dry, 
        wel, 
        crumpled, 
        unwrinkled, 
        burne, 
        frozen, 
        crooked, 
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
