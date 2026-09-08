using System;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _value = 0;
    [SerializeField] private float _lerpTime = 1;
    [SerializeField] private float _waitInterval = 3;
    private float _timer = 0;

    private Vector2 _startPosition = Vector2.zero;
    private GameObject _playerObject = null;

    protected virtual void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");
        _startPosition = transform.position;

        if (_playerObject == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
            return;
        }
    }

    protected virtual void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _waitInterval)
        {
            LerpToPlayer();
        }
    }

    private void LerpToPlayer()
    {
        if (_playerObject == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다.");
            return;
        }

        transform.position = Vector2.Lerp(_startPosition, _playerObject.transform.position,
            Math.Clamp(_timer - _waitInterval, 0, 1));
    }
}