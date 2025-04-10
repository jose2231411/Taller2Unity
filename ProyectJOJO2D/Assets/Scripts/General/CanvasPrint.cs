using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPrint : MonoBehaviour
{
    private CanvasPrint Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}