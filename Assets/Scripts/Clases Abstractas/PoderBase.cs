using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PoderBase : MonoBehaviour
{
    public TextMeshProUGUI textoNombre, textoPrecio;
    public string poderNombre;
    public int precio;

    public abstract void Poder();

    


}
