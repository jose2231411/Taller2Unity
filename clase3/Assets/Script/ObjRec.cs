using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRec : MonoBehaviour
{


    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.sumValue(1);
            Destroy(gameObject);
        }
    }
}
