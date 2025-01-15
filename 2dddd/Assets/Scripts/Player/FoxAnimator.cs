using UnityEngine;

[RequireComponent(typeof(FoxAnimator))]
public class FoxAnimator : MonoBehaviour
{
    private const string NameOfValue = "speed";

    private UnityEngine.Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<UnityEngine.Animator>();
    }

    public void StartRunningAnimation(float movement)
    {
        _animator.SetFloat(NameOfValue, Mathf.Abs(movement));
    }
}
