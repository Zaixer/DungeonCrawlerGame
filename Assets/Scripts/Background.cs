using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed = 0.01f;

    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void MoveBackgroundLeft()
    {
        MoveBackground(-moveSpeed);
    }

    public void MoveBackgroundRight()
    {
        MoveBackground(moveSpeed);
    }

    private void MoveBackground(float xDistance)
    {
        _renderer.material.mainTextureOffset = new Vector2(_renderer.material.mainTextureOffset.x + xDistance, 0f);
    }
}
