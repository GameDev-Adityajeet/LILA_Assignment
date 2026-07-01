using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public GameObject shopPanel;
    public Button btnSpeed;
    public Button btnDash;
    public Button btnExtraTime;
    public Button btnClose;

    public TMP_Text btnSpeedLabel;
    public TMP_Text btnDashLabel;
    public TMP_Text btnExtraTimeLabel;

    void Start()
    {
        btnSpeed.onClick.AddListener(() => Purchase(UpgradeManager.Instance.TryBuySpeed, btnSpeed, btnSpeedLabel, "Speed +15%"));
        btnDash.onClick.AddListener(() => Purchase(UpgradeManager.Instance.TryBuyDash, btnDash, btnDashLabel, "Dash (Space)"));
        btnExtraTime.onClick.AddListener(() => Purchase(UpgradeManager.Instance.TryBuyExtraTime, btnExtraTime, btnExtraTimeLabel, "Extra Time +5s"));
        btnClose.onClick.AddListener(CloseShop);

        shopPanel.SetActive(false);
    }

    void Purchase(System.Func<bool> tryBuy, Button btn, TMP_Text label, string name)
    {
        bool success = tryBuy();
        if (success)
        {
            btn.interactable = false; 
            label.text = name + " - OWNED";
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}