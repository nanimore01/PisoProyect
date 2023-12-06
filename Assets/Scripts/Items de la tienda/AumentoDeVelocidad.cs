using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDeVelocidad : PoderBase
{
    private void Start()
    {
        poderNombre = "Aumento de velocidad";
        precio = 20;

        textoNombre.text = poderNombre;
        textoPrecio.text = precio.ToString();
    }

    public override void Poder()
    {
        
        DatosJugador.Instance.speed++;
        DatosJugador.Instance.Save();
    }
}
