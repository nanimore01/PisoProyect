using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.GetComponent<Jugador>()?.Morir();
    }
}
