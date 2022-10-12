using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicacionDeArma : MonoBehaviour
{
    public Transform R_Hand;
    public Transform FuntaEspalda;
    public Transform Arma;
    [Header("Variable Dinamica")]

    [SerializeField]
    public Transform DondeEstaLaEspada;

    // Start is called before the first frame update
    void Start()
    {
        if (R_Hand == null)
        {
            R_Hand = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0);
        }
        DondeEstaLaEspada = R_Hand;

    }

    // Update is called once per frame
    void Update()
    {
        
        Arma.transform.position = DondeEstaLaEspada.transform.position;
        Arma.transform.rotation = DondeEstaLaEspada.transform.rotation;

    }



}
