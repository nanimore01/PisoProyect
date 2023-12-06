using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoActualizable : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    public void UpdateHUDActualInt(int NumeroActual, int NumeroMaximo, string Texto)
    {
        _text.text = NumeroActual + " / " + NumeroMaximo + " " + Texto;
    }
    public void UpdateHUDActualFloat(float NumeroActual, float NumeroMaximo, string Texto)
    {
        _text.text = NumeroActual + " / " + NumeroMaximo + " " + Texto;
    }
    public void UpdateInt(int Numero, string Texto)
    {
        _text.text = Numero + " " + Texto;

        if(Texto != null)
        {
            _text.text = Numero.ToString();
        }
    }


}
