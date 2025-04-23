using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCamera;
    public Animator animator;

    bool estaAndando;

    private bool estaNoChao;
    [SerializeField] private Transform peDoPersonagem;
    [SerializeField] private LayerMask colisaoLayer;

    private float forcaY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = myCamera.TransformDirection(movimento);
        movimento.y = 0;

        controller.Move(movimento * Time.deltaTime * 5);

        // Verifica se está andando (usando magnitude para maior precisão)
        bool estaAndando = movimento.magnitude > 0.1f;

        if (estaAndando)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }

        // Atualiza o parâmetro "andando" no Animator
        if (animator != null)
        {
            animator.SetBool("andando", estaAndando);
        }

        estaNoChao = Physics.CheckSphere(peDoPersonagem.position, 0.3f, colisaoLayer);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            forcaY = 5;
        }

        if (forcaY > -9.81f)
        {
            forcaY += -9.81f * Time.deltaTime;
        }

        controller.Move(new Vector3(0, forcaY, 0) * Time.deltaTime);
    }
}
