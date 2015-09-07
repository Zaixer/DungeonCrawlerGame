using UnityEngine;

public class EnemyUnitsController : MonoBehaviour
{
    public static EnemyUnitsController Instance;

    private const float START_X_POSITION = 2f;
    private const float START_Y_POSITION = 2.4f;
    private const float TARGET_Y_POSITION = 0.7f;
    private const float DROP_SPEED = 0.05f;
    private State _currentState;
    private GameObject _enemyUnit;
    private Transform _enemyUnitTransform;

    void Awake()
    {
        Instance = this;
    }
    
    void Update()
    {
        if (_currentState == State.DroppingInEnemyUnit)
        {
            if (_enemyUnitTransform.position.y <= TARGET_Y_POSITION)
            {
                _currentState = State.None;
            }
            else
            {
                _enemyUnitTransform.position = new Vector3(_enemyUnitTransform.position.x, _enemyUnitTransform.position.y - DROP_SPEED);
            }
        }
    }

    public void DropInNewEnemyUnit()
    {
        _enemyUnit = (GameObject)Instantiate(Resources.Load(new RabbitUnit().Resource), new Vector3(START_X_POSITION, START_Y_POSITION), Quaternion.identity);
        _enemyUnitTransform = _enemyUnit.transform;
        _currentState = State.DroppingInEnemyUnit;
    }

    private enum State
    {
        None,
        DroppingInEnemyUnit
    }
}
