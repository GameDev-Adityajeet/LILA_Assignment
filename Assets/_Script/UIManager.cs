using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text timerText;
    public TMP_Text deliveryStatusText;
    public TMP_Text promptText;
    public TMP_Text bonusPopupText;
    public TMP_Text moneyPopupText;

    private Coroutine bonusPopupCoroutine;
    private Coroutine moneyPopupCoroutine;

    void Start()
    {
        GameState.Instance.OnMoneyChanged += UpdateMoney;
        GameState.Instance.OnTimeChanged += UpdateTimer;
        GameState.Instance.OnTimeBonusEarned += ShowTimeBonus;
        GameState.Instance.OnMoneyEarned += ShowMoneyPopup;

        UpdateMoney(GameState.Instance.money);
        UpdateTimer(GameState.Instance.timeRemaining);

        if (bonusPopupText != null) bonusPopupText.gameObject.SetActive(false);
        if (moneyPopupText != null) moneyPopupText.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (GameState.Instance == null) return;
        GameState.Instance.OnMoneyChanged -= UpdateMoney;
        GameState.Instance.OnTimeChanged -= UpdateTimer;
        GameState.Instance.OnTimeBonusEarned -= ShowTimeBonus;
        GameState.Instance.OnMoneyEarned -= ShowMoneyPopup;
    }

    void ShowMoneyPopup(int amount)
    {
        if (moneyPopupText == null) return;
        if (moneyPopupCoroutine != null) StopCoroutine(moneyPopupCoroutine);
        moneyPopupCoroutine = StartCoroutine(MoneyPopupRoutine(amount));
    }

    void UpdateMoney(int amount)
    {
        moneyText.text = "Money: $" + amount;
    }

    void UpdateTimer(float time)
    {
        timerText.text = "Time: " + Mathf.CeilToInt(time);
    }

    public void SetDeliveryStatus(string status)
    {
        deliveryStatusText.text = status;
    }

    public void SetPrompt(string prompt)
    {
        promptText.text = prompt;
    }

    void ShowTimeBonus(float amount)
    {
        if (bonusPopupText == null) return;
        if (bonusPopupCoroutine != null) StopCoroutine(bonusPopupCoroutine);
        bonusPopupCoroutine = StartCoroutine(BonusPopupRoutine(amount));
    }

    System.Collections.IEnumerator BonusPopupRoutine(float amount)
    {
        bonusPopupText.text = "+" + Mathf.RoundToInt(amount) + "Time";
        bonusPopupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        bonusPopupText.gameObject.SetActive(false);
    }

    System.Collections.IEnumerator MoneyPopupRoutine(int amount)
    {
        moneyPopupText.text = "+$" + amount;
        moneyPopupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        moneyPopupText.gameObject.SetActive(false);
    }
}