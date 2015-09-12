using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    public Level CurrentLevel { get { return _currentLevel; } }

    private readonly Level _currentLevel = new TestLevel();
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Instantiate(Resources.Load<GameObject>("UI/MenuBackground"));
    }
}
