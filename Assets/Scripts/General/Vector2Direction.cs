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
    private IRandomInt _randomI;
    public IRandomInt RandomI { get => _randomI; set => _randomI = value; }

    public Vector2Direction()
    {
        RandomI = new RandomIntService();
    }
    
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

    public static int VectorDirectionLength()
    {
        return Enum.GetNames(typeof(VectorDirection)).Length;
    }

    public static VectorDirection GetDirectionFromIndex(int index)
    {
        return (VectorDirection) index;
    }
}