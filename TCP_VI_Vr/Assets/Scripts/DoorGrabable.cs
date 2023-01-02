using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//using XRBaseInteractor.XR;

public class DoorGrabable : MonoBehaviour
{
   
   public Transform handler;

   public void GrabEnd()
   {

    

        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;


       // Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        //rbhandler.velocity = Vector3.zero;
        //rbhandler.angvelocity = Vector3.zero;


   }



   //private void Update(){

   // if(Vector3.distance(handler.postion, transform.position) > 0.4f)
    //{

   //     XRBaseInteractor.enableInteractions = false;
    //}


   //}
}
