using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorVida : MonoBehaviour
{

    public Transform CabezaReflector;
    public Transform Target;
    public Transform rutinaInicioTransform;

    public Transform []Posiciones;
    int WayPoint;
    public float Speed;
    bool PuedeCambiar=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        Vector3 NewPosition = Posiciones[WayPoint].position;
        float Distancia = Vector3.Distance(Target.position, NewPosition);

        if (Distancia <= 0.1f)
        {

            if (WayPoint < Posiciones.Length - 1 && PuedeCambiar)
            {
                WayPoint++;
                PuedeCambiar = false;
                Invoke("CambioHabilitado", 20 * Time.deltaTime);
            }

            if (WayPoint == Posiciones.Length-1 && PuedeCambiar)
            {
                WayPoint = 0;
                PuedeCambiar = false;
                Invoke("CambioHabilitado", 20 * Time.deltaTime);
            }
        }
        if (Distancia > 0.1f)
        {
            Target.position += (Target.forward * Speed * Time.deltaTime);
            Target.LookAt(NewPosition);
        }
        CabezaReflector.LookAt(Target);
    }

    void CambioHabilitado()
    {
        PuedeCambiar = true;
    }

}
