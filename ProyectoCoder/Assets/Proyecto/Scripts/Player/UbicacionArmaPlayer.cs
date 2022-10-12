using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicacionArmaPlayer : UbicacionDeArma
{


    [SerializeField] DañoDeEspada AtK;
    // Start is called before the first frame update
    void Start()
    {
        if (R_Hand == null)
        {
            R_Hand = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0);
        }

        if (FuntaEspalda != null)
        {
            DondeEstaLaEspada = FuntaEspalda;
        }
        else { DondeEstaLaEspada = R_Hand; }
    }

    // Update is called once per frame
    void Update()
    {

        Arma.transform.position = DondeEstaLaEspada.transform.position;
        Arma.transform.rotation = DondeEstaLaEspada.transform.rotation;
    }
    public void Enfundar()
    {
        bool Mano = DondeEstaLaEspada = R_Hand;

        if (Mano)
        {
            DondeEstaLaEspada = FuntaEspalda;
            Debug.Log("Esta En Mano");
        }
    }
    public void Desenfundar()
    {
        bool funda = DondeEstaLaEspada = FuntaEspalda;

        if (funda)
        {
            DondeEstaLaEspada = R_Hand;
            Debug.Log("Esta En Funda");
        }
    }

    public void Ataque()
    {
        Desenfundar();
        AtK.ATK();

        GestorSonidos GS = transform.parent.GetComponent<GestorSonidos>();
        GS.Rep_Espada1();
    }
}
