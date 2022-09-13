using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CirculoAlquimia : MonoBehaviour
{
    [SerializeField] private Color Ngo;
    [SerializeField] private Color Bco;
    [SerializeField] private SpriteRenderer Circulo;
    [SerializeField] private GameObject Luz;
    [SerializeField] private GameObject Destellos;


    public static event Action<Color, String, bool> CartelCirculoInicial;
    public static event Action ActivarMeditacion;

     bool meditando=false;
    // Start is called before the first frame update
    void Start()
    {
        Ngo = Color.black + Color.red / 8 + Color.green / 20;
        Bco = Color.white;
        Fuera();
    }

    // Update is called once per frame
    void Update()
    {
        if (!meditando && Input.GetKeyDown(GameManager.Interactuar1) && Circulo.color==Bco)
        {
            ActivarMeditacion?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro();

            string T = GameManager.Interactuar1.ToString()+"";
            Debug.Log(T);

            bool B = true;
            string S = "Pulsa " + T +" Para Meditar" ;
            Color C = (Color.black + Color.white) / 2;
            CartelCirculoInicial?.Invoke(C, S, B);

            Debug.Log("Envia CartelCirculoInicial Desde " + name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fuera();

            bool B = false;
            string S = "";
            Color C = (Color.black + Color.white) / 2;
            CartelCirculoInicial?.Invoke(C, S, B);
        }
    }

    public void Dentro()
    {
        Circulo.color = Bco;
        Luz.SetActive(true);
        Destellos.SetActive(true);
    }
    public void Fuera()
    {
        Circulo.color = Ngo;
        Luz.SetActive(false);
        Destellos.SetActive(false);
    }
}
