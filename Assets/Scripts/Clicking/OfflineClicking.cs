using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OfflineClicking : MonoBehaviour
{
    public PlayerStats playerStats;
    [SerializeField] private long _whenApplicationWasClosed;

    private void Start()
    {
        DateTime whenClosed = DateTime.FromBinary(_whenApplicationWasClosed);
        double secondsAfterLastOpening = DateTime.Now.Subtract(whenClosed).TotalSeconds;

        playerStats.GetOfflineMoney(secondsAfterLastOpening);
    }

    private void OnApplicationQuit()
    {
        _whenApplicationWasClosed = DateTime.Now.ToBinary();
    }
}
