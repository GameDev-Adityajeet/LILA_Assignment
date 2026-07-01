using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [Header("Money")]
    public int money = 0;

    [Header("Timer")]
    public float timeRemaining = 120f;
    public float timeBonusPerDelivery = 10f;
    public bool isGameOver = false;

    public event Action<int> OnMoneyChanged;
    public event Action<float> OnTimeChanged;
    public event Action OnGameOver;

    public event Action<float> OnTimeBonusEarned;
    public event Action<int> OnMoneyEarned;
    
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;
        OnTimeChanged?.Invoke(timeRemaining);

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isGameOver = true;
            OnGameOver?.Invoke();
            Debug.Log("GAME OVER. Final money: " + money);
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        OnMoneyChanged?.Invoke(money);
        if (amount > 0)
            OnMoneyEarned?.Invoke(amount);
    }
    
    public void AddTimeBonus()
    {
        timeRemaining += timeBonusPerDelivery;
        OnTimeChanged?.Invoke(timeRemaining);
        OnTimeBonusEarned?.Invoke(timeBonusPerDelivery);
    }
}