using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorManzanas : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos; // Puntos específicos donde pueden aparecer las manzanas
    [SerializeField] private GameObject[] Manzanas;
    [SerializeField] private int cantidadManzanas = 5; // Número fijo de manzanas a generar
    private List<Transform> puntosDisponibles;

    // Start is called before the first frame update
    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);

        puntosDisponibles = puntos.ToList(); // Copia los puntos disponibles para evitar duplicados

        GenerarManzanas(); // Generar la cantidad fija de manzanas en diferentes puntos
    }

    private void GenerarManzanas()
    {
        for (int i = 0; i < cantidadManzanas; i++)
        {
            if (puntosDisponibles.Count == 0) break; // Evita errores si hay menos puntos que manzanas

            CrearManzana();
        }
    }

    private void CrearManzana()
    {
        if (puntosDisponibles.Count == 0) return;

        int indicePunto = Random.Range(0, puntosDisponibles.Count);
        Transform puntoSeleccionado = puntosDisponibles[indicePunto];

        int numeroManzanas = Random.Range(0, Manzanas.Length);
        Instantiate(Manzanas[numeroManzanas], puntoSeleccionado.position, Quaternion.identity);

        puntosDisponibles.RemoveAt(indicePunto); // Elimina el punto usado para que no se repita
    }

}