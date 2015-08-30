using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MovementDirection movementDirection;

    private GameController _gameController;
    private Button _button;

    void Start()
    {
        _gameController = FindObjectOfType<Camera>().GetComponent<GameController>();
        _button = GetComponent<Button>();
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _gameController.ChangeMovementDirection(movementDirection);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_button.interactable)
        {
            _gameController.ChangeMovementDirection(MovementDirection.None);
        }
    }
}
