using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Jugador pj;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            
    }
}
