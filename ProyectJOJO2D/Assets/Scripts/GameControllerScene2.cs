using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GameControllerScene2 : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro txtGreenApple2;
    public GameObject gkEY;
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("AppleTag");
        txtGreenApple2 = panel.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowGreenApple2();
        NextPhase();
    }

    public void ShowGreenApple2()
    {
        txtGreenApple2.text = GameManager.Instance.AppleGreenCount.ToString();
    }

    public void NextPhase()
    {
        if (GameManager.Instance.AppleGreenCount == 25)
        {
            gkEY.SetActive(true);
        }
    }
}
