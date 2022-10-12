using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{

    [SerializeField] GameObject  Player;

    [SerializeField] Objeto  Objeto;
    [SerializeField] Transform Tapa;
    [SerializeField] int Cantidad;

    [SerializeField] bool Abierto;
    [SerializeField] bool dentro;
    [SerializeField] TrigerEventCartelObjeto TE_cartel;
    // Start is called before the first frame update
    void Start()
    {

        TE_cartel = GetComponent<TrigerEventCartelObjeto>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameManager.Interactuar1) && !Abierto && dentro)
        {
            StartCoroutine(Abrir());
            Abierto = true;


            // Ocultar Cartel__________________________________________________________________
            string T = GameManager.Interactuar1.ToString();
            Debug.Log(T);

            bool B = false;
            string S = null;
            Color C = Color.black;
            TE_cartel._MostrarCartelInteractuar(C, S, B);
            // Ocultar Cartel__________________________________________________________________


            TrigerEventCartelObjeto Mensajero = GetComponent<TrigerEventCartelObjeto>();

            if (Objeto.NAME == "Pocion")
            {
                {
                    PlayerKeys KY = Player.GetComponent<PlayerKeys>();
                    GameManager.AS1.PlayOneShot(Objeto.GetObjeto, 1f);
                    Mensajero.EnviarMensaje(Objeto.NAME + "(+" + Cantidad + ")");
                    while (Cantidad > 0)
                    {
                        KY.AddPocion();
                        Cantidad--;
                    }
                }
            }
        }
    }

    IEnumerator Abrir()
    {
        float Y = 0;
        while (Y < 45)
        {
            Y += 100 * Time.deltaTime;
            Tapa.localEulerAngles = new Vector3(0, Y, 0);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = true;
            Player = other.transform.gameObject;


            // mostrar Cartel__________________________________________________________________

            if (!Abierto)
            {
                //  Button.SetActive(true);
                string T = GameManager.Interactuar1.ToString();
                Debug.Log(T);

                bool B = true;
                string S = "Pulsa " + T.ToString();
                Color C = (Color.black + Color.white) / 2;
                TE_cartel._MostrarCartelInteractuar(C, S, B);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Ocultar Cartel__________________________________________________________________

        if (other.CompareTag("Player"))
        {
            dentro = false;
            Player = null;


            //  Button.SetActive(true);
            string T = GameManager.Interactuar1.ToString();
            Debug.Log(T);

            bool B = false;
            string S = null;
            Color C = Color.black;
            TE_cartel._MostrarCartelInteractuar(C, S, B);
        }
    }

    void OtorgarObjetos()
    {

    }
}
