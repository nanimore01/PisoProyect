using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeightPointer 
{

    public static readonly FlyWeight EnemigoBasico = new FlyWeight
    {
        monedasDadas = 2,
        weight = 1,
    };

    public static readonly FlyWeight EnemigoTorreta = new FlyWeight
    {
        monedasDadas = 5,
        weight = 1,
    };

    public static readonly FlyWeight EnemigoMovil = new FlyWeight
    {
        monedasDadas = 2,
        weight = 1,
    };
}
