using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MovementDirection MovementDirection;
    
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            MovementController.Instance.ChangeMovementDirection(MovementDirection);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            MovementController.Instance.ChangeMovementDirection(MovementDirection.None);
        }
    }
}
