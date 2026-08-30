using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ScoreUI : MonoBehaviour
{
    [field: SerializeField] public UIDocument UIDocument { get; private set; }
    
    //UI elements
    private Label _scoreText;

    void OnValidate()
    {
        if (UIDocument == null) Debug.LogWarning("GameUI UIDocument is null");
    }
    
    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        _scoreText = UIDocument.rootVisualElement.Q<Label>("ScoreLabel");
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
        if (_scoreText != null) _scoreText.text = $"Score: {score}";
    }
}
