using UnityEngine;

public class BattleController : MonoBehaviour
{
    private State _currentState;
    private int _checksSinceLastRandomEncounter;
    private int _numberOfChecksBeforeNextRandomEncounter;

    public event System.EventHandler OnBattleStart;
    public event System.EventHandler OnBattleEnd;

    void Start()
    {
        _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
        var movementController = GetComponentInParent<MovementController>();
        movementController.OnMovement += MovementController_OnMovement;
    }

    void Update()
    {
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
