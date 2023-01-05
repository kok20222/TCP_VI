using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public Slider volumeSom, volumeSom2; 
    public Slider volumeEffect, vol2;
    public AudioSource msc, som1, som2;
     public AudioSource maquina;
     public AudioSource geladeira;
    public AudioSource efx;
    public AudioSource efxCena;
    public AudioSource acabandoTempo;
    public AudioClip btnCllick;
    public AudioClip[] audiosClips;
    void Start()
    {
        instance =this;
        volumeSom.value=0.5f;
        volumeSom2.value=0.5f;
        volumeEffect.value=0.5f;
        vol2.value=0.5f;
         msc.volume = volumeSom2.value/2;
            som1.volume = volumeSom2.value*4;
            som2.volume = volumeSom2.value*4;
            maquina.volume = vol2.value*3;
            geladeira.volume = vol2.value;
            efxCena.volume = vol2.value*2;
            acabandoTempo.volume = vol2.value*2;
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
            msc.volume = volumeSom2.value/2;
            som1.volume = volumeSom2.value*4;
            som2.volume = volumeSom2.value*4;
            volumeSom.value =volumeSom2.value;
        }
        public void ListenerMethod2(float v)
        {
            msc.volume = volumeSom.value/2;
            som1.volume = volumeSom.value*4;
            som2.volume = volumeSom.value*4;
            volumeSom2.value =volumeSom.value;
        }
        public void ListenerMethod3(float v)
        {
           efx.volume = vol2.value*2;
           efxCena.volume = vol2.value*2;
           acabandoTempo.volume = vol2.value*2;
           maquina.volume = vol2.value*3;
           geladeira.volume = vol2.value;
           volumeEffect.value = vol2.value;
        }
        public void ListenerMethod4(float v)
        {
           efx.volume = volumeEffect.value*2;
           efxCena.volume = volumeEffect.value*2;
           acabandoTempo.volume = volumeEffect.value*2;
           maquina.volume = volumeEffect.value*3;
           geladeira.volume = volumeEffect.value;
           vol2.value = volumeEffect.value;
        }
    
    public void botaoSound(){
        efx.clip=btnCllick;
        efx.Play();
    }
    public void efeitoInterface(AudioClip clipEscolhido){
        efx.clip=clipEscolhido;
        efx.Play();
    }
    public void efeitosound(AudioClip clipEscolhido){
        efxCena.clip=clipEscolhido;
        efxCena.Play();
    }
}
