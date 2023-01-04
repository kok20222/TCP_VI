using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    
    public Activity target;
    public string witchTask;

    
    private void OnTriggerEnter(Collider other)
    {

      
        if (other.CompareTag("hand"))
        {
            
            Debug.Log("hand check");
            target.GetComponent<Activity>().Check(witchTask);
            AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[4]);
            //AudioController.instance.efeitosound(AudioController.instance.audiosClips[5]);
        }
    }
  
    
}
