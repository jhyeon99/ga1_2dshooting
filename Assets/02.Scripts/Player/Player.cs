using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    private PlayerFire _playerFire = null;
    private PlayerAutoMove _playerAutoMove = null;

    [SerializeField] private GameObject _deathEffectPrefab = null;
    [SerializeField] private GameObject _getItemEffectPrefab = null;

    private void Start()
    {
        _playerFire = GetComponent<PlayerFire>();
        _playerAutoMove = GetComponent<PlayerAutoMove>();
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
            if (_deathEffectPrefab != null)
            {
                Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            }

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

        if (_getItemEffectPrefab != null)
        {
            Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        }

        _playerFire.AttackspeedUp(amount);
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("힐량은 0보다 작을 수 없습니다.");
            return;
        }

        if (_getItemEffectPrefab != null)
        {
            Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        }

        _health += amount;
    }

    public void SpeedUp(float amount)
    {
        if (amount < 0)
        {
            Debug.LogWarning("속도 증가량은 0보다 작을 수 없습니다.");
            return;
        }

        if (_getItemEffectPrefab != null)
        {
            Instantiate(_getItemEffectPrefab, transform.position, Quaternion.identity);
        }

        //_playerMove.SpeedUp(amount);
        _playerAutoMove.SpeedUp(amount);
    }
}