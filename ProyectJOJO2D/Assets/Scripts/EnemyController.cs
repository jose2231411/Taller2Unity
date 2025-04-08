using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float patrolSpeed; //VELOCIDAD DE PATRULLAJE
    public float runSpeed; //VELOCIDAD DE PERSECUSION
    public float jumpForce; //ALTURA DE SALTO
    public float wait; //TIEMPO DE ESPERA EN PATRULLAJE
    public LayerMask groundLayer; //LAYER DEL SUELO
    public Transform groundCheck; //GAMEOBJECT UBICADO EN LOS PIES PARA DETECTAR COLISION CON EL SUELO MODIFICAR EN PREFAB
    public Transform obstacleCheck; //GAMEOBJECT UBICADO AL FRENTE DEL ENEMIGO PARA DETECTAR COLISION CONTRA OBSTACULOS MODIFICAR EN PREFAB
    public Transform[] patrolPoints; //LISTA DE PUNTOS DE PATRULLAJE
    public float distanceToChase; //DISTANCIA PARA PERSEGUIR AL JUGADOR
    public float shootingDistance; //DISTANCIA PARA DISPARAR
    public GameObject prefabBala; //PREFAB DE LA BALA ENEMIGO
    public Transform shootPoint; //PUNTO DE DISPARO MODIFICAR EN EL PREFAB
    public float distanceToJump; //NOTERMINADO
    public float cooldown; //COOLDOWN DE LOS ATAQUES
    private float currCooldown;
    private bool canShoot = false;
    private Vector3 originalScale; //ESCALA ORIGINAL DEL OBJETO PARA VOLTEAR EL SPRITE
    private bool chase = false;
    private Rigidbody2D rb;
    private Animator anim;
    private int currentPatrolIndex = 0; //INDICE DE LA LISTA PARA EMPEZAR A PATRULLAR
    private bool isRunning = false;
    private bool isWaiting = false;
    private bool facingRight = true;
    private Transform player; //UBICACION DEL PLAYER
    private Vector3 lockedPosition;

    void Start()
    {

        originalScale = transform.localScale;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player' en la escena.");
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chase)
        {
            Patrol();
        }
        else
        {
            chasePlayer();

        }
        anim.SetBool("IsRunning", isRunning);

        float direction = transform.localScale.x > 0 ? -1f : 1f;
        lockedPosition = player.position + new Vector3(direction * shootingDistance, 0, 0);
    }
    void Patrol()
    {

        if (patrolPoints.Length == 0 || isWaiting) return;

        Transform patrolTarget = patrolPoints[currentPatrolIndex];

        // Moverse hacia el siguiente punto
        transform.position = Vector2.MoveTowards(transform.position, patrolTarget.position, patrolSpeed * Time.deltaTime);
        isRunning = true;
        // Flip solo si cambia de dirección
        if ((patrolTarget.position.x > transform.position.x && !facingRight) ||
            (patrolTarget.position.x < transform.position.x && facingRight))
        {
            FlipSprite();
        }

        if (Vector2.Distance(transform.position, player.position) < distanceToChase)
        {
            chase = true;
            chasePlayer();
        }

        if (transform.position.y - patrolTarget.position.y > distanceToJump) 
        {

        }
        // Si llega al punto, hacer una pausa antes de continuar
        if (Vector2.Distance(transform.position, patrolTarget.position) < 0.2f)
        {
            StartCoroutine(WaitAndMove());
        }

    }

    IEnumerator WaitAndMove()
    {
        isRunning = false;
        isWaiting = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(wait); // Esperar segundos antes de continuar
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Coger el siguiente o anterior indice segun corresponda
        isWaiting = false;
    }

    void chasePlayer()
    {

        transform.position = Vector2.MoveTowards(transform.position, lockedPosition, patrolSpeed * Time.deltaTime);
        isRunning = true;


        if ((player.position.x > transform.position.x && !facingRight) ||
           (player.position.x < transform.position.x && facingRight))
        {
            FlipSprite();
        }

        // Si llega al punto, hacer una pausa antes de continuar
        if (Vector2.Distance(transform.position, lockedPosition) < 0.02f)
        {
            isRunning = false;

        }

        if (currCooldown < 0)
        {
            currCooldown = cooldown;
            canShoot = true;

        }
        else currCooldown -= Time.deltaTime;

        if (canShoot)
        {
            Quaternion rotation = facingRight ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0); //ROTAR SI ESTA VIENDO A LA DERECHA O NO
            Instantiate(prefabBala, shootPoint.position, rotation);
            canShoot = false;
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight;

        // Mantener la escala original y solo invertir en X
        transform.localScale = new Vector3(facingRight ? originalScale.x : -originalScale.x, originalScale.y, originalScale.z);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}


