using UnityEngine;

public class DirectionalEnemy : Enemy
{
    private GameObject _player = null;

    protected override void Start()
    {
        base.Start();
        _player = GameObject.FindWithTag("Player");
        GetDirection();
    }

    private void GetDirection()
    {
        if (_player == null)
        {
            _direction = Vector2.zero;
            return;
        }

        Vector3 dir = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        _direction = Vector2.down;
    }
}