using UnityEngine;

public class UI_UpgradeButton : MonoBehaviour
{
    public void AttackUpgradeButton()
    {
        UpgradeManager.Instance.AttackUpgrade();
    }

    public void HPUpgradeButton()
    {
        UpgradeManager.Instance.HpUpgrade();
    }

    public void SpeedUpgradeButton()
    {
        UpgradeManager.Instance.SpeedUpgrade();
    }
}