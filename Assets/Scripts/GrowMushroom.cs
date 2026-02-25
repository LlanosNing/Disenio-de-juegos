using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMushroom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //cuando el player detecta la seta, se destruye
        if (other.CompareTag("Player") == false)
        {
            Destroy(gameObject);
        }
    }
}
