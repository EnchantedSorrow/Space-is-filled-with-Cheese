using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float ThrustForce { get; private set; }
    private Rigidbody2D _rb;

    private IMouse _mouseService;
    public IMouse MouseService { get => _mouseService; set => _mouseService = value; }

    public static event Action OnBoost;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogWarning("No rigidbody found");
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }

        MouseService = new MouseService();
        
        if (OnBoost == null) OnBoost = delegate { };
    }

    void OnSetDestination()
    {
        ChangePlayerDirection();
    }

    private void ChangePlayerDirection()
    {
        Vector2 newDirection = GetNewDirection();
        transform.up = newDirection;
        _rb.AddForce(newDirection * ThrustForce);
        OnBoost?.Invoke();
    }

    private Vector2 GetNewDirection()
    {
        return (Camera.main.ScreenToWorldPoint(MouseService.GetMousePosition()) - transform.position).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}