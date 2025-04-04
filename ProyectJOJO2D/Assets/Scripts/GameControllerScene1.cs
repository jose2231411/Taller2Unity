using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerScene1 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtGreenApple;
    private ObjectRecollected goldKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowGreenApple();
        NextPhase();
    }

    public void ShowGreenApple()
    {
        txtGreenApple.text = GameManager.Instance.AppleGreenCount.ToString();
    }

    public void NextPhase()
    {
        if (GameManager.Instance.AppleGreenCount==25)
        {
            
        }
    }
}
