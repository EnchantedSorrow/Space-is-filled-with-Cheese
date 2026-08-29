public class RandomIntService : IRandomInt
{
    public int GetRandomInt(int min, int max)
    {
        return RandomInt.GenerateRandomInt(min, max);
    }
}

public class RandomInt
{
    public static int GenerateRandomInt(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}