using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private ItemSpawnDataTableSO _spawnDataTable;

    public void SpawnItemWithData(Vector3 spawnPosition)
    {
        if (_spawnDataTable == null || _spawnDataTable.Datas.Length == 0) return;


        float totalWeight = 0;
        foreach (ItemSpawnData itemSpawnData in _spawnDataTable.Datas)
        {
            totalWeight += itemSpawnData.Weight;
        }

        float probability = Random.Range(0f, totalWeight);

        float cumulativeWeight = 0;
        for (int itemType = 0; itemType < _spawnDataTable.Datas.Length; itemType++)
        {
            cumulativeWeight += _spawnDataTable.Datas[itemType].Weight;
            if (probability <= cumulativeWeight)
            {
                if (_spawnDataTable.Datas[itemType].Prefab == null)
                {
                    break;
                }

                Instantiate(_spawnDataTable.Datas[itemType].Prefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}