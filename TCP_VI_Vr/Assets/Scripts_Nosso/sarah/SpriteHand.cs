using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHand : MonoBehaviour
{
    // Start is called before the first frame update
    //SpriteRenderer m_SpriteRenderer;
    public GameObject canvasHand;
    public GameObject leftHand;
    float rotationZ;
    void Start()
    {
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         //leftHand = GameObject.FindWithTag("leftHand");
         rotationZ= leftHand.transform.rotation.z;
         Debug.Log(rotationZ);
         if (rotationZ > 0.1f && rotationZ<0.9f)
        {
           canvasHand.SetActive(true);
        }else{
           canvasHand.SetActive(false);
        }
    }
}
