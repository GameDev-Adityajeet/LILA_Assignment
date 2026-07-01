using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [Header("Upgrade State")]
    public bool hasSpeedUpgrade = false;
    public bool hasDashUpgrade = false;
    public bool hasExtraTimeUpgrade = false;

    [Header("Costs")]
    public int speedCost = 100;
    public int dashCost = 200;
    public int extraTimeCost = 300;

    [Header("Effect Values")]
    public float speedMultiplier = 1.15f; 
    public float extraTimeBonus = 5f;

    void Awake()
    {
        Instance = this;
    }

    public bool TryBuySpeed()
    {
        if (hasSpeedUpgrade) return false;
        if (GameState.Instance.money < speedCost) return false;

        GameState.Instance.AddMoney(-speedCost);
        hasSpeedUpgrade = true;

        PlayerController pc = FindFirstObjectByType<PlayerController>();
        pc.maxSpeed *= speedMultiplier;
        pc.acceleration *= speedMultiplier;

        AudioManager.Instance.PlayUpgrade();
        return true;
    }

    public bool TryBuyDash()
    {
        if (hasDashUpgrade) return false;
        if (GameState.Instance.money < dashCost) return false;

        GameState.Instance.AddMoney(-dashCost);
        hasDashUpgrade = true;

        return true;
    }

    public bool TryBuyExtraTime()
    {
        if (hasExtraTimeUpgrade) return false;
        if (GameState.Instance.money < extraTimeCost) return false;

        GameState.Instance.AddMoney(-extraTimeCost);
        hasExtraTimeUpgrade = true;

        GameState.Instance.timeBonusPerDelivery += extraTimeBonus;

        return true;
    }
}