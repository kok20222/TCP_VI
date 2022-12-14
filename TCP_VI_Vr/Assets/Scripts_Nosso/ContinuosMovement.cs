using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuosMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;
    public bool auxAndar=false;
    private float fallingSpeed;

    private XROrigin rig;
    private Vector2 inputAxis;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {

        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        //if(inputAxis!=)
        Vector3 aux=new Vector3(inputAxis.x, 0, inputAxis.y);
        if(aux.x!=0||aux.y!=0||aux.z!=0){
            //chamar passos aqui
            if(auxAndar==false){
                 AudioController.instance.efeitosound(AudioController.instance.audiosClips[7]);
                 auxAndar=true;
            }
           

        }else{
            AudioController.instance.efxCena.Stop();
            auxAndar=false;
        }
        
    }



    private void FixedUpdate(){

        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw *  new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        // gravidade
        bool isGrounded = CheckIfGrounded();
        if(isGrounded){

            fallingSpeed = 0;

        }else{

             fallingSpeed += gravity * Time.fixedDeltaTime;
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

        }
       
    }


    void CapsuleFollowHeadset(){


        character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth , capsuleCenter.z);

    }

    bool CheckIfGrounded(){


        // checar se est?? no ch??o

        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hisInfo, rayLength, groundLayer );
        return hasHit;

    }
}
