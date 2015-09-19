using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Instantiate(Resources.Load<GameObject>("UI/MenuBackground"));
    }
}
