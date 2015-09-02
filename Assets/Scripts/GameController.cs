using UnityEngine;

public class GameController : MonoBehaviour
{
    private MovementHandler _movementHandler;
    private BattleHandler _battleHandler;

    void Start()
    {
        var level = new TestLevel();
        var playerUnit = new SnailUnit();
        var contentHandler = new ContentHandler();
        contentHandler.InitializeContent(level, playerUnit);
        _movementHandler = new MovementHandler(contentHandler, level.Length);
        _battleHandler = new BattleHandler(contentHandler);
        _movementHandler.OnMovement += _movementHandler_OnMovement;
        _battleHandler.OnBattleStart += _battleHandler_OnBattleStart;
        _battleHandler.OnBattleEnd += _battleHandler_OnBattleEnd;
    }

    void Update()
    {
        _movementHandler.PerformMovement();
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _movementHandler.ChangeMovementDirection(newMovementDirection);
    }

    private void _movementHandler_OnMovement(object sender, System.EventArgs e)
    {
        _battleHandler.CheckForRandomEncounter();
    }

    private void _battleHandler_OnBattleStart(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void _battleHandler_OnBattleEnd(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
