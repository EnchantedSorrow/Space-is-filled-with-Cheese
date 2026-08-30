using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class RestartButtonUI : MonoBehaviour
{
    [field: SerializeField] public UIDocument UIDocument { get; private set; }
    
    //UI elements
    private Button _restartButton;
    
    void OnValidate()
    {
        if (UIDocument == null) Debug.LogWarning("GameUI UIDocument is null");
    }
    
    void Awake()
    {
        UIDocument = GetComponent<UIDocument>();
        _restartButton = UIDocument.rootVisualElement.Q<Button>("RestartButton");
    }

    void OnEnable()
    {
        PlayerController.OnPlayerDeath += ShowRestartButton;
    }

    void OnDisable()
    {
        PlayerController.OnPlayerDeath -= ShowRestartButton;
    }
    
    void Start()
    {
        //Hide Restart Button
        HideRestartButton();
    }

    private void HideRestartButton()
    {
        if (_restartButton != null) _restartButton.style.display = DisplayStyle.None;
    }

    void ShowRestartButton()
    {
        if (_restartButton != null) _restartButton.style.display = DisplayStyle.Flex;
    }
}
