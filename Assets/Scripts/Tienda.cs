using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public TextMeshProUGUI MonedasTexto;
    public PoderBase[] poderes;
    [SerializeField] AudioSource _audio;

    public void Start()
    {
        MonedasUpdate();
    }

    public void Update()
    {
        MonedasUpdate();
    }
    public void MonedasUpdate()
    {
        MonedasTexto.text = DatosJugador.Instance.monedas + "$";
        print("Me actualizo la cantidad de monedas");
    }

    public void ComprarPoder(int index)
    {
        if (poderes[index].precio <= DatosJugador.Instance.monedas)
        {
            _audio.Play();
            DatosJugador.Instance.monedas -= poderes[index].precio;
            poderes[index].Poder();
            DatosJugador.Instance.Save();
            MonedasUpdate();
        }
    }
   
}
