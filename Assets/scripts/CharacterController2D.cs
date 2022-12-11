using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed, smooth, jumpForce;
    public bool facingRight = true;
    public bool grounded;
    public Collider2D groundCheck;
    public LayerMask groundLayer;
    Animator animator;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Is the player touching the ground ?
        grounded = groundCheck.IsTouchingLayers(groundLayer);

        // Only jump if the player is grounded and has pressed the Space bar

        if (Input.GetKeyDown(KeyCode.Space) && grounded) rb2d.AddForce(new Vector2(0f, jumpForce));
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(x * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);

        animator.SetBool("running", x != 0);
        animator.SetBool("jumping", !grounded);
        if (x > 0 && !facingRight)
        {
            Flip();
        }
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            animator.SetBool("jumping", false);
            animator.SetBool("running", false);
        }
    }
    public void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
}
