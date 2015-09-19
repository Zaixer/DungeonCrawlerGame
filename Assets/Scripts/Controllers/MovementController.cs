using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public static MovementController Instance;

    private bool _isEnabled = true;
    private MovementDirection _currentMovementDirection;
    private int _currentPosition;
    private int _minPosition;
    private int _maxPosition;
    private GameObject _movementCanvas;
    private Button _moveLeftButton;
    private Button _moveRightButton;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _minPosition = 0;
        _maxPosition = StateController.Instance.CurrentLevel.Length;
        _movementCanvas = Instantiate(Resources.Load<GameObject>("UI/MovementCanvas"));
        _moveLeftButton = GameObject.Find("MoveLeftButton").GetComponent<Button>();
        _moveRightButton = GameObject.Find("MoveRightButton").GetComponent<Button>();
    }

    void Update()
    {
        if (_isEnabled)
        {
            if (_currentMovementDirection != MovementDirection.None)
            {
                _currentPosition += _currentMovementDirection == MovementDirection.Left ? -1 : 1;
                BackgroundController.Instance.MoveBackgrounds(_currentMovementDirection);
                BattleController.Instance.CheckForRandomEncounter();
            }
            if (_currentPosition == _minPosition)
            {
                UpdateEnabledMovementButtons(false, true);
                ChangeMovementDirection(MovementDirection.None);
            }
            else if (_currentPosition == _maxPosition)
            {
                UpdateEnabledMovementButtons(true, false);
                ChangeMovementDirection(MovementDirection.None);
            }
            else
            {
                UpdateEnabledMovementButtons(true, true);
            }
        }
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        if (newMovementDirection != _currentMovementDirection)
        {
            _currentMovementDirection = newMovementDirection;
            PlayerUnitsController.Instance.UpdateWalkingForPlayerUnit(_currentMovementDirection != MovementDirection.None);
        }
    }

    public void DisableMovement()
    {
        _isEnabled = false;
        ShowMovementButtons(false);
        ChangeMovementDirection(MovementDirection.None);
    }

    public void EnableMovement()
    {
        _isEnabled = true;
        ShowMovementButtons(true);
    }

    private void ShowMovementButtons(bool show)
    {
        _movementCanvas.SetActive(show);
    }

    private void UpdateEnabledMovementButtons(bool enableLeft, bool enableRight)
    {
        if (_moveLeftButton.interactable != enableLeft)
        {
            _moveLeftButton.interactable = enableLeft;
        }
        if (_moveRightButton.interactable != enableRight)
        {
            _moveRightButton.interactable = enableRight;
        }
    }
}
