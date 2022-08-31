using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspada : MonoBehaviour
{

    public KeyCode Ataque;
    public KeyCode Rol;

    public Animator Anim;
    public MovimientoPlayer movimiento;

    //PlayerEstamina Estamina;

    private bool puedeRotar=true;
    private bool puedeAtacar = true;
    [Range(0,10)]
    [SerializeField] private float tiempoAtaque;
    [Range(0,10)]
    [SerializeField] private float tiempoRotar;

    public bool PuedeRotar { get => puedeRotar; set => puedeRotar = value; }
    public bool PuedeAtacar { get => puedeAtacar; set => puedeAtacar = value; }
  
    public float TiempoAtaque { get => tiempoAtaque; set => tiempoAtaque = value; }
    public float TiempoRotar { get => tiempoRotar; set => tiempoRotar = value; }

    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<MovimientoPlayer>();
      //  Estamina=movimiento.transform.gameObject.GetComponent<PlayerEstamina>();
    }

    // Update is called once per frame
    void Update()
    {
          Ataque=GameManager.Attack1;
         Rol=GameManager.Roll1;
           AnimatorStateInfo State = Anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyUp(Ataque) && !State.IsTag("NO"))
        {
            AnimacionAtaque();
        }
        if (Input.GetKeyUp(Rol) && !State.IsTag("NO"))
        {
            if (!State.IsName("Roll"))
            {
                Roll();
            }
        }

        if (State.IsName("Hit0") || State.IsName("Hit1"))
        {
            movimiento.Mov(movimiento.Brujula.transform.forward,.3f);
        }
        else if (State.IsName("Hit2"))
        {
            movimiento.Mov(movimiento.Brujula.transform.forward, .15f);
        }
    }

    void AnimacionAtaque()
    {
        AnimatorStateInfo State = Anim.GetCurrentAnimatorStateInfo(0);
        if (PuedeAtacar)
        {
            if (State.IsName("Idle") || State.IsName("run"))
            {
                Anim.SetTrigger("Hit");
            }

            if (State.IsName("Hit0"))
            {
                Anim.SetTrigger("Hit2");
            }

            if (State.IsName("Hit1"))
            {
                Anim.SetTrigger("Hit3");
                PuedeAtacar = false;
                Invoke("reestablecerAtaque", TiempoAtaque*Time.deltaTime);
            }
        }
    }

    void Roll()
    {
        if(PuedeRotar)
        {

            GestorSonidos GS = GetComponent<GestorSonidos>();
            GS.Rep_Rol();

            Anim.SetTrigger("Rol");
            PuedeRotar = false;
            Invoke("reestablecerRotacion", TiempoRotar * Time.deltaTime);
        }
    }

    void reestablecerAtaque()
    { PuedeAtacar = true; }

    void reestablecerRotacion()
    { PuedeRotar = true; }
}
