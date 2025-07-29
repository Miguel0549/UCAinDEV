using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


public class AtaquesGusano : MonoBehaviour
{
    public Transform jugador; // Objetivo principal
    public Transform[] objetivosAlternativos; // Objetivos temporales para el ataque
    public float duracionAtaque = 7f;

    public NavMeshAgent agente;
    private bool atacando = false;

    void Start()
    {
        DatosGlobales.actual = jugador;
    }

    void Update()
    {
        if (DatosGlobales.actual != null)
        {
            agente.SetDestination(DatosGlobales.actual.position);
        }

        // 🧪 TEST (borrar en producción): pulsa espacio para forzar un ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IniciarAtaque();
        }
    }

    public void IniciarAtaque()
    {
        Debug.Log("ATACANDO");
        if (!atacando && objetivosAlternativos.Length > 0)
        {
            int index = Random.Range(0, objetivosAlternativos.Length);
            Transform objetivoTemporal = objetivosAlternativos[index];
            StartCoroutine(RealizarAtaque(objetivoTemporal));
        }
    }

    IEnumerator RealizarAtaque(Transform objetivoTemporal)
    {
        atacando = true;

        DatosGlobales.actual = objetivoTemporal;
        Debug.Log("Ataque iniciado contra: " + objetivoTemporal.name);

        yield return new WaitForSeconds(duracionAtaque);

        DatosGlobales.actual = jugador;
        atacando = false;

        Debug.Log("Ataque terminado. Volviendo a jugador.");
    }
}

