using UnityEngine;

public class BattleHandler : Object
{
    private readonly ContentHandler _contentHandler;
    private int _checksSinceLastRandomEncounter;
    private int _numberOfChecksBeforeNextRandomEncounter;
    private State _currentState;

    public event System.EventHandler OnBattleStart;
    public event System.EventHandler OnBattleEnd;
    
    public BattleHandler(ContentHandler contentHandler)
    {
        _contentHandler = contentHandler;
    }

    public void CheckForRandomEncounter()
    {
        if (_currentState == State.OutsideBattle)
        {
            _checksSinceLastRandomEncounter++;
            if (_numberOfChecksBeforeNextRandomEncounter == 0)
            {
                _numberOfChecksBeforeNextRandomEncounter = GetNewRandomNumberForNumberOfChecksBeforeNextRandomEncounter();
            }
            var shouldTriggerBattle = _checksSinceLastRandomEncounter >= _numberOfChecksBeforeNextRandomEncounter;
            if (shouldTriggerBattle)
            {
                _checksSinceLastRandomEncounter = 0;
                _numberOfChecksBeforeNextRandomEncounter = 0;
                _currentState = State.StartOfBattle;
                if (OnBattleStart != null)
                {
                    OnBattleStart(this, System.EventArgs.Empty);
                }
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
