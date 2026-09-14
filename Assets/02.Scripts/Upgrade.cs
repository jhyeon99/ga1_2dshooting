using UnityEngine;

[System.Serializable]
public class Upgrade : ISerializationCallbackReceiver
{
    // 기획자가 채우는 속성
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private float _defaultValue;
    [SerializeField] private float _increaseValue;
    [SerializeField] private float _defaultCost;
    [SerializeField] private float _increaseCost;

    // 실행중에 동적으로 바뀌는 속성
    private int _level;
    public int Level => _level;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    private float _nextValue;
    public float NextValue => _nextValue;
    private int _cost;
    public int Cost => _cost;

    public Upgrade(int level, string name, float defaultValue, float increaseValue, float increaseCost)
    {
        _level = level;
        _name = name;
        _defaultValue = defaultValue;
        _increaseValue = increaseValue;
        _increaseCost = increaseCost;

        Calculate();
    }


    public void LevelUp()
    {
        _level++;
        Calculate();
    }

    private void Calculate()
    {
        _currentValue = _defaultValue + _level * _increaseValue;
        _nextValue = _defaultValue + (_level + 1) * _increaseValue;
        _cost = (int)(_defaultCost * Mathf.Pow(_increaseCost, _level));
    }

    // --- ISerializationCallbackReceiver 구현 ---

    // 직렬화 되기 전 (사용 안 함)
    public void OnBeforeSerialize()
    {
    }

    // 유니티가 인스펙터 데이터를 읽어온 직후 실행
    public void OnAfterDeserialize()
    {
        // 0으로 초기화되는 현상을 방지하기 위해 1 미만일 때 1로 보정
        if (_level < 0) _level = 0;

        Calculate();
    }
}