using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public TextMeshProUGUI MonedasTexto;
    public PoderBase[] poderes;

    public void Start()
    {
        MonedasUpdate();
    }

    public void MonedasUpdate()
    {
        MonedasTexto.text = PlayerPrefs.GetInt("Monedas Conseguidas") + "$";
    }

    public void ComprarPoder(int index)
    {
        if (poderes[index].precio <= DatosJugador.Instance.monedas)
        {
            DatosJugador.Instance.monedas -= poderes[index].precio;
            poderes[index].Poder();
            DatosJugador.Instance.Save();
        }
    }
   
}
