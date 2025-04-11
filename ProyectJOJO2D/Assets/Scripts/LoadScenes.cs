using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;

public class LoadScenes : MonoBehaviour
{
    public GameObject ObjectsRecollects;
    // Start is called before the first frame update
    void Start()
    {
        //ObjectsRecollects.SetActive(false);
        timer timerComponent = GetComponent<timer>();
        if (timerComponent != null)
        {
            List<float> timeList = new List<float> { timerComponent.time };
            Debug.Log("Time added: " + timerComponent.time);
        }
        else
        {
            Debug.LogError("time in this dont exist");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.Instance.AppleGreenCount >= 25 && !ObjectsRecollects.activeSelf)
        //{
        //    ObjectsRecollects.SetActive(true);
        //}
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (GameManager.Instance.AppleGreenCount == 25)
        //{

        //    //GoldKey.SetActive(true);
        //    if (collision.gameObject.GetComponent<Collider2D>().CompareTag("GoldKey"))
        //    {
        //        LoadScene("SceneGame2");
        //    }
        //}
        if (collision.gameObject.GetComponent<Collider2D>().CompareTag("GoldKey"))
        {
            LoadScene("SceneGame2");
        }

    }
}
