using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PublicPuertaCerrojo : MonoBehaviour
{
    [SerializeField] GameObject Cerrojo;
    [SerializeField] Transform puertaA;
    [SerializeField] Transform puertaB;
    [SerializeField] string LlaveRequerida;
    [SerializeField] bool Abierta;
    [SerializeField] TextMeshProUGUI Texto;
    [SerializeField] Image Panel;
    [SerializeField] AudioClip SonidoPuerta;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.K) && Abierta) { StartCoroutine(Abrir()); }
    }

    IEnumerator Abrir()
    {
        Abierta = false;
        for (float i = 1; i > 0.01f; i-=0.01f)
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
        Destroy(Panel.transform.gameObject);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Panel.gameObject.SetActive(true);

            if (other.GetComponent<PlayerKeys>().Keys_.ContainsKey(LlaveRequerida))
            {
                Abierta = true;
                Texto.text = "Presiona La Tecla [K] ";
                Panel.color = (Color.green + Color.white) / 2.4f;
            }
            else
            {
                Texto.text = "No tienes La Llave Necesaria ";
                Panel.color = (Color.red + Color.white) / 2.4f;
            }
        }
   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
