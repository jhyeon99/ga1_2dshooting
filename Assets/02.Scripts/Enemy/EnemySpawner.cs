using UnityEngine;

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval;
    private float _timer = 0;

    // - 생성할 프리팹
    [SerializeField] private Enemy[] _enemyPrefabs;


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnInterval)
        {
            _timer = 0;
            _spawnInterval = Random.Range(1f, 3f); // 1 ~ 3

            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        Spawn(Random.Range(0, _enemyPrefabs.Length));
    }

    private void Spawn(int enemyType)
    {
        Enemy enemy = Instantiate(_enemyPrefabs[enemyType]);
        enemy.transform.position = transform.position;
    }
}