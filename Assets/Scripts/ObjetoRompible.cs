using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRompible : ObjetoBase
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Jugador>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
