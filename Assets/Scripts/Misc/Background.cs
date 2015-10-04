using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed = 0.01f;

    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void MoveBackground(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Left:
                MoveBackground(-moveSpeed);
                break;
            case MovementDirection.Right:
                MoveBackground(moveSpeed);
                break;
        }
    }

    private void MoveBackground(float xDistance)
    {
        _renderer.material.mainTextureOffset = new Vector2(_renderer.material.mainTextureOffset.x + xDistance, 0f);
    }
}
