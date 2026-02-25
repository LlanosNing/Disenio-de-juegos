using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    public bool isActive = false;
    public LayerMask detectLayer;

    public LineRenderer lineRend;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        //configurar el Line para que una los dos puntos
        lineRend.positionCount = 2;
        lineRend.SetPosition(0, leftPoint.position);
        lineRend.SetPosition(1, rightPoint.position);
    }

    private void Update()
    {
        if(isActive == true)
        {
            LaserDetect();
        }
    }

    void LaserDetect()
    {
        if (Physics.Linecast(leftPoint.position, rightPoint.position))
        {
            Debug.Log("Estas muerto");
        }

    }
}
