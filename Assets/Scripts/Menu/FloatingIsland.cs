using UnityEngine;

public class FloatingIsland : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float frequency = 1f;   

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, startPos.y + y, startPos.z);
    }
}