using UnityEngine;

public class ModelEnemy : MonoBehaviour
{
    [SerializeField] GameObject _me;
    public void OnDeadAnimationEnd()
    {
        _me.SetActive(false);
    }
}
