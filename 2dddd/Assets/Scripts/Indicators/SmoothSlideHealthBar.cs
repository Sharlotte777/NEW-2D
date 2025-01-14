using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlideHealthBar : HealthBar
{
    [SerializeField] private float _smoothSlideDifference = 0.5f;

    private Coroutine _coroutine;

    protected override void UpdateValue()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SmoothChangeSliderNumber(_health.CurrentValue));
    }

    private IEnumerator SmoothChangeSliderNumber(float goal)
    {
        goal /= _health.MaxValue;

        while (_healthBar.value != goal)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, goal, _smoothSlideDifference * Time.deltaTime);

            yield return null;
        }
    }
}
