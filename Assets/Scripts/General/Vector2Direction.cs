using System;
using UnityEngine;

[Serializable]
public enum VectorDirection : byte
{
    Left,
    Right,
    Up,
    Down
};

public class Vector2Direction
{
    public static Vector2 GetVector2FromDirection(VectorDirection dir)
    {
        switch (dir)
        {
            case VectorDirection.Left:
                return Vector2.left;
            
            case VectorDirection.Right:
                return Vector2.right;
            
            case VectorDirection.Up:
                return Vector2.up;
            
            case VectorDirection.Down:
                return Vector2.down;
            
            default:
                return Vector2.zero;
        }
    }
}