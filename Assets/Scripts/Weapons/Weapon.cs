using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float range = 5f;
    [SerializeField] protected float fireRate = 10;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected Vector3 spread = Vector3.zero;

    protected Camera cam;
    private float timeToShoot;

    private void Start()
    {
       cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > timeToShoot)
        {
            timeToShoot = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        Debug.Log("PIUM PIUM");
    }

    public Vector3 GetRandomSpread()
    {
        float x = Random.Range(-spread.x, spread.x);
        float y = Random.Range(-spread.y, spread.y);
        float z = Random.Range(-spread.z, spread.z);
    }
}
