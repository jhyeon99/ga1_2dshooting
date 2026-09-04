using UnityEngine;

public class ChaserEnemy : Enemy
{
    private Transform _target = null;
    public float ChaseUpdateDelay = 1f;
    private float _chaseUpdateTimer = 0;
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