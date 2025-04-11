using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioClip Sound;
    private void OnTriggerEnter2D(Collider2D collision) // Para 2D
    {
        if (collision.CompareTag("Player"))
        {
            Recolectar();
        }
    }

    private void Recolectar()
    {
        Debug.Log("Manzana recolectada!");
        Destroy(gameObject); // Elimina la manzana al recolectarla
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
