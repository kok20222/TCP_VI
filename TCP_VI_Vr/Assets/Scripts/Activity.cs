using InstructionSystem;
using System.Collections;
using System.Collections.Generic;
using TargetSystem;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace ActivitSystem
{
    public abstract class Duraction : MonoBehaviour
    {
        [HideInInspector] public float start;
        [HideInInspector] public float end;
    }
 
    [RequireComponent(typeof(BoxCollider))]
    public class Activity : Duraction
    {
        public Instruction instruction;
        [SerializeField] public List<Target> involved;
        private ActivityState state;
        public PlayerInteraction player;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        private float timeAmount;

        private void Check()
        {
        }
        private void MakeThis()
        {
        }
        private void Interrupt()
        {
        }
        private void Punshiument()
        {
        }
        private void Feedback()
        {
        }
    }
    public enum PlayerInteraction { 
        sttoped,
        free,
        coupled
    }
    public enum ActivityState
    {
        to_do, does, done
    }
    public class Attribbuts {
        public string description;
        public float onus;
        public float bonus;
    }
}