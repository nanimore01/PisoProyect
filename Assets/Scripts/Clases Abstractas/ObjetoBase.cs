using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoBase : MonoBehaviour, IDashable
{
    [SerializeField] float _cooldownRespawn = 3f;
    public void ActiveDash()
    {
        Jugador.instance.target = transform;
        Jugador.instance.rb.useGravity = false;
        Jugador.instance.rb.velocity = Vector3.zero;
    }

    public IEnumerator CooldownRespawn()
    {
        yield return new WaitForSeconds(_cooldownRespawn);
        gameObject.SetActive(true);
    }
}
