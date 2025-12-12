using UnityEngine;

public class Mina : ObjetoBase
{
    [SerializeField] Animator _animator;

    public override void ActiveDash()
    {
        base.ActiveDash();
        EventManager.enemy.OnTargetTrap?.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Jugador>())
        {
            collision.collider.GetComponent<Jugador>().Morir();
            _animator.SetBool("IsDead", true);
        }
    }

    

}
