using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float horizontal;
    private Rigidbody2D rigidbody;
    public float jumpForce;
    public LayerMask groundLayer;
    public Transform groundCheck;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal,rigidbody.velocity.y);
        if (horizontal > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
