using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaMaquina : MonoBehaviour
{
    public static PortaMaquina instance;
    public bool fechado=true;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

      
        if (other.CompareTag("areaMaquina"))
        {
            fechado=true;
            Debug.Log("fechou");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {

      
        if (other.CompareTag("areaMaquina"))
        {
            fechado=false;
            Debug.Log("abriu");
            
        }
    }
}
