using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceCharacter : MonoBehaviour
{
    public Rigidbody ball;
    public Vector3 offset;
    private Animator anim;
    //todas las partes del ragdoll
    public Rigidbody[] bodyParts;
    public float growDuration = 10;

    private float growTimer;

    private void Start()
    {
        TryGetComponent(out anim);
        //buscar todas las parrtes del cuerpo del ragdoll
        bodyParts = GetComponentsInChildren<Rigidbody>();
        //de inicio el ragdoll tiene que estar desactivado
        EnableRagdoll(false);
    }

    void Update()
    {
        transform.position = ball.transform.position + offset;
        anim.SetFloat("Direction", Mathf.Sign(ball.velocity.z));

        //ha terminado el temporizador del tamño y estaba agrandado
        if(Time.time >= growTimer && transform.localScale.x > 1)
        {
            //reiniciar el tamaño al valor original
            transform.localScale = Vector3.one;
        }
    }

    public void Die()
    {
        //activar el ragdoll
        EnableRagdoll(true);
        //se desactiva este script para que no siga más a la pelota
        this.enabled = false;
    }

    void EnableRagdoll(bool enable)
    {
        //activar el animator cuando se desactiva el ragdoll y viceversa
        anim.enabled = !enable;

        //activar el kinematic cuando se desactiva el ragdoll y viceversa
        foreach (Rigidbody part in bodyParts) { 
        part.isKinematic = !enable;
        }
    }

    public void Grow()
    {
        //aumentar el tamaño del personaje
        transform.localScale *= 1.1f;
        //reiniciar el temporizador de volver al tamaño normal  
        growTimer = Time.time + growDuration;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //si detecta que choca contra algo que lo mata, se muere
        if (collision.collider.CompareTag("Kill"))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //si detecta una seta, SE LA COME JUAJUAJUAs
        if (other.CompareTag("Mushroom"))
        {
            Grow();
            //destruir la setita
            Destroy(other.gameObject);
        }
    }
}
