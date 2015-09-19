using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public static BackgroundController Instance;

    private ICollection<Background> _backgrounds;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        var bottom = Instantiate(Resources.Load<GameObject>(StateController.Instance.CurrentLevel.BackgroundBottomResource));
        var top = Instantiate(Resources.Load<GameObject>(StateController.Instance.CurrentLevel.BackgroundTopResource));
        _backgrounds = new List<Background>();
        _backgrounds.Add(bottom.GetComponent<Background>());
        _backgrounds.Add(top.GetComponent<Background>());
    }

    public void MoveBackgrounds(MovementDirection direction)
    {
        foreach (var background in _backgrounds)
        {
            background.MoveBackground(direction);
        }
    }
}
