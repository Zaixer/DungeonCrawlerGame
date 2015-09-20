using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public static LevelSelectController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Instantiate(Resources.Load<GameObject>("UI/LevelSelectCanvas"));
    }
}
