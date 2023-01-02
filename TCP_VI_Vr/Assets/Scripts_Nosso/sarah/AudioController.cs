using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSom, volumeSom2; 
    public Slider volumeEffect, vol2;
    public AudioSource msc;
    public AudioSource efx;
    public AudioClip btnCllick;
    void Start()
    {
        volumeSom.value=0.5f;
        volumeSom2.value=0.5f;
        volumeEffect.value=0.5f;
        vol2.value=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
         volumeSom2.onValueChanged.AddListener(ListenerMethod);
         volumeSom.onValueChanged.AddListener(ListenerMethod2);
         vol2.onValueChanged.AddListener(ListenerMethod3);
         volumeEffect.onValueChanged.AddListener(ListenerMethod4);
 
    }
        public void ListenerMethod(float v)
        {
            msc.volume = volumeSom2.value*2;
            volumeSom.value =volumeSom2.value;
        }
        public void ListenerMethod2(float v)
        {
            msc.volume = volumeSom.value*2;
            volumeSom2.value =volumeSom.value;
        }
        public void ListenerMethod3(float v)
        {
           efx.volume = vol2.value*2;
           volumeEffect.value = vol2.value;
        }
        public void ListenerMethod4(float v)
        {
           efx.volume = volumeEffect.value*2;
           vol2.value = volumeEffect.value;
        }
    
    public void botaoSound(){
        efx.clip=btnCllick;
        efx.Play();
    }
}