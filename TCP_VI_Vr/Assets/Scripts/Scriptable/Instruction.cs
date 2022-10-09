using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;

namespace InstructionSystem
{
    [CreateAssetMenu(fileName = "ActivitysInstruction", menuName = "Activity/Instruction", order = 1)]
    public class Instruction : ScriptableObject
    {
        public string description;
        public long idealTime;
        [SerializeField] public List<Pair> NextStep;
        private Dictionary<string, Instruction> next;
        public Attribbuts attribbuts;
        private void Awake()
        {
            if (NextStep != null)
            {
                next = new Dictionary<string, Instruction>();
                foreach (Pair p in NextStep)
                {
                    next[p.Key] = p.value;
                }
            }
        }
    }
    [System.Serializable]
    public struct Pair
    {
        public string Key;
        public Instruction value;
    }
}