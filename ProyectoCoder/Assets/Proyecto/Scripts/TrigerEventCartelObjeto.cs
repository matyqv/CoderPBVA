using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrigerEventCartelObjeto : MonoBehaviour
{
    public static event Action<String> Mensaje;
    public static event Action<Color,String,bool> CartelEmergente2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnviarMensaje(string Texto)
    {
        Mensaje?.Invoke(Texto);
    }

    public void _MostrarCartelInteractuar(Color C,string S, bool B)
    {
        CartelEmergente2?.Invoke(C, S,B);   
    }
}
