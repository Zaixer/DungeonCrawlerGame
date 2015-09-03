using UnityEngine;

public class MovementHandler : Object
{
    private readonly ContentHandler _contentHandler;
    private readonly int _minPosition;
    private readonly int _maxPosition;
    private bool _isAbleToMove;
    private MovementDirection _currentMovementDirection;
    private int _currentPosition;

    public event System.EventHandler OnMovement;

    public MovementHandler(ContentHandler contentHandler, int levelLength)
    {
        _contentHandler = contentHandler;
        _minPosition = 0;
        _maxPosition = levelLength;
        _isAbleToMove = true;
    }

    public void PerformMovement()
    {
        if (_isAbleToMove)
        {
            if (_currentMovementDirection != MovementDirection.None)
            {
                _currentPosition += _currentMovementDirection == MovementDirection.Left ? -1 : 1;
                _contentHandler.MoveBackgrounds(_currentMovementDirection);
                if (OnMovement != null)
                {
                    OnMovement(this, System.EventArgs.Empty);
                }
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
    }

    internal void DisableMovement()
    {
        _isAbleToMove = false;
        _contentHandler.UpdateVisibleMovementButtons(false, false);
    }

    internal void EnableMovement()
    {
        _isAbleToMove = true;
        _contentHandler.UpdateVisibleMovementButtons(true, true);
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _currentMovementDirection = newMovementDirection;
    }
}
