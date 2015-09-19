using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public static LevelSelectController Instance;

    void Awake()
    {
        Instance = this;
    }

    // TODO: prefabs
}
