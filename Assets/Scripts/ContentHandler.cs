using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentHandler : Object
{
    private ICollection<Background> _backgrounds;
    private Button _moveLeftButton;
    private Button _moveRightButton;

    public void Initialize(Level level, Unit unit)
    {
        SetupBackgroundMusic(level);
        SetupBackground(level);
        SetupPlayerUnit(unit);
        SetupMovementButtons();
    }

    public void MoveBackgrounds(MovementDirection direction)
    {
        foreach (var background in _backgrounds)
        {
            background.MoveBackground(direction);
        }
    }

    public void UpdateEnabledMovementButtons(bool enableLeft, bool enableRight)
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
        _backgrounds = new List<Background>();
        var gameObjectsWithBackground = GameObject.FindGameObjectsWithTag("Background");
        foreach (var gameObjectWithBackground in gameObjectsWithBackground)
        {
            _backgrounds.Add(gameObjectWithBackground.GetComponent<Background>());
        }
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
        _moveLeftButton = GameObject.Find("MoveLeftButton").GetComponent<Button>();
        _moveRightButton = GameObject.Find("MoveRightButton").GetComponent<Button>();
    }
}
