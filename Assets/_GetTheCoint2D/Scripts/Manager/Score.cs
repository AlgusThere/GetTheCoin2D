using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int _Score;

    void OnEnable()
    {
        EventManager._CoinCollected += UpdateScore;
    }

    void OnDisable()
    {
        EventManager._CoinCollected -= UpdateScore;
    }

    void Start()
    {
        _Score = 0;
        EventManager.UpdateScoreText(_Score);
    }

    void UpdateScore(int _Amount)
    {
        _Score += _Amount;
        EventManager.UpdateScoreText(_Score);
    }

    public void CheckScore(float _Amount)
    {
        if(_Score >= 100)
        {
            EventManager.IncreaseJumpHeight(_Amount);
            _Score -= 100;
            EventManager.UpdateScoreText(_Score);
        }
    }
}
