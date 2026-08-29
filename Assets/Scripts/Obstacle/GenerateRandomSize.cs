using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GenerateRandomSize : MonoBehaviour
{
    [field: SerializeField] public float MinScale { get; private set; }
    [field: SerializeField] public float MaxScale { get; private set; }

    private IRandomFloat _randomFloat;
    public IRandomFloat RandomFloat { get => _randomFloat; set => _randomFloat = value; }

    private Rigidbody2D _rb;
    

    private void Awake()
    {
        RandomFloat = new RandomFloatService();
        float randomScale = RandomFloat.GetRandomFloat(MinScale, MaxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
        
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogWarning("No Rigidbody 2D found");
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }

        _rb.mass *= randomScale;
    }
}
