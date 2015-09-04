using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MovementDirection movementDirection;

    private MovementController _movementController;
    private Button _button;

    void Start()
    {
        _movementController = FindObjectOfType<Camera>().GetComponent<MovementController>();
        _button = GetComponent<Button>();
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _movementController.ChangeMovementDirection(movementDirection);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _movementController.ChangeMovementDirection(MovementDirection.None);
        }
    }
}
