using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int appleGreenCount = 0;
   // private int goldKeyCount = 0;

    

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

    public void sumValue(int value)
    {
        appleGreenCount+=value;   
    }

    public void resetValue()
    {
        appleGreenCount = 0;
    }

    //public void sumKeyValue(int value)
    //{
    //    goldKeyCount += value;
    //}

    //public void resetKeyValue()
    //{
    //    goldKeyCount = 0;
    //}

    //public void goldKeyCollected()
    //{
    //    if ()
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex += 1);
    //    }
    //}

    public int AppleGreenCount { get => appleGreenCount; set => appleGreenCount = value; }
    //public int GoldKeyCount { get => goldKeyCount; set => goldKeyCount = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
