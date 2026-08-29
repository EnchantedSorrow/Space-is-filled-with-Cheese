using UnityEngine;
using UnityEngine.InputSystem;

namespace General
{
    public class MouseService : IMouse
    {
        public Vector3 GetMousePosition()
        {
            return Mouse.current.position.ReadValue();
        }
    }
}