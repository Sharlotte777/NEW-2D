using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlideHealthBar : MonoBehaviour
{
    [SerializeField] private float _smoothSlideDifference = 0.5f;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private FoxHealth _foxHealth;

    private Coroutine _coroutine;

    private void Awake()
    {
        ChangeNumber();
    }

    private void OnEnable()
    {
        _foxHealth.AmountChanged += ChangeNumber;
    }

    private void OnDisable()
    {
        _foxHealth.AmountChanged -= ChangeNumber;
    }

    private void ChangeNumber()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothChangeSliderNumber(_foxHealth.Health));
    }

    private IEnumerator SmoothChangeSliderNumber(float goal)
    {
        goal = goal / _foxHealth.MaxHealth;

        while (_smoothHealthBar.value != goal)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, goal, _smoothSlideDifference * Time.deltaTime);

            yield return null;
        }
    }
}
