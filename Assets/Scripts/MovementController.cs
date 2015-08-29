using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    private MoveStatus _moveStatus;
    private ICollection<Background> _backgrounds;

    void Update()
    {
        PerformMovement();
    }

    public void StartMovingLeft()
    {
        _moveStatus = MoveStatus.Left;
    }

    public void StartMovingRight()
    {
        _moveStatus = MoveStatus.Right;

    }

    public void StopMoving()
    {
        _moveStatus = MoveStatus.None;
    }

    private void PerformMovement()
    {
        LoadBackgroundsIfNotDoneAlready();
        switch (_moveStatus)
        {
            case MoveStatus.Left:
                foreach (var background in _backgrounds)
                {
                    background.MoveBackgroundLeft();
                }
                break;
            case MoveStatus.Right:
                foreach (var background in _backgrounds)
                {
                    background.MoveBackgroundRight();
                }
                break;
            default:
                break;
        }
    }

    private void LoadBackgroundsIfNotDoneAlready()
    {
        if (_backgrounds == null)
        {
            _backgrounds = new List<Background>();
            var gameObjectsWithBackground = GameObject.FindGameObjectsWithTag("Background");
            foreach (var gameObjectWithBackground in gameObjectsWithBackground)
            {
                _backgrounds.Add(gameObjectWithBackground.GetComponent<Background>());
            }
        }
    }

    private enum MoveStatus
    {
        None,
        Left,
        Right
    }
}
