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
    
    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;

    public bool isGrounded;

    private Animator anim;

    public GameObject projectile;
    public Transform shootPoint;

    public Vector3 cursor;


    // Start is called before the first frame update
    void Start(){
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        cursor = Input.mousePosition;

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundCheckLayerMask);
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2 (0, theRB.velocity.y);
        }
        if (Input.GetKeyDown(up) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(shoot))
        {
            GameObject ballClone = (GameObject)Instantiate(projectile,shootPoint.position,shootPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Shoot");
        }

        anim.SetFloat("Speed",Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
}
    