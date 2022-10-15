using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHand : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer m_SpriteRenderer;
    GameObject leftHand;
    float rotationZ;
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         leftHand = GameObject.FindWithTag("leftHand");
         rotationZ= leftHand.transform.rotation.z;
         if (rotationZ > 0.1f && rotationZ<0.9f)
        {
            m_SpriteRenderer.enabled = true;
        }else{
            m_SpriteRenderer.enabled = false;
        }
    }
}
