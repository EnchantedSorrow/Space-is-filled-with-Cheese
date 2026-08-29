using General;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMouse _mouseService;
    public IMouse MouseService { get => _mouseService; set => _mouseService = value; }

    void Awake()
    {
        MouseService = new MouseService();
    }

    void OnSetDestination()
    {
        ChangePlayerDirection();
    }

    private void ChangePlayerDirection()
    {
        transform.up = GetNewDirection();
    }

    private Vector3 GetNewDirection()
    {
        return MouseService.GetMousePosition() - transform.position;
    }
}
