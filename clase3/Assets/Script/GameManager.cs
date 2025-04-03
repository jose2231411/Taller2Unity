using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject applePrefab;
    private int appleGreenCount = 0;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);
        if (!scene.name.Equals("Menu"))
        {
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            List<int> availableIndices = new List<int>();

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                availableIndices.Add(i);
            }

            int spawnCount = Mathf.Min(5, spawnPoints.Length);
            for (int i = 0; i < spawnCount; i++)
            {
                int randomIndex = Random.Range(0, availableIndices.Count);
                int selectedIndex = availableIndices[randomIndex];
                availableIndices.RemoveAt(randomIndex);

                GameObject obj = Instantiate(applePrefab, spawnPoints[selectedIndex].transform.position, applePrefab.transform.rotation);
            }
        }
    }

    public void sumValue(int value) 
    {
        appleGreenCount+= value;
    }

    public void resetVal()
    {
        appleGreenCount = 0;
    }

    public int AppleGreenCount { get => appleGreenCount; set => appleGreenCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
