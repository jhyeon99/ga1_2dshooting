using UnityEngine;

public class ChaserEnemy : Enemy
{
    public Transform Target;
    public float ChaseUpdateDelay = 0;
    private float _chaseUpdateTimer = 0;

    protected override void GetDirection()
    {
        Vector2 direction = Target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }

    protected override void Update()
    {
        base.Update();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        _chaseUpdateTimer += Time.deltaTime;
        if (_chaseUpdateTimer > ChaseUpdateDelay)
        {
            _chaseUpdateTimer = 0;
            GetDirection();
        }
    }
}