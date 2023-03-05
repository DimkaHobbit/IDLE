using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDLEClick : MonoBehaviour
{
    public PlayerStats playerStats;
    public float cooldown;

    void Start()
    {
        IEnumerator clicking = Clicking();
        StartCoroutine(clicking);
    }

    private IEnumerator Clicking()
    {
        while (true)
        {
            playerStats.GetMoneyByIDLE();
            yield return new WaitForSeconds(cooldown);
        }        
    }
}
