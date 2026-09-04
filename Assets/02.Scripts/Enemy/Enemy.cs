using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    protected Vector2 Direction = Vector2.zero;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _damage = 0;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Start()
    {
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                player.TakeDamage(_damage);
            }
        }
    }
}