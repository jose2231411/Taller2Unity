using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health; //VIDA 
    public int maxhealth; //VIDA 
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 )
        {
            anim.SetBool("Died", true);

        }
     
    }
    void death()
    {
        Destroy(gameObject);
    }
}
