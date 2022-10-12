using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caballero_Vampiro : Boss_Basic
{
    [Header("Patron")]
    [SerializeField] string Patron;
    [SerializeField] int subpatron;
    [SerializeField] List<string> Patrones;


    [SerializeField] MeshRenderer Circulo;

    [Header("Funcion Teletransport")]
    [SerializeField] Transform[] Waypoints;
    [SerializeField] int NextTransport;
    [SerializeField] int FaseTP;
    public int FaseTP1 { get => FaseTP; set => FaseTP = value; }
    [SerializeField] string Sig_Patron;
    


    // Start is called before the first frame update
    void Start()
    {
        Indicar_Mele();
        GenerarPatrones();
    }

    // Update is called once per frame
    void Update()
    {
        if (Patron == "TP")
        {
            Transportando();
            GenerarPatrones();
        }
        if (Patron == "Mele")
        {            
            if (seMueve > 0)
            {
                Mover();
            }
        }
        if (Patron == "Shoot")
        {
            Brujula.LookAt(Target);
            Rot();
        }

        if (Patron == "Bream")
        {

        }
        if (Patron == "Shadow")
        {

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GenerarPatrones();
        }
    }
    // Funciones Moviemiento
    void Mover()
    {
        float distancia = Vector3.Distance(transform.position, Target.position);


        if (distancia > 2)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsTag("Move"))
            {
                CC.Move(Skin.forward * Speed * seMueve * Time.deltaTime);
                Rot();
            }
        }
    }
    public void Rot()
    {
        Vector3 V_3 = new Vector3(Target.transform.position.x, Brujula.position.y, Target.transform.position.z);

        Brujula.transform.LookAt(V_3);
        Skin.rotation = Quaternion.Lerp(Skin.rotation, Brujula.transform.rotation, Speed * 1.5f * Time.deltaTime);
    }
    public void Transportando()
    {
        if (FaseTP1 == 0)
        {
            Anim.SetFloat("Desaparecer",0.1f);

            Debug.Log(
            Anim.GetCurrentAnimatorStateInfo(0).normalizedTime
                );
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Desaparecer_0") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .9f)
            {
                FaseTP1 = 1;
            }
        }
        if (FaseTP1==1)
        {
            if (NextTransport != 3)
            {
                NextTransport = Mathf.RoundToInt(Random.Range(-0.4f, 2.4f));

                transform.position = Waypoints[NextTransport].position;
                Brujula.LookAt(Waypoints[3].position);
                FaseTP1 = 2;
            }
            if (NextTransport == 3)
            {                
                transform.position = Waypoints[3].position;
                FaseTP1 = 2;

            }
        }
        if (FaseTP1 == 2)
        {
            Anim.SetFloat("Desaparecer", 0.2f);
        }
        if (FaseTP1 == 3)
        {
            IndicarGeneral();
        }
    }

    // Indicar Funciones
    public void IndicarGeneral()
    {
        if (Sig_Patron == "Mele")
        { Indicar_Mele(); }

        if (Sig_Patron == "Shoot")
        { Indicar_Shoot(); }

        Patrones.Remove(Patrones[0]);
        GenerarPatrones();
    }

    public void Indicar_Transporte()
    {
        Patron = "TP";
        Anim.SetTrigger("Apa_Des");
        FaseTP1 = 0;
    }
    public void Indicar_Mele()
    {
        seMueve = Random.Range(1.5f,2.7f);
        Anim.SetTrigger("Mover");
        Patron = Sig_Patron;
    }

    public void Indicar_Shoot()
    {
        Anim.ResetTrigger("Mover");
        Anim.SetTrigger("Spell0");
        Patron = Sig_Patron;
    }
    //Funciones de Ataque
    public void Atk_0()
    {
        seMueve = 0.3f;
        Anim.SetTrigger("Atk 0");
    }
    //Auxiliares________________________________________________________________________
    public void SeMueve_1()
    {
        seMueve = 1;
    }


    //Disparar Patrones::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    void GenerarPatrones()
    {
        int N = Mathf.RoundToInt(Random.Range(-0.4f, 1.49f));
      
        if (N == 0)
        {
            Patrones.Add("Mele");
        }
        if (N == 1)
        {
            Patrones.Add("Shoot");
        }

        Sig_Patron = Patrones[0];

    }
    //Disparar Patrones::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::



}
