using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjKey : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScene loadScene = GetComponent<LoadScene>();
            loadScene.lScene(sceneName);
           
        }
    }
}
