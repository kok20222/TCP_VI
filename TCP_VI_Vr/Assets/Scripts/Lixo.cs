using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lixo : MonoBehaviour
{



    public TMP_Text lixotexto1;
    public int lixos = 0;
    bool aux=false;
    bool aux2=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        lixotexto1.text =  lixos + "/5";
    if(lixos==5){
        MenuController.instance.mental.value=1f;
        //MenuController.instance.panelTrue(MenuController.instance.checks[0]);
        //
        //MenuController.instance.panelTrue(MenuController.instance.checks[2]);
        //if(aux==false){
               // MenuController.instance.vitoryCond++;
               // aux=true;
            }
    //}else{
        //MenuController.instance.panelFalse(MenuController.instance.checks[0]);
       // MenuController.instance.panelFalse(MenuController.instance.checks[2]);
        //if(aux2==false && aux==true){
            //    MenuController.instance.vitoryCond--;
               // aux2=true;
               // aux = false;
          //  }
   // }

        
        
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
