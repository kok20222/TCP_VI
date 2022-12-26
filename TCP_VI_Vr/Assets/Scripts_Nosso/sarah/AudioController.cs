using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSom; 
    public Slider volumeEffect;
    public AudioSource msc;
    public AudioSource efx;
    public AudioClip btnCllick;
    void Start()
    {
        volumeSom.value=0.5f;
        volumeEffect.value=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
         msc.volume = volumeSom.value*2;
         efx.volume = volumeEffect.value*2;
    }
    public void botaoSound(){
        efx.clip=btnCllick;
        efx.Play();
    }
}
