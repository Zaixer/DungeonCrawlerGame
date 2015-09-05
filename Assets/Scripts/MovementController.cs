using UnityEngine;

public class MovementController : MonoBehaviour
{
    private ContentController _contentController;
    private MovementDirection _currentMovementDirection;
    private int _minPosition;
    private int _maxPosition;
    private int _currentPosition;

    public event System.EventHandler OnMovement;

    void Start()
    {
        _contentController = GetComponentInParent<ContentController>();
        _minPosition = 0;
        _maxPosition = _contentController.Level.Length;
        var battleController = GetComponentInParent<BattleController>();
        battleController.OnBattleStart += BattleController_OnBattleStart;
        battleController.OnBattleEnd += BattleController_OnBattleEnd;
    }

    void Update()
    {
        PerformMovement();
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        if (newMovementDirection != _currentMovementDirection)
        {
            _currentMovementDirection = newMovementDirection;
            _contentController.UpdateWalkingForPlayerUnit(_currentMovementDirection != MovementDirection.None);
        }
    }

    private void BattleController_OnBattleStart(object sender, System.EventArgs e)
    {
        _contentController.HideMovementButtons();
        ChangeMovementDirection(MovementDirection.None);
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
            _contentController.UpdateEnabledMovementButtons(false, true);
            ChangeMovementDirection(MovementDirection.None);
        }
        else if (_currentPosition == _maxPosition)
        {
            _contentController.UpdateEnabledMovementButtons(true, false);
            ChangeMovementDirection(MovementDirection.None);
        }
        else
        {
            _contentController.UpdateEnabledMovementButtons(true, true);
        }
    }
}
