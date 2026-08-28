using UnityEngine;

public class GenerateRandomSize : MonoBehaviour
{
    [field: SerializeField] public float minScale { get; private set; }
    [field: SerializeField] public float maxScale { get; private set; }

    private void Start()
    {
        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1.0f);
    }

    private float GetRandomValue(float min, float max)
    {
        return Random.Range(min, max);
    }
}
