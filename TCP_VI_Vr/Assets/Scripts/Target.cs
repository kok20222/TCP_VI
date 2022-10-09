using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TargetSystem
{
    [System.Serializable]
    [RequireComponent(typeof(BoxCollider))]
    public class Target : MonoBehaviour, Tool, Equipment, Item
    {
        public string description;
        public List<State> state;
        public void ChangeStatus()
        {
            throw new System.NotImplementedException();
        }

        public void Combine()
        {
            throw new System.NotImplementedException();
        }

        public void Consume()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchOff()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchOn()
        {
            throw new System.NotImplementedException();
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
    public interface Tool: Tecnology
    {
        public void Use();
    }

    public interface Equipment : Tecnology
    {
        public void SwitchOn();
        public void SwitchOff();
    }

    public interface Item : Tecnology
    {
        public void Consume();
    }
    public interface Tecnology 
    {
        public void Combine();
        public void ChangeStatus();
    }
    public enum State {
        dry, wel, crumpled, unwrinkled, burne, frozen, crooked, crude, dirty, clean, entire, broke, scratched, occupied, free, empty, half, full
    }
}
