using System;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    [SerializeField] private float _health = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            Destroy(other.gameObject);
            TakeDamage(enemy.GetDamage());
        }
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}