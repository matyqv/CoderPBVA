using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] Vector3 Movimiento;
    [SerializeField] Vector3 PosicionInicial;
    [SerializeField] Vector3 Direccion;

    public ScriptPalanca Palanca;
    public ScriptPalanca[] Palancas;

    public AudioClip PuertaClip;

    [SerializeField] int Cantidad;
    [SerializeField] int CantidadNecesaria;
    // Start is called before the first frame update
    void Start()
    {
        PosicionInicial = transform.position;
        Movimiento = Direccion+PosicionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cantidad == CantidadNecesaria)
        {
            Abrir();
        }
        if (Cantidad != CantidadNecesaria)
        {
            Cerrar();
        }
    }

    void Abrir()
    {
        Vector3 Mov= Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, Movimiento);
        if (Distancia > 0.5f)
        {
            transform.Translate(Mov * 0.5f * Time.deltaTime);          
        }
    }

    void Cerrar()
    {
        Vector3 Mov = Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, PosicionInicial);
        float DistanciaPrimaria = Vector3.Distance(Direccion, PosicionInicial);
        if (Distancia > 0.5f)
        {
            transform.Translate(-Mov * 0.5f * Time.deltaTime);
        }
    }

    void dispararSonido()
    {
        AudioSource AS = GameManager.AS1;
        AS.PlayOneShot(PuertaClip,.6f);
    }

    public void SumarClave(int N)
    {
        Cantidad += N;
        if (Cantidad == CantidadNecesaria) { dispararSonido(); }
        if (Cantidad == 0) { dispararSonido(); }
        Debug.Log(name+" Recibio la señal");
    }
}
