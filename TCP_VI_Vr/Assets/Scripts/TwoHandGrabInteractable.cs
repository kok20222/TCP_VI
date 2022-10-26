using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TwoHandGrabInteractable : XRGrabInteractable
{

    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>();
    public XRBaseInteractor secondInteractor;
    public Quaternion attachInitialRotation;

    public enum TwoHandRotationType { None, First, Second };
    public TwoHandRotationType twoHandRotationType;

    public bool snapToSecondHand = true;
    public Quaternion initialRotationOffset;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in secondHandGrabPoints){


            item.onSelectEntered.AddListener(OnSecondHandGrab);
             item.onSelectExited.AddListener(OnSecondHandRelease);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase){

        if(secondInteractor && selectingInteractor){

            //rotação
            if(snapToSecondHand)
            selectingInteractor.attachTransform.rotation = GetTwoHandRotation();
            else
            selectingInteractor.attachTransform.rotation = GetTwoHandRotation() * initialRotationOffset;
        }

        

        base.ProcessInteractable(updatePhase);
    }

    public Quaternion GetTwoHandRotation(){

            Quaternion targetRotation;
            if (twoHandRotationType == TwoHandRotationType.None){

                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);

            }
            else if (twoHandRotationType == TwoHandRotationType.First){

                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.transform.up);

            }else 
            {

                targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.transform.up);
            }

            return targetRotation;


        }


    public void OnSecondHandGrab(XRBaseInteractor interactor){

       
       secondInteractor = interactor;
        
        initialRotationOffset = Quaternion.Inverse(GetTwoHandRotation()) * selectingInteractor.attachTransform.rotation;

    }


    public void OnSecondHandRelease(XRBaseInteractor interactor){

      secondInteractor = null;


    }

    protected override void OnSelectEntered(XRBaseInteractor interactor){

        Debug.Log("First GrabEnter");
       base.OnSelectEntered(interactor);
       attachInitialRotation = interactor.attachTransform.localRotation;
    }

     protected override void OnSelectExited(XRBaseInteractor interactor){

           Debug.Log("First Grab RELEASE");
        base.OnSelectExited(interactor);
        secondInteractor = null;
        interactor.attachTransform.localRotation = attachInitialRotation;
    }


    public override bool IsSelectableBy(XRBaseInteractor interactor){

        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }
}
