using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    private PlayerMove _playerMove = null;
    private PlayerFire _playerFire = null;

    [SerializeField] private GameObject _deathEffectPrefab = null;
    [SerializeField] private GameObject _getItemEffectPrefab = null;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerFire = GetComponent<PlayerFire>();
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("데미지는 0보다 작을 수 없습니다.");
            return;
        }

        _health -= amount;
        if (_health <= 0)
        {
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AttackspeedUp(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("공격속도 증가량은 0보다 작을 수 없습니다.");
            return;
        }

        Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        _playerFire.AttackspeedUp(amount);
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("힐량은 0보다 작을 수 없습니다.");
            return;
        }

        Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        _health += amount;
    }

    public void SpeedUp(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("속도 증가량은 0보다 작을 수 없습니다.");
            return;
        }

        Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        _playerMove.SpeedUp(amount);
    }
}