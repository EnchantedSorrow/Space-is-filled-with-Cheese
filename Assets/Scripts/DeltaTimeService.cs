using UnityEngine;

public class DeltaTimeService : IDeltaTime
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}