using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float _RemainingTime = 20f;

    void OnEnable() => EventManager._TimerIncreaseAction += TimerIncreaser;
    void OnDisable() => EventManager._TimerIncreaseAction -= TimerIncreaser;

    void Start()
    {
        Time.timeScale = 1f;
    }

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
            EventManager.UpdateGameOverPanel(true);
            Time.timeScale = 0f;
        }
    }

    void TimerIncreaser(float _Amount)
    {
        _RemainingTime += _Amount;

        EventManager.UpdateTimerText(_RemainingTime);
    }
}
