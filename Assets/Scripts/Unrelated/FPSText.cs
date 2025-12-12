using UnityEngine;
using TMPro;
public class FPSText : MonoBehaviour
{


    [SerializeField] TMP_Text _fpsText;
    private float updateInterval = 0.5f; // Actualizar cada 0.5 segundos
    private float timeSinceLastUpdate;

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            float fps = 1.0f / Time.deltaTime;
            _fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
            timeSinceLastUpdate = 0;
        }
    }
}
