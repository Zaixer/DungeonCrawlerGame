using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject background;
    public GameObject unit;

    private const float SCREEN_WIDTH = 8f;
    private const float SCREEN_HEIGHT = 6f;
    private const float BACKGROUND_Y_POSITION = SCREEN_HEIGHT / 4f;
    private const float UNIT_Y_POSITION = 0.5f;

    void Start () {
        Instantiate(background, new Vector3(0, BACKGROUND_Y_POSITION), Quaternion.identity);
        Instantiate(unit, new Vector3(-3f, UNIT_Y_POSITION), Quaternion.identity);
    }
}
