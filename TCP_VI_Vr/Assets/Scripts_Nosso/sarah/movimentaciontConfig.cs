using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentaciontConfig : MonoBehaviour
{
    public static movimentaciontConfig instance;
    //public GameObject ObjComScript;
    public bool teleportEnable;
     void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    
     void Start (){
        instance = this;
        //ObjComScript.GetComponent<"TeleportationProvider">().enabled = false;
       //ObjComScript.GetComponent<MenuController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
