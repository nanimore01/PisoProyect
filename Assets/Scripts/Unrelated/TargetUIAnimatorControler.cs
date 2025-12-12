using UnityEngine;

public class TargetUIAnimatorControler : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void OnFinishedAnimation()
    {
        _animator.SetBool("IsActive", false);
    }
}
