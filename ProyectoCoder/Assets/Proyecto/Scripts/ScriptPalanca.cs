using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class ScriptPalanca : MonoBehaviour
{
    [SerializeField] private GameObject Palanca;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform Waypoint;
    [SerializeField] private TextMeshProUGUI Text;
    MovimientoPlayer Mp;
    private Animator Anim;

    public bool Activado1 { get => Activado; set => Activado = value; }

    private bool Moviendo;
    [SerializeField] private bool Activado=true;
    public GameObject Button;

    public AudioClip PalancaClip;

    public UnityEvent TriggerOn;
    public UnityEvent TriggerOff;

    //  public static event Action <Color,String,bool>CartelEmergentel2;

    [SerializeField] TrigerEventCartelObjeto TE_cartel; 

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        TE_cartel = GetComponent<TrigerEventCartelObjeto>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {
           KeyCode Interaccion = GameManager.Interactuar1;
            if (Input.GetKeyDown(Interaccion) && !Moviendo)
            {
                AudioSource AS = GameManager.AS1;
                AS.PlayOneShot(PalancaClip,0.7f);
                Moviendo = true;
                //CerrarCartel__________________________________________________________________________

                bool B = false;
                string S = "No Debe Aparecer";
                Color C = (Color.black + Color.white) / 2;
                TE_cartel._MostrarCartelInteractuar(C, S, B);
                //CerrarCartel__________________________________________________________________________
            }
            if (Moviendo)
            {
                MoviendoPalanca();
            }
        }
        
    }
   
    void MoviendoPalanca()
    {
        Player.transform.position = Waypoint.transform.position;
        Player.transform.GetChild(0).transform.eulerAngles = Waypoint.transform.eulerAngles;

        if (Activado1)
        {
            Mp.Anim.SetTrigger("PalancaOff");
            Anim.SetInteger("On", -1);

            TriggerOn?.Invoke();
            Debug.Log("PalancaActivada" + name);

        }

        if (!Activado1)
        {
            Mp.Anim.SetTrigger("PalancaOn");
            Anim.SetInteger("On", 1);

            TriggerOff?.Invoke();
            Debug.Log("PalancaDesactivada" + name);
        }

        if (!Mp.Anim.GetCurrentAnimatorStateInfo(0).IsTag("Palanca"))
        {
            TerminarDeMoverPalanca();      
        }


    }
    void TerminarDeMoverPalanca()
    {
        Moviendo = false;
        bool On = !Activado1;
        Activado1 = On;
    }

    void On_Off()
    {
        bool On = !Activado1;
        Activado1 = On;
        if (On == true) {  }
        if (On == true) {  }
    }

    private void OnTriggerEnter(Collider hit)
    {
        bool EsPlayer = hit.transform.gameObject.CompareTag("Player");
        if (EsPlayer) { Player = hit.transform.gameObject; Mp = Player.GetComponent<MovimientoPlayer>(); }
        else { Player = null; }


      //  Button.SetActive(true);
        string T = GameManager.Interactuar1.ToString();
        Debug.Log(T);

        bool B = true;
        string S = "Pulsa " + T.ToString();
        Color C = (Color.black + Color.white) / 2;
        TE_cartel._MostrarCartelInteractuar(C, S, B);

    }
    private void OnTriggerExit(Collider hit)
    {
     //   Button.SetActive(false);
         Player = null;

        bool B = false;
        string S = "No Debe Aparecer";
        Color C = (Color.black + Color.white) / 2;
        TE_cartel._MostrarCartelInteractuar(C, S, B);
    }

}
