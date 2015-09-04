using UnityEngine;

public class MovementController : MonoBehaviour
{
    private ContentController _contentController;
    private MovementDirection _currentMovementDirection;
    private int _minPosition;
    private int _maxPosition;
    private int _currentPosition;
    private bool _isAbleToMove;

    public event System.EventHandler OnMovement;

    void Start()
    {
        _contentController = GetComponentInParent<ContentController>();
        _minPosition = 0;
        _maxPosition = _contentController.Level.Length;
        _isAbleToMove = true;
        var battleController = GetComponentInParent<BattleController>();
        battleController.OnBattleStart += BattleController_OnBattleStart;
        battleController.OnBattleEnd += BattleController_OnBattleEnd;
    }

    void Update()
    {
        if (_isAbleToMove)
        {
            PerformMovement();
        }
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _currentMovementDirection = newMovementDirection;
    }

    private void BattleController_OnBattleStart(object sender, System.EventArgs e)
    {
        _contentController.HideMovementButtons();
        _currentMovementDirection = MovementDirection.None;
    }

    private void BattleController_OnBattleEnd(object sender, System.EventArgs e)
    {
        _contentController.ShowMovementButtons();
    }

    private void PerformMovement()
    {
        if (_currentMovementDirection != MovementDirection.None)
        {
            _currentPosition += _currentMovementDirection == MovementDirection.Left ? -1 : 1;
            _contentController.MoveBackgrounds(_currentMovementDirection);
            if (OnMovement != null)
            {
                OnMovement(this, System.EventArgs.Empty);
            }
        }
        if (_currentPosition == _minPosition)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentController.UpdateEnabledMovementButtons(false, true);
        }
        else if (_currentPosition == _maxPosition)
        {
            _currentMovementDirection = MovementDirection.None;
            _contentController.UpdateEnabledMovementButtons(true, false);
        }
        else
        {
            _contentController.UpdateEnabledMovementButtons(true, true);
        }
    }
}
