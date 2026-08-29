using UnityEngine;

public class RandomVector2Service : IRandomVector2
{
    public Vector2 GetRandomVector2()
    {
        return RandomVector2.GenerateInCircle();   
    }
}

public class RandomVector2
{
    public static Vector2 GenerateInCircle()
    {
        return UnityEngine.Random.insideUnitCircle;
    }
}