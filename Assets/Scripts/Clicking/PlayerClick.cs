using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public PlayerStats playerStats;
    public float cooldown;

    private bool _isCanClick = true;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = gameObject.AddComponent<BoxCollider2D>();
        _boxCollider.size = GetComponent<RectTransform>().sizeDelta;
    }

    private void OnMouseDrag()
    {
        if (_isCanClick)
        {
            Click();
        }        
    }

    private void Click()
    {
        Debug.Log("Нажал");
        playerStats.GetMoneyByCLick();
        Invoke("CanClick", cooldown);
        _isCanClick = false;
    }

    private void CanClick()
    {
        _isCanClick = true;
    }
}
