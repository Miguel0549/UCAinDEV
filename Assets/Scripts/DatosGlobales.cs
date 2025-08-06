using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;

public static class DatosGlobales
{
    public static List<NavMeshAgent> Lobos;
    
    public static Transform actual;
    
    public static List<Transform> objetivosAlternativos;

	public static Transform objetivoAlt_entrada;

	public static Transform objetivoAlt_salida;
    
    public static bool atacando = false;

	public static int cuerpos_derrotados;

	public static NavMeshAgent[] agents_partes_gusano;

	public static Transform jugador;
    
}
