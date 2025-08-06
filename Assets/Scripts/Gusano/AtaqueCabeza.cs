using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class AtaqueCabeza : MonoBehaviour
{
    public Transform jugador; // Objetivo principal
    private NavMeshAgent agente;

    public GameObject gusano;
    

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        DatosGlobales.jugador = DatosGlobales.actual = jugador;
        
        DatosGlobales.objetivosAlternativos = GameObject.FindGameObjectsWithTag("Agujero")
            .Select(go => go.transform)
            .ToList();
        
        DatosGlobales.agents_partes_gusano = gusano.GetComponentsInChildren<NavMeshAgent>();
        
    }

    void Update()
    {
        if (DatosGlobales.actual != null)
        {
            agente.SetDestination(DatosGlobales.actual.position);
        }

        Debug.Log("Objetivo: " + DatosGlobales.actual.gameObject.name);

        if (DatosGlobales.cuerpos_derrotados >= 2 && !DatosGlobales.atacando)
        {
            StartCoroutine(Funcion_Ataque());
        }
    }

    public void IniciarAtaque()
    {
        
        if (!DatosGlobales.atacando && DatosGlobales.objetivosAlternativos.Count > 0)
        {
            int index_1 = Random.Range(0, DatosGlobales.objetivosAlternativos.Count);
            DatosGlobales.objetivoAlt_entrada = DatosGlobales.objetivosAlternativos[index_1];
            DatosGlobales.actual = DatosGlobales.objetivoAlt_entrada;

            int index_2;
            
            do
            {
                index_2 = Random.Range(0, DatosGlobales.objetivosAlternativos.Count);

            } while (index_1 == index_2);
            
            DatosGlobales.objetivoAlt_salida = DatosGlobales.objetivosAlternativos[index_2];
            
            DatosGlobales.atacando = true;
            
        }
        
        
    }
    
    IEnumerator Funcion_Ataque()
    {
        int SegundosEspera = Random.Range(9, 14);
            
        yield return new WaitForSeconds(SegundosEspera);
            
        IniciarAtaque();
        
    }
    
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == DatosGlobales.objetivoAlt_salida.gameObject.name)
        {
           
            foreach (NavMeshAgent agente in DatosGlobales.agents_partes_gusano)
            {
                if (agente.gameObject.name == "Cola") 
                {
                    agente.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                    agente.stoppingDistance = 1.3f;
                }
                
            }
            

        }
      
        
    }
    
    
    
}

