using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ScoreText;

    void OnEnable()
    {
        EventManager._UpdateScoreText += UpdateScoretext;
    }
    void OnDisable()
    {
        EventManager._UpdateScoreText -= UpdateScoretext;
    }

    private void UpdateScoretext(int _Amount)
    {
        _ScoreText.text = "SCORE: " + _Amount.ToString();
    }
}
