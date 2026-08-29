using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private float _elapsedTime;
    public float ElapsedTime
    {
        get => _elapsedTime;
        set
        {
            if (value < 0) Debug.LogWarning("Elapsed time cannot be less than 0");
            else _elapsedTime = value;
        }
    }

    private IDeltaTime _deltaTime;

    void Awake()
    {
        ResetElapsedTime();
        _deltaTime = new DeltaTimeService();
    }

    void Update()
    {
        ElapsedTime += _deltaTime.GetDeltaTime();
        Debug.Log(ElapsedTime);
    }

    private void ResetElapsedTime()
    {
        ElapsedTime = 0f;
    }
}
