using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRespawneable : ObjetoBase
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Jugador>() != null)
        {
            collision.collider.GetComponent<Jugador>().target = null;
            StartCoroutine(CooldownRespawn());
            gameObject.SetActive(false);
            
        }
    }
}
