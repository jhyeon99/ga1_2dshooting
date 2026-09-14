using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradeType _upgradeType;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _scoreCostText;


    public void OnClick()
    {
        // 버튼 클릭 시 레벨업 및 UI 업데이트 요청
        UpgradeManager.Instance.LevelUp(_upgradeType);
    }

    public void Refresh()
    {
        Upgrade upgrade = UpgradeManager.Instance.Upgrades[(int)_upgradeType];
        _titleText.text = $"{upgrade.Name} Lv.{upgrade.Level}";
        _valueText.text = $"{upgrade.CurrentValue}->{upgrade.NextValue}";
        _scoreCostText.text = $"{upgrade.Cost:N0}";
    }
}