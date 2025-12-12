using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsProyectilesEnemigos 
{
    public static readonly StatsProyectil BalaNormal = new StatsProyectil()
    {
        speed = 0.1f,
        maxDistance = 10,
    };
    public static readonly StatsProyectil BalaRapida = new StatsProyectil()
    {
        speed = 0.5f,
        maxDistance = 20,
    };
    public static readonly StatsProyectil Bomba = new StatsProyectil()
    {
        speed = 0.09f,
        maxDistance = 20,
    };

    public static readonly StatsProyectilesNexoBase RocaNormal = new StatsProyectilesNexoBase()
    {
        speed = 0.1f,
        maxDistance = 20,
        monedasDadas = 1,
        dano = 1,
        setColor = Color.white,
    };
    public static readonly StatsProyectilesNexoBase RocaPesada = new StatsProyectilesNexoBase()
    {
        speed = 0.05f, 
        maxDistance = 20,
        monedasDadas = 3,
        dano = 3,
        setColor = Color.magenta,
    };
    public static readonly StatsProyectilesNexoBase RocaRapida = new StatsProyectilesNexoBase()
    {
        speed = 0.2f,
        maxDistance = 20,
        monedasDadas = 5,
        dano = 1,
        setColor = Color.cyan,
    };
}
