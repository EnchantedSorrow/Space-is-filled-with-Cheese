using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleForce : MonoBehaviour
{
    private Rigidbody2D _rb;

    [field: SerializeField] public Vector2 InitialDirection { get; private set; }
    [field: SerializeField] public float InitialForce { get; private set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogWarning("RB component not found");
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }
    
    private void Start()
    {
        InitialDirection = Random.insideUnitCircle;
        ApplyInitialForce();
    }

    private void ApplyInitialForce()
    {
        _rb.AddForce(InitialDirection * InitialForce, ForceMode2D.Impulse);
    }
}
