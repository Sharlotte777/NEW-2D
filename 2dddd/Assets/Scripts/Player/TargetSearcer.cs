using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FoxCombat))]
[RequireComponent(typeof(FoxHealth))]
public class TargetSearcer : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _radius;
    [SerializeField] private SpriteRenderer _circleOfVampirism;
    [SerializeField] private float _timeToRepeat = 0.01f;

    private FoxCombat _attack;
    private FoxHealth _health;
    private bool _isWorking = true;
    private WaitForSeconds _wait;
    private Collider2D[] _objects;
    private float _radiousOfVampirism;

    private void Awake()
    {
        _radiousOfVampirism = _circleOfVampirism.transform.localScale.x;
        _attack = GetComponent<FoxCombat>();
        _health = GetComponent<FoxHealth>();
        StartCoroutine(SearchElements());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item is FirstAidKit firstAidKit)
            {
                firstAidKit = (FirstAidKit)item;

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

    public BearHealth SearchEnemyForVampirism()
    {
        Collider2D target = SearchForVampirism();

        if (target.TryGetComponent(out BearHealth enemy))
        {
            return enemy;
        }

        return null;
    }

    public void StartDetection()
    {
        BearHealth enemy = SearchEnemy();

        if (enemy != null)
        {
            _attack.Hit(enemy);
        }
    }

    private Collider2D SearchForVampirism()
    {
        int targetLayer = 1;
        Collider2D target = Physics2D.OverlapCircle(_attackPosition.position, _radiousOfVampirism, targetLayer);
        return target;
    }

    private BearHealth SearchEnemy()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (_objects[i].gameObject.TryGetComponent(out BearHealth enemy))
            {
                return enemy;
            }
        }

        return null;
    }

    private IEnumerator SearchElements()
    {
        _wait = new WaitForSeconds(_timeToRepeat);

        while (_isWorking)
        {
            _objects = Physics2D.OverlapCircleAll(_attackPosition.position, _radius);
            yield return _wait;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPosition.position, _radius);
    }
}
