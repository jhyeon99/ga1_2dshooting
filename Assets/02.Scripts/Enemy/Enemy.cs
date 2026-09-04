using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    protected Vector2 Direction = Vector2.zero;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _damage = 0;

    [SerializeField] private float _itemSpawnProbability = 0.3f;
    private ItemFactory _itemFactory = null;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            if (_itemSpawnProbability <= Random.Range(0f, 1f))
            {
                _itemFactory.SpawnRandomItem(gameObject.transform.position);
            }

            Destroy(gameObject);
        }
    }

    protected virtual void Start()
    {
        _itemFactory = GameObject.FindWithTag("ItemFactory").GetComponent<ItemFactory>();
        GetDirection();
    }

    private void Move()
    {
        transform.Translate(Direction * _moveSpeed * Time.deltaTime);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void GetDirection();


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.Log("Player 컴포넌트가 존재하지 않습니다.");
                return;
            }

            Destroy(gameObject);
            player.TakeDamage(_damage);
        }
    }
}