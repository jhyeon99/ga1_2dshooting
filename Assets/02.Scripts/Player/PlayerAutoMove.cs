using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject _target;

    [SerializeField] private float _maxPlayerY = 0;

    [SerializeField] private float _minPlayerY = 0;

    private void Update()
    {
        if (_target == null)
        {
            FindNearestTarget();
        }

        Move();
    }

    private void FindNearestTarget()
    {
        // 1. 타겟을 구한다.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0) return;

        GameObject target = targets[0];
        float minDistance = float.MaxValue;

        // 1-1. 가장 가까운 타겟을 찾는다.
        foreach (GameObject enemy in targets)
        {
            // 거리를 구해서
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance) // 저장된 거리보다 짧다면
            {
                // 타겟 변경
                minDistance = distance;
                _target = enemy;
            }
        }
    }

    private void Move()
    {
        if (_target == null) return;

        // 2. 방향을 구한다
        Vector3 direction = _target.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        Vector3 diff = _target.transform.position - transform.position;

        // 적과 나와의 y축 차이가 3보다 크면 앞으로 가고 아니라면 뒤로
        if (diff.y >= 3)
        {
            direction.y += 1;
        }
        else
        {
            direction.y -= 1;
        }

        // 3. 속도에 맞게 이동한다.
        transform.position += direction * _speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, _minPlayerY, _maxPlayerY), transform.position.z);
    }

    public void SpeedUp(float amount)
    {
        _speed += amount;
    }
}