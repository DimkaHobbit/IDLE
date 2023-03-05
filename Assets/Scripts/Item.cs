using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemProperty itemProperty;

    [Space]

    public Text nameText;
    public Image image;
    public Text lvlText;
    public Slider lvlSlider;
    public Text costText;
    public Text tapIncomeText;
    public Text passIncomeText;

    public ItemsManager _itemsManager;
    public PlayerStats _playerStats;

    public void SetProperties(ItemsManager itemsManager, PlayerStats playerStats)
    {
        _itemsManager = itemsManager;
        _playerStats = playerStats;
        lvlSlider.maxValue = itemProperty.maxLvl;

        UpdateStatTexts();
    }

    public void BuyUpgrage()
    {      
        if (_playerStats.money >= itemProperty.cost)
        {
            if (itemProperty.lvl < itemProperty.maxLvl)
            {
                Debug.Log("Улучшено");
                itemProperty.lvl++;
                itemProperty.cost *= _itemsManager.costFactor;
                itemProperty.tapIncome *= _itemsManager.tapIncomeFactor;
                itemProperty.passIncome *= _itemsManager.passIncomeFactor;

                float prevLvlDifference = itemProperty.tapIncome - (itemProperty.tapIncome / _itemsManager.tapIncomeFactor);
                _playerStats.moneyPerClick += prevLvlDifference;

                prevLvlDifference = itemProperty.passIncome - (itemProperty.passIncome / _itemsManager.passIncomeFactor);
                _playerStats.moneyPerSecond += prevLvlDifference;

                UpdateStatTexts();
            }
        }
    }

    private void UpdateStatTexts()
    {
        lvlText.text = itemProperty.lvl.ToString();
        lvlSlider.value = itemProperty.lvl;
        costText.text = $"{Math.Round(itemProperty.cost, 2)}$";
        tapIncomeText.text = $"+{itemProperty.tapIncome} <color=green>Tap Income</color>";
        passIncomeText.text = $"+{itemProperty.passIncome} <color=green>Passive Income</color>";
    }
}

[System.Serializable]
public struct ItemProperty
{
    public string name;
    public Sprite sprite;
    public int lvl;
    public int maxLvl;
    public float cost;
    public float tapIncome;
    public float passIncome;
}
