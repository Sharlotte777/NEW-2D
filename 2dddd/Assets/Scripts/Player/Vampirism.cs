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

    private InputReader _inputReader;
    private TargetSearcer _targetSearcer;
    private float _remainingTime;
    private bool _isWorking;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _targetSearcer = GetComponent<TargetSearcer>();
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
        BearHealth bear = _targetSearcer.SearchEnemy();
        _remainingTime = Lasting; 
        _isWorking = true;
        _wait = new WaitForSeconds(TimeToRecharge);

        while (_remainingTime > 0)
        {
            if (bear != null)
            {
                yield return new WaitForSeconds(2f);
                bear.TakeDamage(_amountOfDamage);
            }

            _remainingTime--;
        }

        yield return _wait;
        _isWorking = false;
    }
}
