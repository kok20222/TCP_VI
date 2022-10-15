using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    // Start is called before the first frame update
     void Start() {
        instance = this;
    }
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void panelTrue(GameObject go){
        go.SetActive(true);
    }
     public void panelFalse(GameObject go){
        go.SetActive(false);
    }
    public void nextScene(int nextSceneIndex){
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void movimentacaoConfig(int mov){
        if(mov==0){//tp
            //movimentaciontConfig.instance.teleportEnable=true;
        }
        if(mov==1){//joystick
            //movimentaciontConfig.instance.teleportEnable=false;
        }

    }

}
