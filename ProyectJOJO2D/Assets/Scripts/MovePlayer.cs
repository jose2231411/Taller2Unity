using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    
    private Rigidbody2D rigiBodyPlayer;
    private Animator AnimatorBodyPlayer;
    private float horizontal;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
        AnimatorBodyPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            AnimatorBodyPlayer.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
            AnimatorBodyPlayer.SetBool("grounded", Grounded);
        }
        else
        {
            Grounded = false;
            AnimatorBodyPlayer.SetBool("grounded", Grounded);
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
           
            Jump();
        }
        
    }

    private void Jump()
    {

        rigiBodyPlayer.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        rigiBodyPlayer.velocity = new Vector2(horizontal, rigiBodyPlayer.velocity.y);
    }
    
}
