using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce = 100f;

    private Rigidbody2D rbody;
    private bool isGrounded = false;
    private Animator anim;
    private bool isFacingRight = true;


  

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();
        //jump code 

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rbody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rbody.velocity = new Vector2(horiz * speed, rbody.velocity.y);

        //check if the sprite needs to be fliped
        if ((isFacingRight && rbody.velocity.x < 0) || (!isFacingRight && rbody.velocity.x > 0))
        {
            Flip();
        }
        
        // com with animator

        anim.SetFloat("xVelocity", Mathf.Abs(rbody.velocity.x));
        anim.SetFloat("yVelocity", rbody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);

        
        
    }
    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        /*
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;*/

        isFacingRight = !isFacingRight;
    }
    
}