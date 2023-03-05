using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float money = 0;
    [SerializeField] public float moneyPerSecond = 1;
    [SerializeField] public float moneyPerClick = 1;
    [SerializeField] private int _gold = 0;
    [SerializeField] private int _subscribers = 0;

    public Text moneyText;
    public Text moneyPerSecondText;
    public Text goldText;
    public Text subscriberText;

    private void Start()
    {
        UpdateStatTexts();
    }

    private void Update()
    {
        UpdateStatTexts();
    }

    public void UpdateStatTexts()
    {
        moneyText.text = Math.Round(money, 2).ToString();
        moneyPerSecondText.text = Math.Round(moneyPerSecond, 2).ToString();
        goldText.text = _gold.ToString();
        subscriberText.text = _subscribers.ToString();
    }

    public void GetMoneyByCLick()
    {
        money += moneyPerClick;
    }

    public void GetMoneyByIDLE()
    {
        money += moneyPerSecond;
    }

    public void GetOfflineMoney(double secondsOffline)
    {
        money += (float)secondsOffline * moneyPerSecond;
    }
}
