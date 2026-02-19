using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    public Vector2 timeToRotate = new Vector2(1.5f, 2.5f);//Tiempo que espera para rotar
    public Vector2 RotationRange = new Vector2(-10, 10);//Valor minimo y maximo de rotacion posible+
    //Rotacion que debe tener la plataforma
    private Quaternion rot;
    public float rotationSpeed = 4f;

    void Start()
    {
        StartCoroutine(RotateCO());
    }
    private void Update()
    {
        //Interpolar la rotación de la plataforma
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
    }
    private IEnumerator RotateCO()
    {
        while (true)
        {
            //Esperar un tiempo aleatorio
            yield return new WaitForSeconds(Random.Range(timeToRotate.x, timeToRotate.y));
            //Aplicar rotacion aleatoria
            float rotX = Random.Range(RotationRange.x, RotationRange.y);
            float rotZ = Random.Range(RotationRange.x, RotationRange.y);
            //transform.rotation = Quaternion.Euler(rotX, 0, rotZ);
            rot = Quaternion.Euler(rotX, 0, rotZ);
        }
    }
}
