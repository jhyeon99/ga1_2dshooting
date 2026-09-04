using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private Vector2 _direction = Vector2.zero;

    [SerializeField] private float _waitInterval = 3;
    private float _waitTimer = 0;

    private GameObject _playerObject = null;

    protected virtual void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
    }

    protected virtual void Update()
    {
        _waitTimer += Time.deltaTime;
        if (_waitTimer >= _waitInterval)
        {
            SetDirectionToPlayer();
        }

        Move();
    }

    private void SetDirectionToPlayer()
    {
        if (_playerObject == null)
        {
            _direction = Vector2.zero;
            return;
        }

        _direction = (_playerObject.transform.position - transform.position).normalized;
    }

    private void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}