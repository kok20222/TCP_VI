using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lixo : MonoBehaviour
{



    public TMP_Text lixotexto1;
    public int lixos = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        lixotexto1.text =  lixos + "/5";


        
        
    }
    void OnTriggerEnter(Collider other){

            if(other.tag == "lixo"){ 


                 lixos ++;

            }
            



        }



        void OnTriggerExit(Collider other){

            if(other.tag == "lixo"){


                 lixos --;

            }
            



        }
}
