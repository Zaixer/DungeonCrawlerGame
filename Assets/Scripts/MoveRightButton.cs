using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MovementController _movementController;

    void Start()
    {
        _movementController = FindObjectOfType<Camera>().GetComponent<MovementController>();
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _movementController.StartMovingRight();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _movementController.StopMoving();
    }
}