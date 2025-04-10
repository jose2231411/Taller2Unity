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
    public int damage;
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
        GameObject col = collision.gameObject;
        Health hp = col.GetComponent<Health>();
        hp.health -= damage;
        Destroy(gameObject);
    }
}