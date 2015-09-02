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
    }

    void Update()
    {
        _movementHandler.PerformMovement();
    }

    public void ChangeMovementDirection(MovementDirection newMovementDirection)
    {
        _movementHandler.ChangeMovementDirection(newMovementDirection);
    }
}
