using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _instance;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    // 업그레이드 UI들
    [SerializeField] private UI_Upgrade[] _uiUpgrades;

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
        RefreshUI();
    }

    public void LevelUp(UpgradeType upgradeType)
    {
        // 골드 매니저에게 돈이 있는지 물어보고 돈이 있다면 차감 후 업그레이드 호출

        Upgrade upgrade = _upgrades[(int)upgradeType];

        if (ScoreManager.Instance.Score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.SpendScore(upgrade.Cost);

        _upgrades[(int)upgradeType].LevelUp();

        RefreshUI();
    }

    // UI 갱신
    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }
}