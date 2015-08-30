using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly ContentHandler _contentHandler = new ContentHandler();
    private readonly Level _level = new TestLevel();
    private readonly Unit _playerUnit = new SnailUnit();
    private MovementDirection _currentMovementDirection;
    private int _currentPosition;

    void Start()
    {
        _contentHandler.Initialize(_level, _playerUnit);
    }

    void Update()
    {
        PerformMovement();
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _currentMovementDirection = newMovementDirection;
    }

    private void PerformMovement()
    {
        switch (_currentMovementDirection)
        {
            case MovementDirection.Left:
                _currentPosition -= 1;
                _contentHandler.MoveBackgrounds(_currentMovementDirection);
                break;
            case MovementDirection.Right:
                _currentPosition += 1;
                _contentHandler.MoveBackgrounds(_currentMovementDirection);
                break;
        }
        if (_currentPosition == 0)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentHandler.UpdateEnabledMovementButtons(false, true);
        }
        else if (_currentPosition == _level.Length)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentHandler.UpdateEnabledMovementButtons(true, false);
        }
        else
        {
            _contentHandler.UpdateEnabledMovementButtons(true, true);
        }
    }
}
