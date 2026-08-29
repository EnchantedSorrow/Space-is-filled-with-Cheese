public class RandomFloatService : IRandomFloat
{
    public float GetRandomFloat(float min, float max)
    {
        return RandomFloat.GenerateRandomFloat(min, max);
    }
}

public class RandomFloat
{
    public static float GenerateRandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}