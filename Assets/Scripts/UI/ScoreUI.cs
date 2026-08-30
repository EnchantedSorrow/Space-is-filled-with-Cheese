using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ScoreUI : MonoBehaviour
{
    [field: SerializeField] public UIDocument UIDocument { get; private set; }
    
    //UI elements
    private Label _scoreText;
    private Label _highScoreText;

    void OnValidate()
    {
        if (UIDocument == null) Debug.LogWarning("GameUI UIDocument is null");
    }
    
    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        _scoreText = UIDocument.rootVisualElement.Q<Label>("ScoreLabel");
        _highScoreText = UIDocument.rootVisualElement.Q<Label>("HighScoreLabel");
    }

    void OnEnable()
    {
        ScoreKeeper.OnScoreChanged += UpdateScoreUI;
        PlayerController.OnPlayerDeath += ShowHighScore;
        ScoreKeeper.OnHighScoreUpdate += UpdateHighScoreUI;
    }

    private void OnDisable()
    {
        ScoreKeeper.OnScoreChanged -= UpdateScoreUI;
        PlayerController.OnPlayerDeath += ShowHighScore;
        ScoreKeeper.OnHighScoreUpdate -= UpdateHighScoreUI;
    }

    private void Start()
    {
        HideHighScore();
    }

    void UpdateScoreUI(int score)
    {
        if (_scoreText != null) _scoreText.text = $"Score: {score}";
    }

    void HideHighScore()
    {
        if (_highScoreText != null) _highScoreText.style.display = DisplayStyle.None;
    }

    void ShowHighScore()
    {
        if (_highScoreText != null) _highScoreText.style.display = DisplayStyle.Flex;
    }

    void UpdateHighScoreUI(int score)
    {
        if (_highScoreText != null) _highScoreText.text = $"High Score: {score}";
    }
}
