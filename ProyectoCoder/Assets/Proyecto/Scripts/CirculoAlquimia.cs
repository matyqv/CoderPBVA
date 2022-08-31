using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculoAlquimia : MonoBehaviour
{
    [SerializeField] private Color Ngo;
    [SerializeField] private Color Bco;
    [SerializeField] private SpriteRenderer Circulo;
    [SerializeField] private GameObject Luz;
    [SerializeField] private GameObject Destellos;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dentro();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fuera();
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
