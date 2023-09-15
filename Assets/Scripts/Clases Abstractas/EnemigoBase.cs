using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemigoBase : Entity, IDashable
{
    [Header("Valores")]
    [SerializeField] protected int _monedasDadas;
    [SerializeField] protected float _tamaño;

    public override void Morir()
    {
        gameObject.SetActive(false);
    }

    public void ActiveDash()
    {
        Jugador.instance.target = transform;
        Jugador.instance.rb.useGravity = false;
        Jugador.instance.rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Jugador>() != null)
        {
            collision.collider.GetComponent<Jugador>().target = null;
            collision.collider.GetComponent<Jugador>().Impacto(transform.position);
            collision.collider.GetComponent<Jugador>().concentracionTimeCurr = 0;
            Morir();
        }
    }



}
