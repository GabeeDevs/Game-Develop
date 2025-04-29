using UnityEngine;

public class portas : MonoBehaviour
{
    public string tagDoPersonagem = "Player"; // Alterar se o personagem tiver outra tag

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagDoPersonagem)
        {
            Destroy(gameObject); // Destroi a porta
        }
    }
}