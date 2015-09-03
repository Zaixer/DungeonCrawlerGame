using UnityEngine;

public class BattleHandler : Object
{
    private readonly ContentHandler _contentHandler;
    private bool _isInBattle;
    private int _checksSinceLastRandomEncounter;
    private int _numberOfChecksBeforeNextRandomEncounter;

    public event System.EventHandler OnBattleStart;
    public event System.EventHandler OnBattleEnd;
    
    public BattleHandler(ContentHandler contentHandler)
    {
        _contentHandler = contentHandler;
    }

    public void CheckForRandomEncounter()
    {
        Debug.Log(_checksSinceLastRandomEncounter);
        if (!_isInBattle)
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
                _isInBattle = true;
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
}
