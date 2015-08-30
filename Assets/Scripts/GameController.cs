using UnityEngine;

public class GameController : MonoBehaviour
{
    private ContentHandler _contentHandler = new ContentHandler();
    private Level _level = new TestLevel();
    private Unit _playerUnit = new SnailUnit();
    private MovementDirection _currentMovementDirection;

    void Start()
    {
        _contentHandler.InitializeContent(_level, _playerUnit);
    }

    void Update()
    {
        PerformMovement();
    }

    public void StartMovingLeft()
    {
        _currentMovementDirection = MovementDirection.Left;
    }

    public void StartMovingRight()
    {
        _currentMovementDirection = MovementDirection.Right;

    }

    public void StopMoving()
    {
        _currentMovementDirection = MovementDirection.None;
    }

    private void PerformMovement()
    {
        _contentHandler.MoveBackground(_currentMovementDirection);
    }
}
