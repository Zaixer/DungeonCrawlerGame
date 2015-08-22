using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject background;
    public GameObject unit;
    public GameObject buttonWalkLeft;
    public GameObject buttonWalkRight;

    void Start () {
        Instantiate(background, ScreenPositionHelper.GetFromPixels(0, 150), Quaternion.identity);
        Instantiate(unit, ScreenPositionHelper.GetFromPixels(-300, 50), Quaternion.identity);
        Instantiate(buttonWalkLeft);
        Instantiate(buttonWalkRight);
    }
}
