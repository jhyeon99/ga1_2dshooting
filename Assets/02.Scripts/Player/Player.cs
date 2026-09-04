using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    private PlayerMove _playerMove = null;
    private PlayerFire _playerFire = null;

    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerFire = GetComponent<PlayerFire>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AttackspeedUp()
    {
        _playerFire.AttackspeedUp();
    }

    public void Heal(float amount)
    {
        _health += amount;
    }

    public void SpeedUp(float amount)
    {
        _playerMove.SpeedUp(amount);
    }
}