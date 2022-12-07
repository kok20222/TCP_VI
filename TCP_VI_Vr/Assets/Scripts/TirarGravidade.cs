using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarGravidade : MonoBehaviour
{
   

   private GameObject target;
    Rigidbody item;
    


   

    void OnTriggerEnter(Collider other) {

          if(other.tag == "roupa"){

            Debug.Log ("entrou");
            item = other.GetComponent<Rigidbody>();
            item.useGravity = false;
            item.constraints = RigidbodyConstraints.FreezePosition;
           // item.isKinematic = true;


          }
          
           

       }

         void OnTriggerExit(Collider other) {


          if(other.tag == "roupa"){
            
          Debug.Log ("saiu");
          item = other.GetComponent<Rigidbody>();
          Ativar();

          }
           
       
            
        }

        public void Ativar(){

          item.constraints = RigidbodyConstraints.None;
          item.useGravity = true;
          
          //item.isKinematic = false;

        }


}