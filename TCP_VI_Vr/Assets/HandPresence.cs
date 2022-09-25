using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{   
    int framesToSkip;

    private InputDevice targetDevice;
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
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

       // InputDevices.GetDevices(devices);


        foreach(var item in devices)
        {

            Debug.Log(item.name + item.characteristics);



        }
        if(devices.Count > 0){

            targetDevice = devices[0];

        }

        framesToSkip = 0;
        }







        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(primaryButtonValue){

                  Debug.Log("pressing Primary Button");
        }
           

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if(triggerValue > 0.1f){

            Debug.Log("Trigger pressed" + triggerValue);
        }


        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if(primary2DAxisValue != Vector2.zero){

            Debug.Log("Primary Touchpad" + primary2DAxisValue);
        }

    }
}
