using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurumKibab : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 2);
    }
}
