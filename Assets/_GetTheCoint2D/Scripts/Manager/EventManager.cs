using System;

public static class EventManager
{
    public static event Action<int> _CoinCollected;
    public static event Action<int> _UpdateScoreText;
    public static event Action<float> _UpdateTimerText;
    public static event Action<float> _TimerIncreaseAction;
    public static event Action<float> _IncreaseJumpHeight;

    public static event Action<bool> _GameOverPanel;

    public static void CoinCollected(int _Amount)
    {
        _CoinCollected?.Invoke(_Amount);
    }

    public static void UpdateScoreText(int _Amount)
    {
        _UpdateScoreText?.Invoke(_Amount);
    }

    public static void UpdateTimerText(float _Amount)
    {
        _UpdateTimerText?.Invoke(_Amount);
    }

    public static void IncreaseTimerMethod(float _Amount) => _TimerIncreaseAction?.Invoke(_Amount);
    public static void IncreaseJumpHeight(float _Amount) => _IncreaseJumpHeight?.Invoke(_Amount);

    public static void UpdateGameOverPanel(bool _Booler) => _GameOverPanel?.Invoke(_Booler);
}
