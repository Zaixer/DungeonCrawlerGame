using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameController _gameController;

    void Start()
    {
        _gameController = FindObjectOfType<Camera>().GetComponent<GameController>();
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _gameController.StartMovingLeft();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _gameController.StopMoving();
    }
}
