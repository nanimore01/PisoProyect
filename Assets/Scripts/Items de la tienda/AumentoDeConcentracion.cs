using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDeConcentracion : PoderBase
{
    
    private void Start()
    {
        poderNombre = "Aumento de Concentracion";
        precio = 200;

        textoNombre.text = poderNombre;
        textoPrecio.text = precio.ToString();
    }

    public override void Poder()
    {
        DatosJugador.Instance.tiempoDeConcentracion++;
        DatosJugador.Instance.Save();
    }

}
