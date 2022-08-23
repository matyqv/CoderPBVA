using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspada : MonoBehaviour
{

    public KeyCode Ataque;
    public KeyCode Salto;
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
        if (Input.GetKeyUp(Ataque) && !Anim.GetCurrentAnimatorStateInfo(0).IsTag("NO"))
        {
            AnimacionAtaque();
        }
        if (Input.GetKeyUp(Rol) && !Anim.GetCurrentAnimatorStateInfo(0).IsTag("NO"))
        {
            if (!Anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
            {
                Roll();
            }
        }

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit0") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            movimiento.Mov(movimiento.Brujula.transform.forward,.3f);
        }
        else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            movimiento.Mov(movimiento.Brujula.transform.forward, .15f);
        }
    }

    void AnimacionAtaque()
    {
        if (PuedeAtacar)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || Anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {
                Anim.SetTrigger("Hit");
            }

            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit0"))
            {
                Anim.SetTrigger("Hit2");
            }

            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
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
