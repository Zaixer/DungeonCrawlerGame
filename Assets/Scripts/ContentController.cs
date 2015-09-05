using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentController : MonoBehaviour
{
    private readonly Level _level = new TestLevel();
    private ICollection<Background> _backgrounds;
    private Animator _playerUnitAnimator;
    private AudioSource _normalMusicAudioSource;
    private AudioSource _battleMusicAudioSource;
    private GameObject _movementCanvas;
    private Button _moveLeftButton;
    private Button _moveRightButton;

    public Level Level { get { return _level; } }

    void Start()
    {
        SetupMusic(_level);
        SetupBackground(_level);
        SetupPlayerUnit(new KnightUnit());
        SetupMovementButtons();
    }
    
    void Update()
    {
    }

    public void SwitchToBattleMusic()
    {
        _normalMusicAudioSource.Stop();
        _battleMusicAudioSource.Play();
    }

    public void SwitchToNormalMusic()
    {
        _battleMusicAudioSource.Stop();
        _normalMusicAudioSource.Play();        
    }

    public void MoveBackgrounds(MovementDirection direction)
    {
        foreach (var background in _backgrounds)
        {
            background.MoveBackground(direction);
        }
    }

    public void UpdateWalkingForPlayerUnit(bool walking)
    {
        _playerUnitAnimator.SetBool("Walking", walking);
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

    private void SetupMusic(Level level)
    {
        var normalMusic = Instantiate(Resources.Load<GameObject>(level.MusicNormalResource));
        var battleMusic = Instantiate(Resources.Load<GameObject>(level.MusicBattleResource));
        _normalMusicAudioSource = normalMusic.GetComponent<AudioSource>();
        _battleMusicAudioSource = battleMusic.GetComponent<AudioSource>();
    }

    private void SetupBackground(Level level)
    {
        var bottom = Instantiate(Resources.Load<GameObject>(level.BackgroundBottomResource));
        var top = Instantiate(Resources.Load<GameObject>(level.BackgroundTopResource));
        _backgrounds = new List<Background>();
        _backgrounds.Add(bottom.GetComponent<Background>());
        _backgrounds.Add(top.GetComponent<Background>());
    }

    private void SetupPlayerUnit(Unit unit)
    {
        var playerUnit = Instantiate(Resources.Load<GameObject>(unit.Resource));
        _playerUnitAnimator = playerUnit.GetComponent<Animator>();
    }

    private void SetupMovementButtons()
    {
        _movementCanvas = Instantiate(Resources.Load<GameObject>("UI/MovementCanvas"));
        _moveLeftButton = GameObject.Find("MoveLeftButton").GetComponent<Button>();
        _moveRightButton = GameObject.Find("MoveRightButton").GetComponent<Button>();
    }
}
