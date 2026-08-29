using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpeedManager : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [field: SerializeField] public float MaxSpeed { get; private set; }

    void OnValidate()
    {
        if (MaxSpeed <= 0) Debug.LogWarning("MaxSpeed must be greater than zero");
    }
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogWarning("No rigidbody attached");
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    public void FixedUpdate()
    {
        _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, MaxSpeed);
    }
}
