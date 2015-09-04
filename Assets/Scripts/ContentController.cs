using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    private readonly Level _level = new TestLevel();
    private ICollection<Background> _backgrounds;
    private GameObject _movementCanvas;
    private Button _moveLeftButton;
    private Button _moveRightButton;

    public Level Level { get { return _level; } }

    void Start()
    {
        SetupBackgroundMusic(_level);
        SetupBackground(_level);
        SetupPlayerUnit(new SnailUnit());
        SetupMovementButtons();
    }
    
    void Update()
    {
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

    public void ShowMovementButtons()
    {
        _movementCanvas.SetActive(true);
    }

    public void HideMovementButtons()
    {
        _movementCanvas.SetActive(false);
    }

    private void SetupBackgroundMusic(Level level)
    {
        Instantiate(Resources.Load(level.BackgroundMusicResource));
    }

    private void SetupBackground(Level level)
    {
        Instantiate(Resources.Load(level.BackgroundBottomResource));
        Instantiate(Resources.Load(level.BackgroundTopResource));
        _backgrounds = new List<Background>();
        var gameObjectsWithBackground = GameObject.FindGameObjectsWithTag("Background");
        foreach (var gameObjectWithBackground in gameObjectsWithBackground)
        {
            _backgrounds.Add(gameObjectWithBackground.GetComponent<Background>());
        }
    }

    private void SetupPlayerUnit(Unit unit)
    {
        Instantiate(Resources.Load(unit.Resource));
    }

    private void SetupMovementButtons()
    {
        _movementCanvas = Instantiate(Resources.Load<GameObject>("UI/MovementCanvas"));
        _moveLeftButton = GameObject.Find("MoveLeftButton").GetComponent<Button>();
        _moveRightButton = GameObject.Find("MoveRightButton").GetComponent<Button>();
    }
}
