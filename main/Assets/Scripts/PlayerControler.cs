using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode shoot;


    private Rigidbody2D rb;

    private float horizontal;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;

    public bool isGrounded;

    private Animator anim;


    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        horizontal = Input.GetAxis("Horizontal");

    }

    // Update is called once per 0.02s
    void fixedUpdate()
    {

   


        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(up) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  
        }

        anim.SetFloat("Speed", rb.velocity.x);
        anim.SetBool("Grounded", isGrounded);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, groundCheckLayerMask);
    }
}
    