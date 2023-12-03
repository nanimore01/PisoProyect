using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : EnemigoBase
{
    // Start is called before the first frame update
    void Start()
    {
        _tamaño = StatsEnemigoBasico.EnemigoBasico.weight;
        _monedasDadas = StatsEnemigoBasico.EnemigoBasico.monedasDadas;
    }

    
}
