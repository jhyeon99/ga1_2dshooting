using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    protected Vector2 Direction = Vector2.zero;
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _damage = 0;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
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

    public float GetDamage()
    {
        return _damage;
    }
}