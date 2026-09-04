using UnityEngine;

[System.Serializable]
public struct EnemySpawnData
{
    public Enemy prefab;
    public float probability;
}

// 역할: 일정 시간마다 적을 생성해주고 싶다.
public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [SerializeField] private float _spawnInterval;
    private float _timer = 0;
    [SerializeField] private float _enemyMinSpawnTime = 1f;
    [SerializeField] private float _enemyMaxSpawnTime = 3f;

    // - 생성할 프리팹
    [SerializeField] private EnemySpawnData[] _enemySpawnData;


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnInterval)
        {
            _timer = 0;
            _spawnInterval = Random.Range(_enemyMinSpawnTime, _enemyMaxSpawnTime);

            SpawnWithProbability();
        }
    }

    private void SpawnWithProbability()
    {
        if (_enemySpawnData == null || _enemySpawnData.Length == 0)
        {
            Debug.LogWarning("EnemySpawner: Spawn data is empty.");
            return;
        }

        float sum = 0;
        foreach (var enemySpawnData in _enemySpawnData)
        {
            sum += enemySpawnData.probability;
        }

        float probability = Random.Range(0f, sum);

        sum = 0;
        for (int enemyType = 0; enemyType < _enemySpawnData.Length; enemyType++)
        {
            sum += _enemySpawnData[enemyType].probability;
            if (probability <= sum)
            {
                Enemy enemy = Instantiate(_enemySpawnData[enemyType].prefab);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }

    private void Spawn(int enemyType)
    {
        Enemy enemy = Instantiate(_enemySpawnData[enemyType].prefab);
        enemy.transform.position = transform.position;
    }
}