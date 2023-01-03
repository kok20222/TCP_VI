using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Varal : MonoBehaviour
{
    public static Varal instance;

    public TMP_Text secarRoupa;
    public int roupas = 0;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
         if(roupas==2){
            secarRoupa.text =   "Secagem finalizada!";
        }
        
    }
}
