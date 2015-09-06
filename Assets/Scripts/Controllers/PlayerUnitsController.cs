using UnityEngine;

public class PlayerUnitsController : MonoBehaviour
{
    public static PlayerUnitsController Instance;
    
    private Animator _playerUnitAnimator;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        var playerUnit = Instantiate(Resources.Load<GameObject>(new KnightUnit().Resource));
        _playerUnitAnimator = playerUnit.GetComponent<Animator>();
    }
    
    public void UpdateWalkingForPlayerUnit(bool walking)
    {
        _playerUnitAnimator.SetBool("Walking", walking);
    }
}
