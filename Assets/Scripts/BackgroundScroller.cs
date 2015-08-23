using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    public float speed = 0.01f;

    private MoveStatus moveStatus = MoveStatus.None;

    public void MoveLeft()
    {
        moveStatus = MoveStatus.Left;
    }

    public void MoveRight()
    {
        moveStatus = MoveStatus.Right;

    }

    public void StopMoving()
    {
        moveStatus = MoveStatus.None;
    }

    void Update()
    {
        switch (moveStatus)
        {
            case MoveStatus.Left:
                MoveBackground(-speed);
                break;
            case MoveStatus.Right:
                MoveBackground(speed);
                break;
            default:
                break;
        }
    }

    private void MoveBackground(float xDistance)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + xDistance, 0f);
    }

    private enum MoveStatus
    {
        None,
        Left,
        Right
    }
}
