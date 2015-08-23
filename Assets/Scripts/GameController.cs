using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {    
    private MoveStatus _moveStatus = MoveStatus.None;
    private ICollection<Background> _backgrounds = new List<Background>();

    public void MoveLeft()
    {
        _moveStatus = MoveStatus.Left;
    }

    public void MoveRight()
    {
        _moveStatus = MoveStatus.Right;

    }

    public void StopMoving()
    {
        _moveStatus = MoveStatus.None;
    }

    void Start()
    {
        var gameObjectsWithBackground = GameObject.FindGameObjectsWithTag("Background");
        foreach (var gameObjectWithBackground in gameObjectsWithBackground)
        {
            _backgrounds.Add(gameObjectWithBackground.GetComponent<Background>());
        }
    }

    void Update()
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
