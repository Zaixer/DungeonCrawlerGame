using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MovementController _movementController;

    void Start ()
    {
        _movementController = FindObjectOfType<Camera>().GetComponent<MovementController>();
	}
	
	void Update ()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _movementController.StartMovingLeft();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _movementController.StopMoving();
    }
}
