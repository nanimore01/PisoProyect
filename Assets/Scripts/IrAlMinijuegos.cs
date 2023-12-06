using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlMinijuegos : MonoBehaviour
{
    public StaminaSystem _stamina;
    public void IrAlMinijuego()
    {
        if(_stamina.currentStamina > 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
