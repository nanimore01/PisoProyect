using UnityEngine;

public class UIFollower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]Jugador jugador;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position;
    }
}
