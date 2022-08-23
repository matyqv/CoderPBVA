using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPalanca : MonoBehaviour
{
    [SerializeField] private GameObject Palanca;
    [SerializeField] private GameObject Player;
    [SerializeField] private KeyCode Interaccion;
    [SerializeField] private Transform Waypoint;
    MovimientoPlayer Mp;
    private Animator Anim;

    public KeyCode Interaccion1 { get => Interaccion; set => Interaccion = value; }
    public bool Activado1 { get => Activado; set => Activado = value; }

    private bool Moviendo;
     private bool Activado=true;
    public GameObject Button;

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
            if (Input.GetKeyDown(Interaccion1) && !Moviendo)
            {
                Moviendo = true;
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
        if (!Mp.Anim.GetCurrentAnimatorStateInfo(0).IsTag("Palanca"))
        {
            TerminarDeMoverPalanca();
        }

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

    }
    void TerminarDeMoverPalanca()
    {
        //  Palanca.transform.parent = this.transform;
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
    }
    private void OnTriggerExit(Collider hit)
    {
        Button.SetActive(false);
         Player = null;
    }

}
