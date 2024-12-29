using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Damager : MonoBehaviour
{
    [SerializeField] private FoxHealth _health;
    [SerializeField] private int _numberOfDamage = 15;

    private void OnEnable()
    {
        CauseDamage();
    }

    public void CauseDamage()
    {
        _health.TakeDamage(_numberOfDamage);
    }
}
