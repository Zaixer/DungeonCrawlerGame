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
            case State.PlayerChoice:
                break;
            case State.PlayerAnimation:
                break;
            case State.EnemyChoice:
                break;
            case State.EnemyAnimation:
                break;
            case State.EndOfBattle:
                EndBattle();
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
            SoundController.Instance.SwitchToBattleMusic();
            MovementController.Instance.DisableMovement();
            EnemyUnitsController.Instance.StartDropInOfNewEnemyUnit();
        }
    }

    private void EndBattle()
    {
        _currentState = State.OutsideBattle;
        _checksSinceLastRandomEncounter = 0;
        _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
        SoundController.Instance.SwitchToNormalMusic();
        MovementController.Instance.EnableMovement();
    }

    private int GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter()
    {
        return 200 + Random.Range(0, 200);
    }

    private enum State
    {
        OutsideBattle,
        StartOfBattle,
        PlayerChoice,
        PlayerAnimation,
        EnemyChoice,
        EnemyAnimation,
        EndOfBattle
    }
}
