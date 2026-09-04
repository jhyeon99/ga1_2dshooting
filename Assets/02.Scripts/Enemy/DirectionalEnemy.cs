using UnityEngine;

public class DirectionalEnemy : Enemy
{
    public Transform _target;
    private GameObject _player = null;

    protected override void GetDirection()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Direction = Vector2.zero;
            return;
        }

        _target = _player.transform;
        Vector2 direction = _target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }
}