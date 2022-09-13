using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudPlayer : MonoBehaviour
{
    public TextMeshProUGUI Exp;
    [SerializeField] GameObject CartelEmergente;
    [SerializeField] GameObject CartelEmergente2;
    [SerializeField] GameObject MeditacionInterface;

    [Header("Botones Configuracion")]

    [SerializeField] TextMeshProUGUI Button_Att;
    [SerializeField] TextMeshProUGUI Button_Pocion;
    [SerializeField] TextMeshProUGUI NroPociones;


    // Start is called before the first frame update
    void Awake()
    {
        PublicPuertaCerrojo.CartelEmergente += DatosDeCartel;
        CirculoAlquimia.CartelCirculoInicial += DatosDeCartel;
        CirculoAlquimia.ActivarMeditacion += ActivarMeditacion;
        PlayerKeys.Pociones+= ModificarPociones;

    }

    public void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Exp.text = GameManager.exp+"";
        Button_Att.text = "" + GameManager.Attack1;
        Button_Pocion.text = "" + GameManager.Pocion1;
    }

    public void DatosDeCartel(Color C, string S, bool B)
    {

        Debug.Log("recibe PublicPuertaCerrojo.CartelEmergente En " + name);

        CartelEmergente.
            GetComponent<Image>().color = C;
        CartelEmergente.transform.GetChild(0).
            GetComponent<TextMeshProUGUI>().text = S;
        CartelEmergente.SetActive(B);
    }

    public void DatosDeCartel2(Color C, string S, bool B)
    {
        Debug.Log("recibe CirculoAlquimia.CartelCirculoInicial " + name);

        CartelEmergente.
            GetComponent<Image>().color = C;
        CartelEmergente.transform.GetChild(0).
            GetComponent<TextMeshProUGUI>().text = S;
        CartelEmergente.SetActive(B);
    }

    private void OnDisable()
    {
        PublicPuertaCerrojo.CartelEmergente -= DatosDeCartel;
        CirculoAlquimia.CartelCirculoInicial-= DatosDeCartel;
        CirculoAlquimia.ActivarMeditacion -= ActivarMeditacion;
        PlayerKeys.Pociones -= ModificarPociones;
    }

    void ActivarMeditacion()
    { MeditacionInterface.SetActive(true);
        Debug.Log("recibe CirculoAlquimia.ActivarMeditacion " + name);
    }

    void ModificarPociones(int I)
    {

        Button_Att.text = "" + GameManager.Attack1;
        Button_Pocion.text = "" + GameManager.Pocion1;
        NroPociones.text = I.ToString();
    }
}
