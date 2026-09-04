using UnityEngine;

public class DirectionalEnemy : Enemy
{
    public Transform _target;

    protected override void GetDirection()
    {
        GameObject gameObject = GameObject.FindWithTag("Player");
        if (gameObject == null)
        {
            Direction = Vector2.zero;
            return;
        }

        _target = gameObject.transform;
        Vector2 direction = _target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }
}