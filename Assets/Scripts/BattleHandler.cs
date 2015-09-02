using UnityEngine;

public class BattleHandler : Object
{
    private readonly ContentHandler _contentHandler;
    private int _checksSinceLastRandomEncounter;
    private bool _isInBattle;

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
            var shouldTriggerBattle = _checksSinceLastRandomEncounter + Random.Range(1, 100) > 200;
            if (shouldTriggerBattle)
            {
                _checksSinceLastRandomEncounter = 0;
                _isInBattle = true;
                if (OnBattleStart != null)
                {
                    OnBattleStart(this, System.EventArgs.Empty);
                }
            }
            else
            {
                _checksSinceLastRandomEncounter++;
            }
        }
    }
}
