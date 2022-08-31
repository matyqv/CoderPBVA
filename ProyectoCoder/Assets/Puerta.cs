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
    // Start is called before the first frame update
    void Start()
    {
        PosicionInicial = transform.position;
        Movimiento = Direccion+PosicionInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Palancas[0].Activado1 && Palancas[1].Activado1)
        {
            Cerrar();
        }
        if (!Palancas[0].Activado1 && !Palancas[1].Activado1)
        {
            Abrir();
        }
    }

    void Abrir()
    {
        AudioSource AS = GetComponent<AudioSource>();
        Vector3 Mov= Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, Movimiento);
        if (Distancia > 0.5f)
        {
            transform.Translate(Mov * 0.5f * Time.deltaTime);

            if (!AS.isPlaying)
            {
                AS.Play();
            }
        }
        else
        {
            AS.Stop();
        }
    }

    void Cerrar()
    {
        AudioSource AS = GetComponent<AudioSource>();
        Vector3 Mov = Movimiento - PosicionInicial;
        float Distancia = Vector3.Distance(transform.position, PosicionInicial);
        float DistanciaPrimaria = Vector3.Distance(Direccion, PosicionInicial);
        if (Distancia > 0.5f)
        {
            transform.Translate(-Mov * 0.5f * Time.deltaTime);

            if (!AS.isPlaying)
            {
                AS.Play();
            }
        }
        else { AS.Stop(); }
    }
}
