using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] _itemPrefabs;

    public GameObject SpawnRandomItem(Vector3 spawnPosition)
    {
        if (_itemPrefabs == null || _itemPrefabs.Length == 0) return null;

        int randomIndex = Random.Range(0, _itemPrefabs.Length);
        return Instantiate(_itemPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}