using UnityEngine;

public class DirectionalEnemy : Enemy
{
    public Transform _target;

    protected override void GetDirection()
    {
        _target = GameObject.FindWithTag("Player").transform;
        Vector2 direction = _target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }
}