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
    public class Item : Tecnology
    {
        public string description;
        public List<State> states;

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
