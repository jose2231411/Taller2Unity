using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject prefabGhost;
    private Rigidbody2D rigiBodyPlayer;
    private Animator AnimatorBodyPlayer;
    private bool Grounded;
    private int HP;
    private int currHP;
    private bool done = false;
    private float defaultSpeed;
    private float defaultJumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
        AnimatorBodyPlayer = GetComponent<Animator>();
        defaultSpeed = Speed;
        defaultJumpForce = JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        currHP = GetComponent<Health>().health;
        if (currHP > 0)
        {
            float moveX = Input.GetAxisRaw("Horizontal");

            // Movimiento horizontal
            rigiBodyPlayer.velocity = new Vector2(moveX * Speed, rigiBodyPlayer.velocity.y);

            // Mirar en la dirección del movimiento
            if (moveX > 0)
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            else if (moveX < 0)
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

            // Animación de correr
            AnimatorBodyPlayer.SetBool("running", moveX != 0.0f);
        }
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
        if (Input.GetKeyDown(KeyCode.W) && Grounded && currHP > 0)
        {
           
            Jump();
        }
        
        if(currHP <=0 && !done) 
        {
            done = true;
            Vector3 GhostPosition = transform.position + new Vector3(0,0.2f,0);
            Instantiate(prefabGhost, GhostPosition, transform.rotation);
            rigiBodyPlayer.velocity = Vector2.zero;
            StartCoroutine(Gameover());
            
        }
          
    }

    IEnumerator debuff(float time)
    {

        yield return new WaitForSeconds(time); // Esperar segundos antes de continuar
        Speed = defaultSpeed;
        JumpForce = defaultJumpForce;
    }
    IEnumerator Gameover()
    {
        
        yield return new WaitForSeconds(3f); // Esperar segundos antes de continuar
        SceneManager.LoadScene("SceneMenu");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) 
        {
            AnimatorBodyPlayer.SetBool("harmed", true);
            return;
            
        }
        if (collision.CompareTag("SpeedBuff"))
        {
            SpeedBuff col = collision.gameObject.GetComponent<SpeedBuff>();
            Speed += col.buff;
            StartCoroutine(debuff(col.buffTime));
            Destroy(collision.gameObject);
            return;
        }
        if (collision.CompareTag("JumpBuff"))
        {
            JumpBuff col = collision.gameObject.GetComponent<JumpBuff>();
            JumpForce += col.buff;
            StartCoroutine(debuff(col.buffTime));
            Destroy(collision.gameObject);
           return;
        }
    }
    public void resetharm() 
    {
        AnimatorBodyPlayer.SetBool("harmed", false);
    }
    private void Jump()
    {

        rigiBodyPlayer.AddForce(Vector2.up * JumpForce);
    }


    
}
