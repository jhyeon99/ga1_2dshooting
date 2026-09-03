using UnityEngine;

public class DirectionalEnemy : Enemy
{
    public Transform Target;

    protected override void GetDirection()
    {
        Vector2 direction = Target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }
}