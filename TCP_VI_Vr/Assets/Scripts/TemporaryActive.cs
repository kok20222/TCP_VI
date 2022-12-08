using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    
    public Activity target;

    
    private void OnTriggerEnter(Collider other)
    {

      
        if (other.CompareTag("hand"))
        {
              
            target.GetComponent<Activity>().Check();
        }
    }
  
    
}
