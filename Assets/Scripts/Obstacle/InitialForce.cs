using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleForce : MonoBehaviour
{
    private Rigidbody2D _rb;

    [field: SerializeField] public Vector2 InitialDirection { get; private set; }
    [field: SerializeField] public float minInitSpeed { get; private set; }
    [field: SerializeField] public float maxInitSpeed { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    
    private IRandomFloat _randomF;
    public IRandomFloat RandomF { get => _randomF; set => _randomF = value; }
    
    private IRandomVector2 _randomV2;
    public IRandomVector2 RandomV2 { get => _randomV2; set => _randomV2 = value; }

    private void OnValidate()
    {
        if (minInitSpeed == 0) Debug.LogWarning("Obstacle minInitSpeed is 0");
        if (maxInitSpeed == 0) Debug.LogWarning("Obstacle maxInitSpeed is 0");
        if (minInitSpeed >= maxInitSpeed) Debug.LogWarning("Obstacle minInitSpeed should be less than maxInitSpeed");
    }
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogWarning("RB component not found");
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }

        RandomF = new RandomFloatService();
        RandomV2 = new RandomVector2Service();
    }
    
    private void Start()
    {
        InitialiseRandomVariables();
        ApplyInitialForce(InitialDirection, Speed);
    }

    private void InitialiseRandomVariables()
    {
        InitialDirection = RandomV2.GetRandomVector2();
        Speed = RandomF.GetRandomFloat(minInitSpeed, maxInitSpeed);
    }

    private void ApplyInitialForce(Vector2 initialForce, float initialSpeed)
    {
        _rb.AddForce(initialForce * initialSpeed, ForceMode2D.Impulse);
    }
}
