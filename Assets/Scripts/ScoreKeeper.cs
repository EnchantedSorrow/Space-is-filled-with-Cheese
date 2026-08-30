using System;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [field: SerializeField] public float ScoreMultiplier { get; private set; }

    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            if (value < 0) Debug.LogWarning("Score cannot be less than 0");
            else
            {
                _score = value;
                OnScoreChanged?.Invoke(value);
            }
        }
    }
    
    public static event Action<int> OnScoreChanged;

    void Awake()
    {
        ResetScore();

        if (OnScoreChanged == null) OnScoreChanged = delegate { };
    }

    void OnEnable()
    {
        TimeKeeper.OnTimeChanged += UpdateScore;
    }

    void OnDisable()
    {
        TimeKeeper.OnTimeChanged -= UpdateScore;
    }

    private void ResetScore()
    {
        Score = 0;
    }

    private void UpdateScore(float time)
    {
        Score += Mathf.FloorToInt(time * ScoreMultiplier);
    }
}