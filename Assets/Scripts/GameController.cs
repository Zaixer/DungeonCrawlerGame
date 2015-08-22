using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject background;
    public GameObject unit;

    void Start () {
        Instantiate(background, ScreenPositionHelper.GetFromPixels(0, 150), Quaternion.identity);
        Instantiate(unit, ScreenPositionHelper.GetFromPixels(-300, 50), Quaternion.identity);
    }
}
