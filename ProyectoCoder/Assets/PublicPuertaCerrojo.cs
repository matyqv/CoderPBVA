using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PublicPuertaCerrojo : MonoBehaviour
{
    [SerializeField] GameObject Cerrojo;
    [SerializeField] Transform puertaA;
    [SerializeField] Transform puertaB;
    [SerializeField] string LlaveRequerida;
    [SerializeField] bool Abierta;
    [SerializeField] TextMeshProUGUI Texto;
    [SerializeField] AudioClip SonidoPuerta;

    public static event Action <Color,String,bool>CartelEmergente;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKey(GameManager.Interactuar1) && Abierta) { StartCoroutine(Abrir()); }
    }

    IEnumerator Abrir()
    {
        Abierta = false;
        for (float i = 1; i > 0.01f; i-=0.03f)
        {
            Vector3 V = new Vector3(i, i, i);
            Cerrojo.transform.localScale = V;          
            yield return new WaitForEndOfFrame();
        }
        yield return null;

        GameManager.AS1.PlayOneShot(SonidoPuerta);
        for (int i = 90; i > 0; i--)
        {
            Vector3 V = new Vector3(0, 0, i);
            GetComponent<BoxCollider>().enabled = false;
            puertaA.localEulerAngles = V;            
            puertaB.localEulerAngles = V;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
        Destroy(Cerrojo);

        Color C = (Color.red + Color.white) / 2.4f;
        bool B = false;
        string S = "Debe Cerrarse ";
        CartelEmergente?.Invoke(C, S, B);

        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (other.GetComponent<PlayerKeys>().Keys_.ContainsKey(LlaveRequerida))
            {
                Abierta = true;

                Color C= (Color.green + Color.white) / 2.4f;
                bool B = true;
                string S = "Presiona La Tecla ["+GameManager.Interactuar1+"]";
                CartelEmergente?.Invoke(C, S, B);
                Debug.Log("Envia CartelEmergente desde " + name);

            }
            else
            {
                Color C = (Color.red + Color.white*1.2f) / 2.4f;
                bool B = true;
                string S = "No tienes La Llave Necesaria ";
                CartelEmergente?.Invoke(C, S, B);
                Debug.Log("Envia CartelEmergente desde " + name);
            }
        }
   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Color C = (Color.red + Color.white) / 2.4f;
            bool B = false;
            string S = "Debe Cerrarse ";
            CartelEmergente?.Invoke(C, S, B);
        }
    }
}
