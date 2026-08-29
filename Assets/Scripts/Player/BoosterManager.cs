using System.Collections;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public GameObject Boosters;
    [field: SerializeField] public float BoosterDuration { get; private set; }

    void OnValidate()
    {
        if (Boosters == null) Debug.LogWarning("Player Boosters variable is null");
        if (BoosterDuration <= 0) Debug.LogWarning("Booster duration must be greater than zero");
    }

    void Awake()
    {
        TurnOffBoosters();
    }

    private void TurnOffBoosters()
    {
        Boosters.SetActive(false);
    }

    void OnEnable()
    {
        PlayerController.OnBoost += TriggerBoosters;
    }

    void OnDisable()
    {
        PlayerController.OnBoost -= TriggerBoosters;
    }

    void TriggerBoosters()
    {
        Boosters.SetActive(true);
        StartCoroutine(BoosterCountdown());
    }

    IEnumerator BoosterCountdown()
    {
        yield return new WaitForSeconds(BoosterDuration);
        TurnOffBoosters();
    }
}
