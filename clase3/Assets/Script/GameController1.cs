using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController1 : MonoBehaviour
{
    
    public TextMeshProUGUI txtApple;
    GameObject key;
    GameObject[] apples;
    // Start is called before the first frame update
    void Start()
    {
         key = GameObject.FindGameObjectWithTag("Key");
         key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        showGreenApple();
        apples = GameObject.FindGameObjectsWithTag("Apple");
        if(apples.Length == 0) 
        {
            key.SetActive(true);
        }
    }
    public void showGreenApple() 
    {
       txtApple.text = GameManager.Instance.AppleGreenCount.ToString();
    }
    
    }
