using UnityEngine;

public class HorizontalParallax : MonoBehaviour
{
    public float speed = 0.5f;
    public float resetPositionX = 20f; // Quando reiniciar a posição
    public float startPositionX = -20f; // Posição inicial ao resetar

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (transform.position.x > resetPositionX)
        {
            Vector3 pos = transform.position;
            pos.x = startPositionX;
            transform.position = pos;
        }
    }
}
