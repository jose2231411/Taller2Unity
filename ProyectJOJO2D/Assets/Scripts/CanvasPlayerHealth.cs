using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ¡Ojo! No es UIElements sino UI

public class CanvasPlayerHealth : MonoBehaviour
{
    public List<Image> hearts; // Lista de corazones en el canvas
    public Sprite fullHeart;   // Sprite para corazón lleno
    public Sprite emptyHeart;  // Sprite para corazón vacío

    private GameObject player;
    private Health playerHealth;
    private int maxHP;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
         maxHP = playerHealth.maxhealth;
    }

    void Update()
    {
        int currentHP = playerHealth.health;
        

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
