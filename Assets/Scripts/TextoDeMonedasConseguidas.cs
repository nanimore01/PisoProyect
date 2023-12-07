using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoDeMonedasConseguidas : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Conseguiste " + DatosJugador.Instance.monedasConseguidasPorHordas + "$ en esta run";
    }
}
