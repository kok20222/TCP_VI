using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dropDownController : MonoBehaviour
{
    //public GameObject dropdownLabel;
    //Text dropdownText;
    //public string dropdownValue;
    //public TextMeshProUGUI text;
   public void Start()
    {
       // dropdownText = dropdownLabel.GetComponent<Text>();
        //dropdownValue = dropdownText.text;
    }
    
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
           //tp
        }
        if (val == 1)
        {
           //andar
        }
    }
    /*public void pressed()
    {
        if (dropdownValue == "a")
        {
            Debug.Log("0");
        }
        if (dropdownValue == "b")
        {
            Debug.Log("1");
        }
    }
    */
}
