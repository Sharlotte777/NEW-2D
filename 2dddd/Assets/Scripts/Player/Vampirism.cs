using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(TargetSearcer))]
public class Vampirism : MonoBehaviour
{
    private const float Lasting = 6f;
    private const float TimeToRecharge = 4f;

    [SerializeField] private int _amountOfDamage = 5;

    public event Action AmountChanged;

    private InputReader _inputReader;
    private TargetSearcer _targetSearcer;
    private BearHealth enemy;
    private bool _isWorking;
    private WaitForSeconds _wait;
    private WaitForSeconds _waitForSecond;

    public float RemainingTime { get; private set; }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _targetSearcer = GetComponent<TargetSearcer>();
        RemainingTime = Lasting;
        AmountChanged?.Invoke();
    }

    private void Update()
    {
        if (_inputReader.CanDrainEnemy)
        {
            DrainEnemy();
        }
    }

    public void DrainEnemy()
    {
        if (_isWorking == false)
        {
            StartCoroutine(StartDrain());
        }
    }

    private IEnumerator StartDrain()
    {
        _isWorking = true;
        _wait = new WaitForSeconds(TimeToRecharge);
        _waitForSecond = new WaitForSeconds(1f);

        while (RemainingTime > 0)
        {
            enemy = _targetSearcer.SearchEnemyForVampirism();

            if (enemy != null)
            {
                yield return _waitForSecond;
                enemy.TakeDamage(_amountOfDamage);
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
