using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerMenu : MonoBehaviour
{
    public GameObject sonidoSI;
    public GameObject sonidoNo;
    public GameObject logros;
    public GameObject intruciiones;
    public GameObject salir;

    // Start is called before the first frame update
    void Start()
    {
       activarinstrucciones();  

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarinstrucciones()
    {
       intruciiones.SetActive(true);

    }
}
