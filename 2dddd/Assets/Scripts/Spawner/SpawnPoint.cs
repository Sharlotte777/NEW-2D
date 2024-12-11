using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private float _radius = 1f;

    public void CreateObject()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _radius);

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.TryGetComponent(out Item item))
            {
                break;
            }
            else
            {
                Instantiate(_prefab, transform.position, Quaternion.identity);
            }
        }
    }
}
