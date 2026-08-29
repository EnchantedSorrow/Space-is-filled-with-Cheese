using UnityEngine;
using UnityEngine.Serialization;

public class GenerateRandomSize : MonoBehaviour
{
    [field: SerializeField] public float MinScale { get; private set; }
    [field: SerializeField] public float MaxScale { get; private set; }

    private IRandomFloat _randomFloat;
    public IRandomFloat RandomFloat { get => _randomFloat; set => _randomFloat = value; }
    

    private void Awake()
    {
        RandomFloat = new RandomFloatService();
        float randomScale = RandomFloat.GetRandomFloat(MinScale, MaxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
    }
}
