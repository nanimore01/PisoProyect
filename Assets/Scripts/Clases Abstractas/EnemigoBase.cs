using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemigoBase : Entity, IDashable
{
    [Header("Valores")]
    [SerializeField] protected int _monedasDadas;
    [SerializeField] protected float _size;
    [SerializeField] protected BoxCollider _boxC;
    public override void Morir()
    {
        EventManager.enemy.OnDead?.Invoke();
        //gameObject.SetActive(true);
        _boxC.enabled = false;
    }

    public void SetStats(int monedasDadas, float size)
    {
        _monedasDadas = monedasDadas;
        _size = size;
    }

    public void ActiveDash()
    {
        Debug.Log("Enemigo Targeteado");
        EventManager.enemy.OnTargetEnemy?.Invoke();
        EventManager.player.GetTarget?.Invoke(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Jugador>() != null)
        {
            EventManager.enemy.OnHitted?.Invoke();
            collision.collider.GetComponent<Jugador>().TakeMoney(_monedasDadas);
            Morir();
        }
    }

    


}
