using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : MonoBehaviour
{
    public int healAmount; //Cantidad de curacion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int HP = collision.gameObject.GetComponent<Health>().health;
            int maxHP = collision.gameObject.GetComponent<Health>().maxhealth;
            if (HP > maxHP) { HP = maxHP; }

            
            Destroy(gameObject);
        }
    }
}
