using UnityEngine;

public class MovementHandler : Object
{
    private readonly ContentHandler _contentHandler;
    private readonly int _minPosition;
    private readonly int _maxPosition;
    private MovementDirection _currentMovementDirection;
    private int _currentPosition;    

    public MovementHandler(ContentHandler contentHandler, int levelLength)
    {
        _contentHandler = contentHandler;
        _minPosition = 0;
        _maxPosition = levelLength;
    }

    public void PerformMovement()
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
        if (_currentPosition == _minPosition)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentHandler.UpdateEnabledMovementButtons(false, true);
        }
        else if (_currentPosition == _maxPosition)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentHandler.UpdateEnabledMovementButtons(true, false);
        }
        else
        {
            _contentHandler.UpdateEnabledMovementButtons(true, true);
        }
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _currentMovementDirection = newMovementDirection;
    }
}
