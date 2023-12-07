using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DatosJugador : MonoBehaviour
{
    public static DatosJugador Instance;

    

    public int vidaMax = 0;
    public float speed = 2;
    public float tiempoDeConcentracion = 3;
    public int monedas = 1;
    public int monedasConseguidasPorHordas;
    
    private void Awake()
    {
        Save();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    

    public void Save()
    {
        print("Me guardo");

        PlayerPrefs.SetInt("Vidas maximas", vidaMax);
        PlayerPrefs.SetFloat("Velocidad de Dash", speed);
        PlayerPrefs.SetFloat("Tiempo de concentracion", tiempoDeConcentracion);
        PlayerPrefs.SetInt("Monedas Conseguidas", monedas);

        PlayerPrefs.Save();
    }
   
    public void Load()
    {
        print("Me cargo");
        monedas = PlayerPrefs.GetInt("Monedas Conseguidas");
        speed = PlayerPrefs.GetFloat("Velocidad de Dash");
        vidaMax = PlayerPrefs.GetInt("Vidas maximas");
        tiempoDeConcentracion = PlayerPrefs.GetFloat("Tiempo de concentracion");
        
    }
    
    public void ReiniciarStats()
    {
        monedasConseguidasPorHordas = 0;
    }

    
    public void MonedasAgarrada(int monedasObtenidas)
    {
        print("Moneda Agarrada : " + monedasObtenidas);
        monedas += monedasObtenidas;
        print("Monedas : " + monedas);
        PlayerPrefs.Save();
    }
}

