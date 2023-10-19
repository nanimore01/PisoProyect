using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexo : MonoBehaviour
{
    public static Nexo instance;
    private int _vida = 1;
    public int vidaActual { get { return _vida; } }

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void dano()
    {
        _vida--;

        if (_vida <= 0)
        {
            Jugador.instance.Morir();  
        }
    }
    
}
