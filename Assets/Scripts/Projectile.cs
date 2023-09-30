using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f, _maxDistance = 50f, _currentDistance = 0f;

    void Update()
    {
        var distanceToTravel = _speed * Time.deltaTime;

        transform.position += transform.up * distanceToTravel;

        _currentDistance += distanceToTravel;
        if(_currentDistance > _maxDistance)
        {
            ProjectileFactory.Instance.ReturnProjectile(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }

    public static void TurnOnOff(Projectile p, bool active = true)
    {
        if (active)
        {
            p.Reset();
        }
        p.gameObject.SetActive(active);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Piso>()) ProjectileFactory.Instance.ReturnProjectile(this);
    }
}
