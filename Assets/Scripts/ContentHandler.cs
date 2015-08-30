using System.Collections.Generic;
using UnityEngine;

public class ContentHandler : Object
{
    private ICollection<Background> _backgrounds;

    public void InitializeContent(Level level, Unit unit)
    {
        SetupBackgroundMusic(level);
        SetupBackground(level);
        SetupPlayerUnit(unit);
        SetupMovementButtons();
    }

    public void MoveBackground(MovementDirection movementDirection)
    {
        LoadBackgroundsIfNotDoneAlready();
        switch (movementDirection)
        {
            case MovementDirection.Left:
                foreach (var background in _backgrounds)
                {
                    background.MoveBackgroundLeft();
                }
                break;
            case MovementDirection.Right:
                foreach (var background in _backgrounds)
                {
                    background.MoveBackgroundRight();
                }
                break;
            default:
                break;
        }
    }

    private void SetupBackgroundMusic(Level level)
    {
        var backgroundMusic = Resources.Load(level.BackgroundMusicResource);
        Instantiate(backgroundMusic);
    }

    private void SetupBackground(Level level)
    {
        var backgroundBottom = Resources.Load(level.BackgroundBottomResource);
        var backgroundTop = Resources.Load(level.BackgroundTopResource);
        Instantiate(backgroundBottom);
        Instantiate(backgroundTop);
    }

    private void SetupPlayerUnit(Unit unit)
    {
        var snail = Resources.Load(unit.Resource);
        Instantiate(snail);
    }

    private void SetupMovementButtons()
    {
        var canvas = Resources.Load("UI/MovementCanvas");
        Instantiate(canvas);
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
}
