using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _ScoreText;
    [SerializeField] TextMeshProUGUI _TimerText;

    [Header("Panels")]
    [SerializeField] GameObject _GameOverPanel;

    void OnEnable()
    {
        EventManager._UpdateScoreText += UpdateScoretext;
        EventManager._UpdateTimerText += UpdateTimerText;

        EventManager._GameOverPanel += GameOverPanelControl;
    }
    void OnDisable()
    {
        EventManager._UpdateScoreText -= UpdateScoretext;
        EventManager._UpdateTimerText -= UpdateTimerText;

        EventManager._GameOverPanel -= GameOverPanelControl;
    }

    private void UpdateScoretext(int _Amount)
    {
        _ScoreText.text = "SCORE: " + _Amount.ToString();
    }

    private void UpdateTimerText(float _Amount)
    {
        _TimerText.text = _Amount.ToString("F1");
    }

    private void GameOverPanelControl(bool _Booler)
    {
        _GameOverPanel.SetActive(_Booler);
    }
}
