using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float _value = 0;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _waitInterval = 3;

    private float _timer = 0;


    private GameObject _playerObject = null;

    protected virtual void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");

        if (_playerObject == null)
        {
            Debug.LogWarning("플레이어를 찾을 수 없습니다.");
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
            Debug.LogWarning("플레이어를 찾을 수 없습니다.");
            return;
        }

        transform.position = Vector2.Lerp(transform.position, _playerObject.transform.position,
            _speed * Time.deltaTime);
    }
}