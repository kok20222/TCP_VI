using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{   
    int framesToSkip;

    public static HandPresence instance;
    public InputDeviceCharacteristics ControllerCharacteristics;

    private InputDevice targetDevice;

  
    public GameObject handModelPrefab;

    private GameObject spawnedHandModel;

    private Animator handAnimator;
    public int  id;
    public bool aberto = false;
    public bool aberto2 = false;
     //Start is called before the first frame update
    void Start()
    {
        instance=this;
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
       



        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(primaryButtonValue && id==1 && aberto == false){

                UIController.instance.PauseGame();
                AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[0]);
                 
        }

if( id==0 &&aberto2==false){
         targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue2);

        
            if(primaryButtonValue2 ){
                
                    UIController.instance.panelTrue(UIController.instance.canvasHand);
                    AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[1]);
                    aberto2=true;
                
                
        }
        }
        if( id==0 &&aberto2==true){
         targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primaryButtonValue3);

        
            if(primaryButtonValue3 ){
                
                    UIController.instance.panelFalse(UIController.instance.canvasHand);
                    AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[1]);
                    aberto2=false;
                
                
        }
        }
        /*
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue3);

        if(primaryButtonValue3 && id==0 &&aberto2==true){

                
                    UIController.instance.panelFalse(UIController.instance.canvasHand);
                    aberto2=false;
                
                
                 
        }
        */
           // if(primaryButtonValue2 && id==0 &&aberto2==true){
        
                  //  UIController.instance.panelFalse(UIController.instance.canvasHand);
                   // aberto2=false;
                
           // }

        /*else if(primaryButtonValue && id==1 && aberto == true){

             UIController.instance.ResumeGame();

        }

*/
           

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
