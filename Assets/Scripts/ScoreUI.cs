using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ScoreUI : MonoBehaviour
{
    [field: SerializeField] public UIDocument UIDocument { get; private set; }

    void OnValidate()
    {
        if (UIDocument == null) Debug.LogWarning("GameUI UIDocument is null");
    }
    
    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
    }

    void OnEnable()
    {
        ScoreKeeper.OnScoreChanged += UpdateScoreUI;
    }

    private void OnDisable()
    {
        ScoreKeeper.OnScoreChanged -= UpdateScoreUI;
    }

    void UpdateScoreUI(int score)
    {
        Debug.Log($"Score updated: {score}");
    }
}
