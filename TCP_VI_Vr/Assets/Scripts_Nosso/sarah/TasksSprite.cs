using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksSprite : MonoBehaviour
{
    //Animator m_Animator;
    SpriteRenderer m_SpriteRenderer;
    GameObject mainCharacter;
    float distancePlayer;
    public float maxDistance;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //m_Animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        mainCharacter = GameObject.FindWithTag("MainCamera");
        distancePlayer = Vector3.Distance(mainCharacter.transform.position, transform.position);
        if (distancePlayer > maxDistance)
        {
            m_SpriteRenderer.enabled = false;
            //m_Animator.SetTrigger("fadeOut");
            //m_Animator.ResetTrigger("fadeIn");
        }
        else { 
            m_SpriteRenderer.enabled = true;
            //m_Animator.SetTrigger("fadeIn");
            //m_Animator.ResetTrigger("fadeOut");
        }
    }
}
