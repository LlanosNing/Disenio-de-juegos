using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int numberOfProjectiles = 40;
   protected override void Shoot()
    {
        //disparar un rayo por cada proyectil
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            //generar rayo al centro de la camara
            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, cam.nearClipPlane));
            //disparar el rayo
            ray.direction += GetRandomSpread();
            //disparar con Raycast
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log($"Shot: {hit.collider}");
            }
            //dibujar el rayo
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 2);
        }
    }
}
