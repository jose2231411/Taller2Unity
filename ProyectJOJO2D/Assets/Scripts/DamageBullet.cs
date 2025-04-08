using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float bullspeed = 0.7f; //VELOCIDAD DE BALA
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * bullspeed;
    }

    private void animFinished() 
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si colisionó con el jugador
        {
            Debug.Log("Colision");
            Destroy(gameObject);
        }
    }
}