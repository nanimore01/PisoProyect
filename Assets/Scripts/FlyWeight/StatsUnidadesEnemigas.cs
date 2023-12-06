using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUnidadesEnemigas
{
    public static readonly StatsEnemigos EnemigoBasico = new StatsEnemigos
    {
        monedasDadas = 2,
        size = 1,
    };
    public static readonly StatsEnemigos EnemigoSuperBasico = new StatsEnemigos
    {
        monedasDadas = 6,
        size = 2,
    };

    public static readonly StatsEnemigoTorreta EnemigoTorreta = new StatsEnemigoTorreta
    {
        monedasDadas = 5,
        size = 1.5f,
        velocidadDeRotacion = 10.2f,
        coolDown = 2,
    };


    public static readonly StatsEnemigoMovil EnemigoMovil = new StatsEnemigoMovil
    {
        monedasDadas = 2,
        size = 1,
        maxVelocity = 2,
    };

}

