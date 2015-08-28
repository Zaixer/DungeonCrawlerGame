using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {    
    private MoveStatus _moveStatus;
    private ICollection<Background> _backgrounds;

    void Start()
    {
        _backgrounds = GetBackgrounds();
    }

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

    private ICollection<Background> GetBackgrounds()
    {
        var backgrounds = new List<Background>();
        var gameObjectsWithBackground = GameObject.FindGameObjectsWithTag("Background");
        foreach (var gameObjectWithBackground in gameObjectsWithBackground)
        {
            backgrounds.Add(gameObjectWithBackground.GetComponent<Background>());
        }
        return backgrounds;
    }

    private void PerformMovement()
    {
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

    private enum MoveStatus
    {
        None,
        Left,
        Right
    }
}
