using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(TargetSearcer))]
[RequireComponent(typeof(FoxHealth))]
public class Vampirism : MonoBehaviour
{
    private const float Lasting = 6f;
    private const float TimeToRecharge = 4f;

    [SerializeField] private int _amountOfDamage = 5;

    public event Action AmountChanged;

    private InputReader _inputReader;
    private TargetSearcer _targetSearcer;
    private FoxHealth _foxHealth;
    private bool _isDrainingEnemy = false;
    private bool _isWorking;
    private WaitForSeconds _wait;
    private WaitForSeconds _waitForSecond;

    public float RemainingTime { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _targetSearcer = GetComponent<TargetSearcer>();
        _foxHealth = GetComponent<FoxHealth>();
        RemainingTime = Lasting;
        AmountChanged?.Invoke();
        _wait = new WaitForSeconds(TimeToRecharge);
        _waitForSecond = new WaitForSeconds(1f);
    }

    private void OnEnable()
    {
        _inputReader.AbilityOfDrainChanged += ChangeAbilityOfDrain;
    }

    private void OnDisable()
    {
        _inputReader.AbilityOfDrainChanged -= ChangeAbilityOfDrain;
    }

    public void DrainEnemy()
    {
        if (_isWorking == false)
        {
            StartCoroutine(StartDrain());
        }
    }

    private void ChangeAbilityOfDrain()
    {
        if (_isDrainingEnemy)
        {
            _isDrainingEnemy = false;
        }
        else
        {
            DrainEnemy();
            _isDrainingEnemy = true;
        }
    }

    private IEnumerator StartDrain()
    {
        _isWorking = true;
        BearHealth enemy = null;

        while (RemainingTime > 0)
        {
            enemy = _targetSearcer.SearchEnemyForVampirism();

            if (enemy != null)
            {
                yield return _waitForSecond;
                enemy.TakeDamage(_amountOfDamage);
                _foxHealth.Recover(_amountOfDamage);
            }

            RemainingTime--;
            yield return _waitForSecond;
            AmountChanged?.Invoke();
        }

        yield return _wait;
        RemainingTime = Lasting;
        _isWorking = false;
        AmountChanged?.Invoke();
    }
}
