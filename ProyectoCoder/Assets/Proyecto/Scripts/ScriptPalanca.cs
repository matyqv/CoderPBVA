using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptPalanca : MonoBehaviour
{
    [SerializeField] private GameObject Palanca;
    [SerializeField] private GameObject Player;
    [SerializeField] private KeyCode Interaccion;
    [SerializeField] private Transform Waypoint;
    [SerializeField] private TextMeshProUGUI Text;
    MovimientoPlayer Mp;
    private Animator Anim;

    public KeyCode Interaccion1 { get => Interaccion; set => Interaccion = value; }
    public bool Activado1 { get => Activado; set => Activado = value; }

    private bool Moviendo;
    [SerializeField] private bool Activado=true;
    public GameObject Button;

    public AudioClip PalancaClip;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {
            Interaccion = GameManager.Interactuar1;
            if (Input.GetKeyDown(Interaccion1) && !Moviendo)
            {
                AudioSource AS = GameManager.AS1;
                AS.PlayOneShot(PalancaClip,0.7f);
                Moviendo = true;
                Button.SetActive(false);
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
        }

        if (!Activado1)
        {
            Mp.Anim.SetTrigger("PalancaOn");
            Anim.SetInteger("On", 1);
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
    }

    private void OnTriggerEnter(Collider hit)
    {
        bool EsPlayer = hit.transform.gameObject.CompareTag("Player");
        if (EsPlayer) { Player = hit.transform.gameObject; Mp = Player.GetComponent<MovimientoPlayer>(); }
        else { Player = null; }
        Button.SetActive(true);
        string T = GameManager.Interactuar1.ToString();
        Debug.Log(T);
        Text.text = "Pulsa " + T;
    }
    private void OnTriggerExit(Collider hit)
    {
        Button.SetActive(false);
         Player = null;
    }

}
