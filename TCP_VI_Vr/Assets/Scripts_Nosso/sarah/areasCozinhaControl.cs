using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areasCozinhaControl : MonoBehaviour
{
    public static areasCozinhaControl instance;
    public GameObject[] area;
    public void Start(){
        instance=this;
    }
    public void control(){
        area[1].SetActive(true);
        area[0].SetActive(false);
        area[2].SetActive(false);
    }
    public void control2(){
        area[2].SetActive(true);
        area[0].SetActive(false);
        area[1].SetActive(false);
    }
    public void control3(){
        area[2].SetActive(false);
        area[0].SetActive(false);
        area[1].SetActive(false);
    }
}

