using UnityEngine;

public class ChaserEnemy : Enemy
{
    public float ChaseUpdateDelay = 1f;
    private float _chaseUpdateTimer = 0;
    private GameObject _player = null;

    protected override void Start()
    {
        base.Start();
        _player = GameObject.FindWithTag("Player");
        Chase();
    }

    private void Chase()
    {
        if (_player == null)
        {
            Debug.LogWarning("플레이어를 찾을 수 없습니다.");
            return;
        }

        Vector3 dir = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected override void Update()
    {
        base.Update();

        _chaseUpdateTimer += Time.deltaTime;
        if (_chaseUpdateTimer > ChaseUpdateDelay)
        {
            _chaseUpdateTimer = 0;
            Chase();
        }
    }
}