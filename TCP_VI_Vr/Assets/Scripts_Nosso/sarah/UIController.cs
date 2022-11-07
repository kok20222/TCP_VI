using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;

//[RequireComponent(typeof(XRPlatformControllerSetup))]

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject pauseUi;
    //private XRPlatformControllerSetup _inputData;
    public GameObject camera;
    private bool pausado = false;
    private Vector3 rotateValue;
    private Vector3 positionValue;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        ResumeGame();
        //_inputData = GetComponent<XRPlatformControllerSetup>();
        rotateValue = new Vector3(0,0,0);
        positionValue = new Vector3(0,0,0);
    }
    

    void Update()
    {

        if(pausado == true){


              //pauseUi.transform.eulerAngles = rotateValue;
              //pauseUi.transform.position = positionValue;

        }

    }
    public void panelTrue(GameObject go)
    {
        go.SetActive(true);
    }
    public void panelFalse(GameObject go)
    {
        go.SetActive(false);
    }
    public void nextScene(int nextSceneIndex)
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    //if(TryGetFeatureValue(CoomonUsages.))
    public void PauseGame()
    {//chamar m�todo
        Time.timeScale = 0;
        pauseUi.SetActive(true);
        rotateValue = new Vector3(camera.transform.rotation.x, camera.transform.rotation.y, camera.transform.rotation.z);
        positionValue = new Vector3(camera.transform.position.x , camera.transform.position.y, camera.transform.position.z);
        pausado = true;
        //HandPresence.instance.aberto=true;
      

    }
    public void ResumeGame()
    {
        //HandPresence.instance.aberto=false;
        Time.timeScale = 1;
    }
   
}
