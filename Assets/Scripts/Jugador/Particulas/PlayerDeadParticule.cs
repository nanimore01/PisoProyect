using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class PlayerDeadParticule : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public void Start()
    {
        EventManager.player.OnDead += OnDead;
    }

    public void OnDead()
    {
        particle.Play();
        EventManager.player.OnDead -= OnDead;
    }

}
