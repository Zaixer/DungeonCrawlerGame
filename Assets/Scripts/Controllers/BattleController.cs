using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController Instance;

    private State _currentState;
    private int _checksSinceLastRandomEncounter;
    private int _numberOfChecksBeforeNextRandomEncounter;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
    }

    void Update()
    {
        switch (_currentState)
        {
            case State.OutsideBattle:
                break;
            case State.StartOfBattle:
                break;
            case State.PlayerTurn:
                break;
            case State.EnemyTurn:
                break;
            case State.EndOfBattle:
                break;
        }
    }

    public void CheckForRandomEncounter()
    {
        _checksSinceLastRandomEncounter++;
        var shouldTriggerBattle = _checksSinceLastRandomEncounter >= _numberOfChecksBeforeNextRandomEncounter;
        if (shouldTriggerBattle)
        {
            _currentState = State.StartOfBattle;
            _checksSinceLastRandomEncounter = 0;
            _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
            SoundController.Instance.SwitchToBattleMusic();
            MovementController.Instance.DisableMovement();
            EnemyUnitsController.Instance.DropInNewEnemyUnit();
        }
    }

    private int GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter()
    {
        return 200 + Random.Range(0, 200);
    }

    private enum State
    {
        OutsideBattle,
        StartOfBattle,
        PlayerTurn,
        EnemyTurn,
        EndOfBattle
    }
}
