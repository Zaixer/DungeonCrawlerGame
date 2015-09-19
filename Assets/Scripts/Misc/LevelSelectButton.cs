using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectButton : MonoBehaviour, IPointerClickHandler
{
    public LevelSelection LevelSelection;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (LevelSelection)
        {
            case LevelSelection.Test:
                StateController.Instance.CurrentLevel = new TestLevel();
                break;
        }
        // TODO: loading overlay
        Application.LoadLevel("Level");
    }
}
