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
                Debug.Log($"Score: {_score}");
            }
        }
    }

    void Awake()
    {
        ResetScore();
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