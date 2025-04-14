using UnityEngine;

public class EsteiraEmpurradora : MonoBehaviour
{
    public Vector3 direcaoEmpurrao = new Vector3(0, 0, -5f); // direção do empurrão
    public float forca = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(direcaoEmpurrao.normalized * forca, ForceMode.Acceleration);
            }
        }
    }
}
