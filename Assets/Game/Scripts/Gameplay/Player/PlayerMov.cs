using System.Security.Cryptography.X509Certificates;
using UnityEditor.Rendering;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public LayerMask ground;

    public float speed, maxSpeed, drag;
    public float rotationSpeed, jumpForce;

    bool left, forward, right, backward;
    bool grounded, jump;

    public float crouchingSpeed;
    bool crouch, crouching;
    float originalSpeed;


    private void Start()
    {
        originalSpeed = speed;
    }


    // Update is called once per frame
    void Update()
    {
        HandleInput();
        LimitVelocity();
        HandleDrag();
        HandleRotation();
        CheckGrounded();

    }

    void HandleRotation()
    {
        if ((new Vector2(rb.velocity.x, rb.velocity.z)).magnitude > .1f)
        {
            Vector3 horizontalDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            Quaternion rotation = Quaternion.LookRotation(horizontalDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    void FixedUpdate()
    {
        HandleMovement();

    }

    void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position + Vector3.up * .1f, Vector3.down, 2f, ground);
    }

    void LimitVelocity()
    {
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    void HandleDrag()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z) / (1 + drag / 100) + new Vector3(0, rb.velocity.y, 0);
    }


    void HandleMovement()
    {

        Quaternion dir = Quaternion.Euler(0f, cam.rotation.eulerAngles.y, 0f);

        if (left)
        {
            rb.AddForce(dir * Vector3.left * speed);
            left = false;
        }
        if (forward)
        {
            rb.AddForce(dir * Vector3.forward * speed);
            forward = false;
        }
        if (backward)
        {
            rb.AddForce(dir * Vector3.back * speed);
            backward = false;
        }
        if (right)
        {
            rb.AddForce(dir * Vector3.right * speed);
            right = false;
        }
        if (jump && grounded)
        {
            transform.position += Vector3.up * .1f;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.y);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }

        if (crouch && !crouching)
        {
            speed = crouchingSpeed;
            transform.localScale -= new Vector3(0, .5f, 0);
            crouch = false;
            crouching = true;
        }
        if (crouching && !crouch)
        {
            speed = originalSpeed;
            transform.localScale += new Vector3(0, .5f, 0);
            crouch = false;
            crouching = false;
        }

    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
            left = true;
        if (Input.GetKey(KeyCode.D))
            right = true;
        if (Input.GetKey(KeyCode.S))
            backward = true;
        if (Input.GetKey(KeyCode.W))
            forward = true;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            jump = true;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch = true;
    }
}
