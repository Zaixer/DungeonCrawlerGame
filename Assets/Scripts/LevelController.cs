using UnityEngine;

public class LevelController : MonoBehaviour {
    void Start () {
        SetupBackground();
	}

    private void SetupBackground()
    {
        var backgroundBottomQuad = Resources.Load("Backgrounds/BackgroundBottomQuad");
        var backgroundTopQuad = Resources.Load("Backgrounds/BackgroundTopQuad");
        Instantiate(backgroundBottomQuad);
        Instantiate(backgroundTopQuad);
    }
}
