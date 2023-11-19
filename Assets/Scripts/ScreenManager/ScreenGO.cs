using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGO : IScreen
{
    Dictionary<Behaviour, bool> _before;

    public Transform root;

    public ScreenGO(Transform root)
    {
        _before = new Dictionary<Behaviour, bool>();

        this.root = root;

        foreach (var b in root.GetComponentsInChildren<Behaviour>())
        {
           // b.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void Activate()
    {
        foreach (var keyValue in _before)
        {
            keyValue.Key.enabled = keyValue.Value;
            // keyValue.Key.gameObject.GetComponent<Renderer>().material.color = Color.green;

            keyValue.Key.gameObject.SetActive(true);//prendo el GO
        }

        _before.Clear();
    }

    public void Deactivate()
    {
        foreach (var b in root.GetComponentsInChildren<Behaviour>())
        {
            _before[b] = b.enabled;
            b.enabled = false;

            // b.gameObject.GetComponent<Renderer>().material.color = Color.red;

            b.gameObject.SetActive(false);//apago el GO
        }
    }

    public string Free()
    {
        GameObject.Destroy(root.gameObject);
        return "Deletie una pantalla jugable";
    }
}
