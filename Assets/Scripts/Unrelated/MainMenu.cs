using UnityEngine;
using System.IO;
public class MainMenu : MonoBehaviour
{
    [SerializeField]Animator _animator;

    public void Start()
    {
        
    }

    public void GoToMenu()
    {
        print("Voy al menu");
        _animator.SetTrigger("IsStarted");
    }
    

    public void ChargeAllData()
    {

    }
}
