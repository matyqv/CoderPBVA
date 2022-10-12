using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DetectarPlayer : MonoBehaviour
{
    [SerializeField]private Transform Player;
    [SerializeField]private GestorDeteccion PlayerDeteccion;
    [SerializeField]private int ToleranciaSonido;

    public Transform Player1 { get => Player; set => Player = value; }
    public int ToleranciaSonido1 { get => ToleranciaSonido; set => ToleranciaSonido = value; }

   public UnityEvent <bool> Alerta;

    public UnityEvent <bool> NoAlerta; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        bool P1 = other.CompareTag("Player") || other.CompareTag("Playerr");
        if (P1)
        {
            if(other.GetComponent<MovimientoPlayer>().Ruido1>ToleranciaSonido1)
            {
                Player1 = other.transform;
                Alerta?.Invoke(true);
                PlayerDeteccion.DetectorSonido(Player1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool P1 = other.CompareTag("Player") || other.CompareTag("Playerr");
        if (P1)
        {
            Player1 = null;
            NoAlerta?.Invoke(false);
            PlayerDeteccion.NoDetectorSonido();

        }

    }
}
