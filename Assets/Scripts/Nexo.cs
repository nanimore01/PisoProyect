using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexo : MonoBehaviour
{
    public static Nexo instance;
    [SerializeField] private int _vidaMax = 5;
    [SerializeField] private int _vida;
    [SerializeField] TextoActualizable texto;
    [SerializeField] AudioSource _audio;

    private void Start()
    {
        _vida = _vidaMax;
        texto.UpdateHUDActualInt(_vida, _vidaMax, " Nexo");
        if (instance == null)
            instance = this;
    }

    public void dano()
    {
        _vida--;
        texto.UpdateHUDActualInt(_vida, _vidaMax, " Nexo");
        _audio.Play();
        if (_vida <= 0)
        {
            print("Sufri mucho daño");
            Jugador.instance.Morir();  
        }
    }
    
}
