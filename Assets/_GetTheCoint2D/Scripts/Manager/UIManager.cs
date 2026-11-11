using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ScoreText;
    [SerializeField] TextMeshProUGUI _TimerText;

    void OnEnable()
    {
        EventManager._UpdateScoreText += UpdateScoretext;
        EventManager._UpdateTimerText += UpdateTimerText;
    }
    void OnDisable()
    {
        EventManager._UpdateScoreText -= UpdateScoretext;
        EventManager._UpdateTimerText -= UpdateTimerText;
    }

    private void UpdateScoretext(int _Amount)
    {
        _ScoreText.text = "SCORE: " + _Amount.ToString();
    }

    private void UpdateTimerText(float _Amount)
    {
        _TimerText.text = _Amount.ToString("F1");
    }
}
