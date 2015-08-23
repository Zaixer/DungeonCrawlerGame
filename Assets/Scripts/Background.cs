using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveDistance = 0.01f;

    private Renderer _renderer;

    public void MoveBackground()
    {
        _renderer.material.mainTextureOffset = new Vector2(_renderer.material.mainTextureOffset.x + moveDistance, 0f);
    }

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
}
