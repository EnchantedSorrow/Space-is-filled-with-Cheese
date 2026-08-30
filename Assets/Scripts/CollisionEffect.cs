using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    [field: SerializeField] public GameObject ExplosionEffect { get; private set; }

    void OnValidate()
    {
        if (ExplosionEffect == null) Debug.LogWarning("Player Controller Explosion effect is null");
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
    }
}
