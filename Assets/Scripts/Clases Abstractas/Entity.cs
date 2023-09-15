using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Valores de Entity")]
    public float maxSpeed;
    protected float _currSpeed;
    [SerializeField] protected float maxForce;
    [SerializeField] public Rigidbody rb;
    public abstract void Morir();

    
}
