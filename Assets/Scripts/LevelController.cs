using UnityEngine;

public class LevelController : MonoBehaviour {
    void Start () {
        SetupBackground();
        SetupPlayerUnits();
        SetupMovementButtons();
	}

    private void SetupBackground()
    {
        var backgroundBottom = Resources.Load("Backgrounds/BackgroundBottom");
        var backgroundTop = Resources.Load("Backgrounds/BackgroundTop");
        Instantiate(backgroundBottom);
        Instantiate(backgroundTop);
    }

    private void SetupPlayerUnits()
    {
        var snail = Resources.Load("Units/Snail");
        Instantiate(snail);
    }

    private void SetupMovementButtons()
    {
        var canvas = Resources.Load("UI/MovementCanvas");
        Instantiate(canvas);
    }
}
