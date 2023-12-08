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
    public static readonly StatsEnemigoTorreta EnemigoSuperTorreta = new StatsEnemigoTorreta
    {
        monedasDadas = 8,
        size = 2,
        velocidadDeRotacion = 8.2f,
        coolDown = 2,
    };
    public static readonly StatsEnemigoTorreta EnemigoMegaTorreta = new StatsEnemigoTorreta
    {
        monedasDadas = 10,
        size = 2.5f,
        velocidadDeRotacion = 12.2f,
        coolDown = 1,
    };


    public static readonly StatsEnemigoMovil EnemigoMovil = new StatsEnemigoMovil
    {
        monedasDadas = 2,
        size = 1,
        maxVelocity = 2,
    };

    public static readonly StatsEnemigoMovil EnemigoSuperMovil = new StatsEnemigoMovil
    {
        monedasDadas = 4,
        size = 1,
        maxVelocity = 2.5f,
    };

    public static readonly StatsEnemigoMovil EnemigoMiniMovil = new StatsEnemigoMovil
    {
        monedasDadas = 10,
        size = .5f,
        maxVelocity = 3.5f,
    };
}

