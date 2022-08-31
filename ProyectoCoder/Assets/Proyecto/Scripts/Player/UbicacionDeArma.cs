using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicacionDeArma : MonoBehaviour
{
    public Transform R_Hand;
    public Transform Arma;
    [SerializeField] DañoDeEspada AtK;
    // Start is called before the first frame update
    void Start()
    {
        if (R_Hand == null)
        {
            R_Hand = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Arma.transform.position = R_Hand.transform.position;
        Arma.transform.rotation = R_Hand.transform.rotation;
    }

    public void Ataque()
    {
        AtK.ATK();

        GestorSonidos GS = transform.parent.GetComponent<GestorSonidos>();
        GS.Rep_Espada1();
    }
}
