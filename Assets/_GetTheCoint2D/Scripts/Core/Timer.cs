using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float _RemainingTime = 20f;

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if(_RemainingTime > 0)
        {
            _RemainingTime -= Time.deltaTime;

            EventManager.UpdateTimerText(_RemainingTime);            
        }
        else
        {
            Debug.Log("Süren Bitti :(");
        }

        
    }
}
