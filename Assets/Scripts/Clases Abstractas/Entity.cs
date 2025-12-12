using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Valores de Entity")]
    protected FSM _fsm;
    public float maxSpeed;
    protected float _currSpeed;
    [SerializeField] protected float maxForce;
    [SerializeField] public Rigidbody rb;
    [SerializeField] protected Animator _animator;
    public abstract void Morir();

    
}
