using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _instance;
    public static UpgradeManager Instance => _instance;

    private float _attackLevel = 1;
    private float _hpLevel = 1;
    private float _speedLevel = 1;

    private Player _player;

    [SerializeField] private float _attackUpAmount = 0.01f;
    [SerializeField] private float _healAmount = 1;
    [SerializeField] private float _speedUpAmount = 0.01f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
    }

    public void AttackUpgrade()
    {
        _attackLevel++;
        _player.AttackspeedUp(_attackUpAmount);
    }

    public void HpUpgrade()
    {
        _hpLevel++;
        _player.Heal(_healAmount);
    }

    public void SpeedUpgrade()
    {
        _speedLevel++;
        _player.SpeedUp(_speedUpAmount);
    }
}