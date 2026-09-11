using System;

[System.Serializable]
public class EnemySpawnData
{
    public string PrefabPath { get; set; }
    public float Weight { get; set; }

    [NonSerialized] public Enemy Prefab;
}