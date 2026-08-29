using UnityEngine;
using UnityEngine.InputSystem;

public class MouseService : IMouse
{
    public Vector3 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }
}
