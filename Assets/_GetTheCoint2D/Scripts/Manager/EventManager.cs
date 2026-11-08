using System;

public static class EventManager
{
    public static event Action<int> _CoinCollected;
    public static event Action<int> _UpdateScoreText;

    public static void CoinCollected(int _Amount)
    {
        _CoinCollected?.Invoke(_Amount);
    }

    public static void UpdateScoreText(int _Amount)
    {
        _UpdateScoreText?.Invoke(_Amount);
    }
}
