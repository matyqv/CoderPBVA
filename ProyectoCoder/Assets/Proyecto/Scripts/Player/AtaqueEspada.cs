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
    public DañoDeEspada DañoDEspada;

    
    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<MovimientoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(Ataque))
        {
            AnimacionAtaque();
        }
        if (Input.GetKeyUp(Rol))
        {
            if (!Anim.GetCurrentAnimatorStateInfo(0).IsName("Roll")) {
            Anim.SetTrigger("Rol");
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
        }
    }
}
