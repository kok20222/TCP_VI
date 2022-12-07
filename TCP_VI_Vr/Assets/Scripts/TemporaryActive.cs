using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryActive : MonoBehaviour
{

    bool check = false;

    
    public UnityEvent e = new UnityEvent();

    private void OnTriggerStay(Collider other)
    {

        
        if (other.CompareTag("hand") && check)
        {
            Debug.Log("entrou mão");
            check = false;
            e.Invoke();
            
        }


        
    }

    



    public void active() {

        
        check = true;
        
       

    }


}
