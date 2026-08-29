using UnityEngine;

public interface IRandomFloat
{
    float GetRandomFloat(float min, float max);
}

public interface IRandomInt
{
    int GetRandomInt(int min, int max);
}

public interface IRandomVector2
{
    Vector2 GetRandomVector2();
}