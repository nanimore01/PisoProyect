using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemigoBase : MonoBehaviour, IDashable
{
    [Header("Valores")]
    [SerializeField] protected int _monedasDadas;
    [SerializeField] protected float _tamaño;
    

    public void ActiveDash()
    {
        Jugador.instance.target = transform;
        Jugador.instance.dir = transform.position - Jugador.instance.transform.position;
        Jugador.instance.rb.useGravity = false;
        Jugador.instance.rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Jugador>() != null)
        {
            collision.collider.GetComponent<Jugador>().target = null;
            collision.collider.GetComponent<Jugador>().Impacto();
            collision.collider.GetComponent<Jugador>()._concentracionTimeCurr = 0;
            gameObject.SetActive(false);
        }
    }



}
