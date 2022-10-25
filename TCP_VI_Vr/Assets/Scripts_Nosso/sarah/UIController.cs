using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseUi;
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
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
    public void PauseGame()
    {//chamar m�todo
        Time.timeScale = 0;
        pauseUi.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}