using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Botones de Audio")]
    public GameObject botonSilenciar;   // Bot�n para silenciar (�cono de volumen activo)
    public GameObject botonActivar;     // Bot�n para activar (�cono de volumen apagado)

    [Header("Audio")]
    public AudioSource musica;          // Audio que se controla

    private bool isMuted = false;

    void Start()
    {
        // Cargar el estado guardado
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;

        // Aplicar el estado inicial
        AplicarEstadoAudio();
    }

    // M�todo que se llama desde el bot�n "Silenciar"
    public void SilenciarAudio()
    {
        isMuted = true;
        PlayerPrefs.SetInt("Muted", 1);
        AplicarEstadoAudio();
    }

    // M�todo que se llama desde el bot�n "Activar"
    public void ActivarAudio()
    {
        isMuted = false;
        PlayerPrefs.SetInt("Muted", 0);
        AplicarEstadoAudio();
    }

    // Aplica el estado actual al audio y a los botones
    private void AplicarEstadoAudio()
    {
        if (musica != null)
            musica.mute = isMuted;

        // Mostrar solo el bot�n correcto
        if (botonSilenciar != null)
            botonSilenciar.SetActive(!isMuted);  // Mostrar "Silenciar" si audio est� activo

        if (botonActivar != null)
            botonActivar.SetActive(isMuted);     // Mostrar "Activar" si audio est� silenciado

        Debug.Log("Audio: " + (isMuted ? "Silenciado" : "Activado"));
    }

    public void Salir()
    {
        Application.Quit();
    }
}
