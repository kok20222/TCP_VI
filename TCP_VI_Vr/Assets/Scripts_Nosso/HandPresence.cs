using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{   
    int framesToSkip;


    public InputDeviceCharacteristics ControllerCharacteristics;

    private InputDevice targetDevice;

  
    public GameObject handModelPrefab;

    private GameObject spawnedHandModel;

    private Animator handAnimator;
     //Start is called before the first frame update
    void Start()
    {
        
        framesToSkip = 10;

        
        
    }

 



    // Update is called once per frame
    void Update()
    {

        if(framesToSkip >= 2){
            framesToSkip--;

        }
         if(framesToSkip == 1){


            List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);

       // InputDevices.GetDevices(devices);


        foreach(var item in devices)
        {

            Debug.Log(item.name + item.characteristics);



        }
        if(devices.Count > 0){

            targetDevice = devices[0];
            
            
            spawnedHandModel = Instantiate(handModelPrefab,transform);
        }

        handAnimator = spawnedHandModel.GetComponent<Animator>();
        framesToSkip = 0;
        }

        if(framesToSkip == 0){{

             UpdateHandAnimation();

        }}
       



       // targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
       // if(primaryButtonValue){

         //        Debug.Log("pressing Primary Button");
       // }
           

       // targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
       // if(triggerValue > 0.1f){

          // Debug.Log("Trigger pressed" + triggerValue);
       // }


       // targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
       // if(primary2DAxisValue != Vector2.zero){

           //Debug.Log("Primary Touchpad" + primary2DAxisValue);
       // }

    }

    void UpdateHandAnimation(){

        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue )){

            handAnimator.SetFloat("Trigger", triggerValue);

        }
        else 
        {

            handAnimator.SetFloat("Trigger", 0);

        }



        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue )){

            handAnimator.SetFloat("Grip", gripValue);

        }
        else 
        {

            handAnimator.SetFloat("Grip", 0);

        }

    }


}
