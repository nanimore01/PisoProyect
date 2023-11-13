using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_PlayerPref 
{
    int _vidaMax;
    float _speed;
    float _tiempoDeConcentracion;

    public Jugador_PlayerPref (int vidaMax, float speed, float tiempoDeConcentracion)
    {
        _vidaMax = vidaMax;
        _speed = speed;
        _tiempoDeConcentracion = tiempoDeConcentracion;
    }
    
    public void Stats()
    {
        PlayerPrefs.SetInt("Vidas maximas", _vidaMax);
        PlayerPrefs.SetFloat("Velocidad de Dash", _speed);
        PlayerPrefs.SetFloat("Tiempo de concentracion", _tiempoDeConcentracion);
    }

    public void UpgradeStats(string NombreDeStat, int StatsConInt, float StatsConFloat)
    {
        if(PlayerPrefs.HasKey(NombreDeStat))
        {
            if(StatsConInt > 0)
                PlayerPrefs.SetInt(NombreDeStat, StatsConInt);

            if (StatsConFloat == 0)
                PlayerPrefs.SetFloat(NombreDeStat, StatsConFloat);
        }
        PlayerPrefs.Save();
    }
}
