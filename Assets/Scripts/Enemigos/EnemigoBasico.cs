using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : EnemigoBase
{
    // Start is called before the first frame update
    void Start()
    {
        _size = StatsUnidadesEnemigas.EnemigoBasico.size;
        _monedasDadas = StatsUnidadesEnemigas.EnemigoBasico.monedasDadas;
    }

    
}
