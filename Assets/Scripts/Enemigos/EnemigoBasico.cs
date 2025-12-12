using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : EnemigoBase
{
    
    void Start()
    {
       
        
        
    }

    

    public override void Morir()
    {
        EventManager.enemy.OnDead?.Invoke();
        _animator.SetBool("IsDead", true);
        _boxC.enabled = false;
        
    }

}
