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
            }
            if(witchTask=="maquina"){
                
                if(PortaMaquina.instance.fechado==true){
                    Debug.Log("mexeu");
                    target.GetComponent<Activity>().Check(witchTask);
                    target.GetComponent<Activity>().auxMaquina=false;
                   PortaMaquina.instance.fechado=false;
                   
                }

            }
            if(witchTask=="comidaLavar"){
                target.GetComponent<Activity>().auxFogao=false;
                target.GetComponent<Activity>().Check(witchTask);
                }
                if(witchTask=="comidaCortar"){
                target.GetComponent<Activity>().auxFogao=false;
                target.GetComponent<Activity>().Check(witchTask);
                }
                if(witchTask=="comidaCozinhar"){
                target.GetComponent<Activity>().auxFogao=false;
                target.GetComponent<Activity>().Check(witchTask);
                }
            }else{
                target.GetComponent<Activity>().Check(witchTask);
                
            }
            
        
        }
    }
  
    

