using ActivitSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{
    
    public Activity target;
    public string witchTask;
    private int iVaral=0;

    
    private void OnTriggerEnter(Collider other)
    {

      
        if (other.CompareTag("hand"))
        {
            
            Debug.Log("hand check");
            if(witchTask=="varal"){
                if(iVaral==0){
                    target.GetComponent<Activity>().Check(witchTask);
                    iVaral=1;
                }

            }else{
                target.GetComponent<Activity>().Check(witchTask);
                target.GetComponent<Activity>().auxMaquina=false;
            }
            
        }
    }
  
    
}
