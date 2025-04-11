using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefabBala; //PREFAB DE LA BALA ENEMIGO
    public Transform shootPoint; //PUNTO DE DISPARO MODIFICAR EN EL PREFAB
    public float cooldown; //COOLDOWN DE LOS ATAQUES
    private float currCooldown;
    private bool canShoot = false;

    private Vector3 originalScale;
    private Animator anim;
    private bool facingRight = true;
    private GameObject playerObject;
    void Start()
    {
        
         playerObject = GameObject.FindGameObjectWithTag("Player");
       
        anim = GetComponent<Animator>();
        currCooldown = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerObject.transform.localScale.x < 0)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            shoot();
            
        }
        if (currCooldown < 0)
        {
            currCooldown = cooldown;
            canShoot = true;

        }
        else currCooldown -= Time.deltaTime;
        
        
    }
    void shoot() 
    {
        if (canShoot)
        {
            anim.SetTrigger("Shoot");
            Quaternion rotation = facingRight ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0); //ROTAR SI ESTA VIENDO A LA DERECHA O NO
            Instantiate(prefabBala, shootPoint.position, rotation);
            canShoot = false;
        }
    }
}
