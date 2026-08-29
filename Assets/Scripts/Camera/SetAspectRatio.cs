using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SetAspectRatio : MonoBehaviour
{
    [field: SerializeField] public float WidthRatio { get; private set; }
    [field: SerializeField] public float HeightRatio { get; private set; }
    
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        if (_camera == null)
        {
            Debug.LogWarning("No camera attached");
            _camera = Camera.main;
        }

        if (_camera != null)
        {
            _camera.aspect = Screen.width / (float)Screen.height;
        }
    }
    
}
