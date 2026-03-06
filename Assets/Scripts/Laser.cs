using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    public bool isActive = false;
    public LayerMask detectLayer;
    public float delay = 0.5f; //retardo antes de que aparezca el laser
    public float duration = 2;//cuanto dura el laser

    public LineRenderer lineRend;

    //usar awake para que se haga antes que OnEnable
    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
    }
    private void OnEnable()
    {
        StartCoroutine(LaserCrt());
    }

    IEnumerator LaserCrt()
    {
        //calcular una posicion aleatoria para el eje z
        int zPos = Random.Range(-6, 7);
        transform.position = new Vector3(0, transform.position.y, zPos);
        //retardo antes de activar el laser
        yield return new WaitForSeconds(delay);
        isActive = true;
        //configurar el line para que una los dos puntos
        lineRend.positionCount = 2;
        lineRend.SetPosition(0, leftPoint.position);
        lineRend.SetPosition(1, rightPoint.position);
        //esperar a que termine y renderizarlo
        yield return new WaitForSeconds(duration);
        lineRend.positionCount = 0;
        isActive = false;
        gameObject.SetActive(false);
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
        if (Physics.Linecast(leftPoint.position, rightPoint.position, out RaycastHit hit, detectLayer))
        {
            Debug.Log("Estas muerto");
            //llamar a la funcion de morir del personaje
            hit.collider.GetComponent<BalanceCharacter>().Die();
            //desactivar el laser
            isActive = false;
        }

    }
}
