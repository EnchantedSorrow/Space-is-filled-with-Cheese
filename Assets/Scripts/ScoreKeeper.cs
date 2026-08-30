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
    
    private int _highScore = 0;

    private bool _gameOngoing;
    
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnHighScoreUpdate;

    void Awake()
    {
        ResetScore();

        if (OnScoreChanged == null) OnScoreChanged = delegate { };
        if (OnHighScoreUpdate == null) OnHighScoreUpdate = delegate { };
        
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    void OnEnable()
    {
        TimeKeeper.OnTimeChanged += UpdateScore;
        PlayerController.OnPlayerDeath += StopGame;
        PlayerController.OnPlayerDeath += HighScoreCheck;
    }

    void OnDisable()
    {
        TimeKeeper.OnTimeChanged -= UpdateScore;
        PlayerController.OnPlayerDeath -= StopGame;
        PlayerController.OnPlayerDeath -= HighScoreCheck;
    }

    void Start()
    {
        StartGame();
    }

    private void ResetScore()
    {
        Score = 0;
    }

    private void UpdateScore(float time)
    {
        if (_gameOngoing) Score += Mathf.FloorToInt(time * ScoreMultiplier);
    }
    
    private void StartGame()
    {
        _gameOngoing = true;
    }
    
    private void StopGame()
    {
        _gameOngoing = false;
    }

    private void HighScoreCheck()
    {
        if (_highScore < Score) _highScore = Score;
        PlayerPrefs.SetInt("HighScore", _highScore);
        OnHighScoreUpdate?.Invoke(_highScore);
    }
}