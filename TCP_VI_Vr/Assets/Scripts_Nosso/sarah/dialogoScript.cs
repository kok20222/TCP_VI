using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class dialogoScript : MonoBehaviour
{
    public TMP_Text dialogoUi;
    public GameObject setaUI;
    public GameObject fecharUi;
    public string[] dialogoText;
    public int idText=0;
    void Start()
    {
        dialogoUi.text = dialogoText[idText];
    }

    public void mudarId()
    {
            idText++;
            dialogoUi.text = dialogoText[idText];
            if (idText >= 4)
            {
                setaUI.SetActive(false);
                fecharUi.SetActive(true);
            }
    }
}
