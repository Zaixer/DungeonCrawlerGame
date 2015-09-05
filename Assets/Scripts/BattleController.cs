using UnityEngine;

public class BattleController : MonoBehaviour
{
    private ContentController _contentController;
    private State _currentState;
    private int _checksSinceLastRandomEncounter;
    private int _numberOfChecksBeforeNextRandomEncounter;

    public event System.EventHandler OnBattleStart;
    public event System.EventHandler OnBattleEnd;

    void Start()
    {
        _contentController = GetComponentInParent<ContentController>();
        _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
        var movementController = GetComponentInParent<MovementController>();
        movementController.OnMovement += MovementController_OnMovement;
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

    private void MovementController_OnMovement(object sender, System.EventArgs e)
    {
        CheckForRandomEncounter();
    }

    private void CheckForRandomEncounter()
    {
        _checksSinceLastRandomEncounter++;
        var shouldTriggerBattle = _checksSinceLastRandomEncounter >= _numberOfChecksBeforeNextRandomEncounter;
        if (shouldTriggerBattle)
        {
            _currentState = State.StartOfBattle;
            _checksSinceLastRandomEncounter = 0;
            _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
            _contentController.SwitchToBattleMusic();
            if (OnBattleStart != null)
            {
                OnBattleStart(this, System.EventArgs.Empty);
            }
        }
    }

    private int GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter()
    {
        return 100 + Random.Range(0, 100);
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
