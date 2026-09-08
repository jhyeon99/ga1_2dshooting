using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    private static readonly Vector2 Direction = Vector2.down;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _damage = 0;

    [Range(0f, 1f), SerializeField] private float _itemSpawnProbability = 0.3f;
    private ItemFactory _itemFactory = null;

    private Animator _animator = null;

    [SerializeField] private GameObject _deathEffectPrefab = null;

    protected virtual void Start()
    {
        _itemFactory = GameObject.FindWithTag("ItemFactory").GetComponent<ItemFactory>();
        _animator = GetComponent<Animator>();

        if (_itemFactory == null)
        {
            Debug.LogWarning("ItemFactory를 찾을 수 없습니다");
        }

        if (_animator == null)
        {
            Debug.LogWarning("Animator를 찾을 수 없습니다.");
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_animator != null)
        {
            _animator.SetTrigger("Hitted");
        }

        if (_health <= 0)
        {
            if (_itemSpawnProbability >= Random.Range(0f, 1f))
            {
                _itemFactory.SpawnRandomItem(gameObject.transform.position);
            }

            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Direction * _moveSpeed * Time.deltaTime);
    }

    protected virtual void Update()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogWarning("Player 컴포넌트가 존재하지 않습니다.");
                return;
            }

            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}