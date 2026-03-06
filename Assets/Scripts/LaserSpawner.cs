using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public Laser laser;
    public Vector2 minMaxTime = Vector2.one;

    private void Start()
    {
        StartCoroutine(SpawnCrt());
    }

    IEnumerator SpawnCrt()
    {
        while (true)
        {
            //sumar la duracion al tiempo aleatorio para que de tiempo a que se desactive
            yield return new WaitForSeconds(Random.Range(minMaxTime.x, minMaxTime.y) + laser.duration);
            laser.gameObject.SetActive(true);
        }
    }
}
