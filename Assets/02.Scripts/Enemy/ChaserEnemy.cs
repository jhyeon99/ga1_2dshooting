using UnityEngine;

public class ChaserEnemy : Enemy
{
    private Transform _target;
    public float ChaseUpdateDelay = 0;
    private float _chaseUpdateTimer = 0;

    private void Start()
    {
        GetDirection();
    }

    protected override void GetDirection()
    {
        _target = GameObject.FindWithTag("Player").transform;
        Vector2 direction = _target.position - transform.position;
        Vector2 normalizedDirection = direction.normalized;
        Direction = normalizedDirection;
    }

    protected override void Update()
    {
        base.Update();

        _chaseUpdateTimer += Time.deltaTime;
        if (_chaseUpdateTimer > ChaseUpdateDelay)
        {
            _chaseUpdateTimer = 0;
            GetDirection();
        }
    }
}