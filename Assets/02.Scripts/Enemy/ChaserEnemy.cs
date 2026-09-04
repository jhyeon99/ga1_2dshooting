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

        GameObject _player = GameObject.FindWithTag("Player"); // 테스트용 코드

        _chaseUpdateTimer += Time.deltaTime;
        if (_chaseUpdateTimer > ChaseUpdateDelay)
        {
            _chaseUpdateTimer = 0;
            GetDirection();
        }
    }
}