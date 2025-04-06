using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class playerMov : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;

    private float velocidade = 2f;
    private float forcaPulo = 5f;
    private float gravidade = -9.8f;  
    private float velocidadeVertical = 0f;

    private bool estaNoChao;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        estaNoChao = character.isGrounded;

        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(inputs * Time.deltaTime * velocidade);
        character.Move(Vector3.down * Time.deltaTime);

        if (!estaNoChao)
        {
            velocidadeVertical += gravidade * Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocidadeVertical = forcaPulo;
            }
            else
            {
                velocidadeVertical = -2f;
            }
            
        }

        character.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10);    
        }
        else
        {
            animator.SetBool("andando", false);
        }
        Debug.Log("Andando: " + animator.GetBool("andando"));
    }
}
