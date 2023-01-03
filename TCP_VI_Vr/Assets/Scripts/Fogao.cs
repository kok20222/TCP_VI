using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fogao : MonoBehaviour
{
     public static Fogao instance;

    public TMP_Text comidaText;
    public int comida = 0;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
         if(comida==2){
            comidaText.text =   "Lavagem finalizada, precisa cortar!";
        }
        if(comida==3){
            comidaText.text =   "Corte finalizado, precisa cozinhar!";
        }
        if(comida==4){
            comidaText.text =   "Cozimento finalizado, comida pronta!";
        }
        
    }
}
