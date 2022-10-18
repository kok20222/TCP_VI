using ActivitSystem;
using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;


namespace InstructionSystem
{
    [CreateAssetMenu(fileName = "InstructionSystem", menuName = "Activity/Instruction", order = 1)]
    public class Instruction : ScriptableObject
    {
        public bool punishment;
        public int point;
        [SerializeField] public Destiction destiction;

    }
    [System.Serializable]
    public struct Destiction
    {
        public List<State> nextState;
        [SerializeField] public List<Mandatory> mandatory;
        public List<GameObject> bonus;
    }

    [System.Serializable]
    public struct Mandatory
    {
        public bool target;
        public GameObject element;
    }
}