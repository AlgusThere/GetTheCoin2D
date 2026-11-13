using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(_ScoreText == null) return;
        _ScoreText.text = "SCORE: " + _Amount.ToString();
    }

    private void UpdateTimerText(float _Amount)
    {
        if(_TimerText == null) return;
        _TimerText.text = _Amount.ToString("F1");
    }

    private void GameOverPanelControl(bool _Booler)
    {
        if(_GameOverPanel == null) return;
        _GameOverPanel.SetActive(_Booler);
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton() => Application.Quit();
}
