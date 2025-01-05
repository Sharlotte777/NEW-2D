using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoxCombat))]
[RequireComponent(typeof(FoxHealth))]
public class FoxSearcher : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _radius;

    private FoxCombat _attack;
    private FoxHealth _health;

    private void Awake()
    {
        _attack = GetComponent<FoxCombat>();
        _health = GetComponent<FoxHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item is FirstAidKit)
            {
                FirstAidKit firstAidKit = (FirstAidKit)item;

                if (_health.HaveRecovered(firstAidKit.RecoveryAmount))
                {
                    Destroy(item.gameObject);
                }
            }
            else if(item is Coin)
            {
                Destroy(item.gameObject);
            }
        }
    }

    public void StartDetection()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(_attackPosition.position, _radius);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.TryGetComponent(out BearHealth enemy))
            {
                _attack.Hit(enemy);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPosition.position, _radius);
    }
}
