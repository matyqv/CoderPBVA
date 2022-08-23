using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEstamina : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]private float MP;
    [Range(10, 24)]

    [SerializeField] private int MPInicial;
    float MPInicial_;

    public Image BarraEstamina;
    public Image BarraBase;

    [Range(1, 100)]
    public float Vcarga;

    public float MP1 { get => MP; set => MP = value; }

    // Start is called before the first frame update
    void Start()
    {
        RevisarEstamina();
        MP1 = MPInicial;
        BarraEstamina.fillAmount = MP1/ 24;
    }

    // Update is called once per frame
    void Update()
    {
        CargarEstamina();
    }

    public void CargarEstamina()
    {
        if (MP1 < MPInicial)
        { MP1 += Vcarga * Time.deltaTime; }
        else
        { MP1 = MPInicial; }

        BarraEstamina.fillAmount = MP1 / 24;

        Vector3 pos = new Vector3(-220+MP1*9.1666f, 5f, 0);
        BarraEstamina.transform.localPosition = pos;
    }
    public void RestarEstamina(int _Estamina)
    {
        MP1 -= _Estamina;

        if (MP1 < 0) { MP1 = 0; }
    }
    public void RevisarEstamina()
    {
        MPInicial_ = MPInicial;
        BarraBase.fillAmount = MPInicial_ / 24;
        Vector3 pos = new Vector3(-220 + MPInicial_ * 9.1666f, 0, 0);
        BarraBase.transform.localPosition = pos;
    }
}
