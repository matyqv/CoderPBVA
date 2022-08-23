using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] Vector3 Movimiento;
    [SerializeField] Vector3 PosicionInicial;
    [SerializeField] Vector3 Direccion;

    public ScriptPalanca Palanca;
    // Start is called before the first frame update
    void Start()
    {
        PosicionInicial = transform.position;
        Movimiento = Direccion+PosicionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Palanca.Activado1) { Cerrar(); }
        if (!Palanca.Activado1) { Abrir(); }
    }

    void Abrir()
    {
        Vector3 Mov= Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, Movimiento);
        if (Distancia > 0.3f)
        {
            transform.Translate(Mov*Time.deltaTime);
        }
    }

    void Cerrar()
    {
        Vector3 Mov = Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, PosicionInicial);
        float DistanciaPrimaria = Vector3.Distance(Direccion, PosicionInicial);
        if (Distancia > DistanciaPrimaria/10)
        {
            transform.Translate(-Mov * 0.01f * Time.deltaTime);
        }
    }
}
