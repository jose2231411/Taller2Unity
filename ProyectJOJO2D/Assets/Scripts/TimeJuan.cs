using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI timetext;
    public float time = 0;





    void Update()
    {
        time += Time.deltaTime;
        timetext.text = time.ToString("F0");
    }


}