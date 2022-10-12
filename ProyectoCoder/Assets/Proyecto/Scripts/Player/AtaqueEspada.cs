using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AtaqueEspada : MonoBehaviour
{
    public Animator Anim;
    public MovimientoPlayer movimiento;

    //PlayerEstamina Estamina;

  // [SerializeField] private bool puedeRotar=true;
    [SerializeField] private bool puedeAtacar = true;
    [Range(0,200)]
    [SerializeField] private float tiempoAtaque;
 //   [Range(0,200)]
  //  [SerializeField] private float tiempoRotar;

  //  public bool PuedeRotar { get => puedeRotar; set => puedeRotar = value; }
    public bool PuedeAtacar { get => puedeAtacar; set => puedeAtacar = value; }
  
    public float TiempoAtaque { get => tiempoAtaque; set => tiempoAtaque = value; }
  //  public float TiempoRotar { get => tiempoRotar; set => tiempoRotar = value; }


    //Disparar
    [SerializeField] bool PreShoot;
    public static Action<float> ShotCharge;
    public static Action  Disparar;

    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<MovimientoPlayer>();
    }
    void Awake()
    {
        PlayerStats.ActualizarValores += ActualizarTiempos;
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode Ataque =GameManager.Attack1;
        KeyCode Rol =GameManager.Roll1;
        KeyCode Disparo= GameManager.Disparar1;

        AnimatorStateInfo State = Anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyUp(Ataque) && !State.IsTag("NO") && !PreShoot)
        {
            AnimacionAtaque();
        }
        if (Input.GetKeyUp(Rol) && !State.IsTag("NO") && !PreShoot)
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


        //Mecanica de disparo
        if (Input.GetKeyDown(Disparo) && !State.IsTag("NO"))
        {
            DisparON();         
        }

        if (State.IsName("1Pistola"))
        {
            float A=State.length;
            ShotCharge?.Invoke(A);
        }

        if (Input.GetKeyUp(Disparo) && PreShoot)
        {
            disparoff();
        }


        //Guardar Espada
        AnimatorStateInfo AnimSI = Anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(GameManager.GuardarArma1))
        {
            if (AnimSI.IsTag("Base"))
            {
                Anim.SetTrigger("GuardarEspada");
            }
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
            GestorSonidos GS = GetComponent<GestorSonidos>();
            GS.Rep_Rol();

            Anim.SetTrigger("Rol");       
    }
    void reestablecerAtaque()
    { PuedeAtacar = true; }
//    void reestablecerRotacion()
 //   { PuedeRotar = true; }
    void ActualizarTiempos()
    {
        Debug.Log("Recibe PlayerStats.ActualizarValores Desde " + name);
        tiempoAtaque = 90 - GameManager.SPD * 10;
//        tiempoRotar = 70 - GameManager.SPD * 10;
    }


    void DisparON()
    {
        PreShoot = true;
        Anim.SetTrigger("Shot0");
        movimiento.speed = 3.3f;
    }

    void disparoff()
    {
        Anim.SetTrigger("Shot1");
        PreShoot = false;
        Disparar?.Invoke();
        movimiento.speed = 10;
    }
    private void OnDisable()
    {
        PlayerStats.ActualizarValores -= ActualizarTiempos;
    }
}
