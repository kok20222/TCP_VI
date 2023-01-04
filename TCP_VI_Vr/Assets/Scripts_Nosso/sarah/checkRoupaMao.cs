using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkRoupaMao : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("roupa"))
        {
            AudioController.instance.efeitoInterface(AudioController.instance.audiosClips[6]);
        }
    }
}
