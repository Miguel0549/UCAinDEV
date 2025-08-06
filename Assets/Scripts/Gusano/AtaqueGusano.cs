using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AtaqueGusano : MonoBehaviour
{
    private SpriteRenderer sprite;
    private NavMeshAgent agent;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        agent.speed = 3.5f;
    }

    void FixedUpdate()
    {
        if (DatosGlobales.atacando)
        {
            agent.speed = 5.5f;
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            agent.stoppingDistance = 0f;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == DatosGlobales.objetivoAlt_entrada.gameObject.name)
        {
            if (DatosGlobales.atacando)
            {
                sprite.enabled = false;
                agent.enabled = false;
                
                
                if (this.gameObject.gameObject.name == "Cola")
                {
                    foreach (NavMeshAgent a in DatosGlobales.agents_partes_gusano)
                    {
                        a.Warp(DatosGlobales.objetivoAlt_salida.position);
                        a.enabled = true;
                        DatosGlobales.actual = DatosGlobales.jugador;
                    }
                    
                }
                
            }
            
        }
        
    }

    IEnumerator velocidad_ataque()
    {
        yield return new WaitForSeconds(1.5f);
        agent.speed = 3.5f;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == DatosGlobales.objetivoAlt_salida.gameObject.name)
        {
            sprite.enabled = true;
            if (this.gameObject.gameObject.name == "Cola")
            {
                DatosGlobales.atacando = false;
            }
            
            if (this.gameObject.gameObject.name == "Cabeza")
            {
                StartCoroutine(velocidad_ataque());
            }
            
        }
      
    }
    
}
