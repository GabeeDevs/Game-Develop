using UnityEngine;

public class EsteiraVisual : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset = new Vector2(0, Time.time * scrollSpeed);
        rend.material.mainTextureOffset = offset;
    }
}
