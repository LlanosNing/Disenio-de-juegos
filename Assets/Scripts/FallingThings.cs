using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingThings : MonoBehaviour
{
    public float spawnRadius = 6f;
    private Vector3 spawnOrigin = Vector3.zero;
    public List<GameObject> thingsPrefabs;
    public Vector2 SpawnTimeRange = Vector2.one;

    void Start()
    {
       // spawnOrigin = transform.position;
        StartCoroutine(SpawnCO());
    }
    void SpawnThing()
    {
        //La funcion de random calcula un punto aleatorio dentro de una esfera de radio 1
        // Para aumentar el radio, se multiplica ese valor por el radio que queremos
        //Para mover la posicion de la esfera se le suma la posicion de origen que queremos
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + spawnOrigin;
        //Cambiar la posicion Y a un valor fijo
        spawnPosition.y = spawnOrigin.y;
        //Spawnear un objeto aleatorio en la posicion calculada
        int prefabIndex = Random.Range(0, thingsPrefabs.Count);
        Instantiate(thingsPrefabs[prefabIndex], spawnPosition, thingsPrefabs[prefabIndex].transform.rotation);

    }
    IEnumerator SpawnCO()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(SpawnTimeRange.x, SpawnTimeRange.y));
            SpawnThing();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(spawnOrigin, spawnRadius);
    }
}
