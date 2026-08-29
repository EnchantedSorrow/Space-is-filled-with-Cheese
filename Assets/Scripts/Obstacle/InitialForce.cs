using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleForce : MonoBehaviour
{
    private Rigidbody2D _rb;

    [field: SerializeField] public VectorDirection InitialDirection { get; private set; }
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
        _rb.AddForce(Vector2Direction.GetVector2FromDirection(InitialDirection) * InitialForce, ForceMode2D.Impulse);
    }
}
