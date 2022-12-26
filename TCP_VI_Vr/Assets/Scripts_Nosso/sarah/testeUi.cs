using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeUi : MonoBehaviour
{
    public void chooseMov( GameObject[] go  ){
        go[0].SetActive(true);
        go[1].SetActive(false);
    }

}
