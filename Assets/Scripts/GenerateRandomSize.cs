using UnityEngine;

public class GenerateRandomSize : MonoBehaviour
{
    [field: SerializeField] public float minScale { get; private set; }
    [field: SerializeField] public float maxScale { get; private set; }

    private IRandomFloat _randomFloat;
    public IRandomFloat RandomFloat { get => _randomFloat; set => _randomFloat = value; }

    private void Awake()
    {
        RandomFloat = new RandomFloatService();
    }
    
    private void Start()
    {
        float randomScale = RandomFloat.GetRandomFloat(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
    }
}
