using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Brujula;
    public Transform Skin;
    public Transform target;

    [Range(0, 20)]
    [SerializeField] private float speed;
    private bool vive = true;
    public CharacterController CC;
    Animator Anim;

    [Range(0, 20)]
    [SerializeField] private float DistanciaAtaque;

    public DetectarPlayer Detector;
    public GameObject Experiencia;
    [Range(3,120)]
    [SerializeField]private int Exp;
    [SerializeField]private int Peso;
    [SerializeField] float RedVelocidadLerp;

    public enum Zombie
    {
        Reposo,
        Mirar,
        Guardia,
        Perseguir,
        Herido,
    }
    public Zombie zombiType;

    public float Speed { get => speed; set => speed = value; }
    public bool Vive { get => vive; set => vive = value; }

    // Start is called before the first frame update
    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vive)
        {
            switch (zombiType)
            {
                case Zombie.Reposo:
                    Reposo();
                    break;

                case Zombie.Guardia:
                    Guardia();
                    break;

                case Zombie.Perseguir:
                    Perseguir();
                    break;
                case Zombie.Mirar:
                    Mirar();
                    break;
            }

        }
        else { Muerto(); }
      
        Gravedad();

        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);
        if (StatInfo.IsTag("AT"))
        {
            RedVelocidadLerp = 3f;
        }
        else if (!StatInfo.IsTag("AT")) { RedVelocidadLerp = 1; }
    }

    void Guardia()
    {
        RotacionLerp(15);
        zombiType = Zombie.Perseguir;
    }
    void Mirar()
    {
        Brujula.LookAt(target);
        RotacionLerp(40);
        Anim.SetInteger("Move", 0);
    }
    void Reposo()
    {
        Anim.SetInteger("Move", 0);
    }
    void Perseguir()
    {
        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);

        Vector3 Target = new Vector3(target.position.x, transform.position.y, target.position.z);
        Brujula.LookAt(Target);
        RotacionLerp(40);
        float distance = Vector3.Distance(transform.position, Target);
        float distance_atack = Vector3.Distance(target.position, transform.position);

        if (distance > DistanciaAtaque && !StatInfo.IsName("GetHit"))
        {
            Anim.SetInteger("Move", 1);
            NoAtacar();
        }
        else
        {
            if (!StatInfo.IsTag("Hit"))
            {
                if (distance_atack < DistanciaAtaque)
                {
                    Atacar();
                }
                else
                { Anim.SetInteger("Move", 0); }
            }
        }

        if (StatInfo.IsName("Walk"))
        {
            Movimiento(Skin.forward, 1);
        }

    }



    //Variables Simples______________________________________________________
    public void Gravedad()
    {
        Skin.transform.localPosition=new Vector3(0, 0, 0);
        CC.Move(Vector3.down * 35 * Time.deltaTime);
    }

    void Atacar()
    { Anim.SetBool("Atk", true); }
    void NoAtacar()
    { Anim.SetBool("Atk", false); }
    public void Movimiento(Vector3 V, float S)
    {
        CC.Move(V * Speed/Peso * Time.deltaTime * S);
    }

    
    void Muerto()
    {
        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);
        NoAtacar();
        Anim.SetTrigger("Die");
        CC.enabled = false;
        if (StatInfo.IsName("KO"))
        {
            Destroy(this.gameObject);
        }
    }
    void VolverAlReposo()
    { zombiType = Zombie.Reposo; }
    void RotacionLerp(float V_Rotacion)
    {
        float r = V_Rotacion / RedVelocidadLerp;
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, r * Time.deltaTime);
    }
    public void DropEXp()
    {
        Experiencia.GetComponent<OrbeExperiencia>().Experiencia = Exp;
        Instantiate(Experiencia, transform.position, Quaternion.identity);
    }
    public void AsignarTarget(Transform T)
    {
        if (target == null)
        {
             target = T;
        }
    }
    // RecibeImpacto
    public void RecibeImpulsoAtaque(Vector3 Vs, float Ss)
    {
        for (float i=Ss ; i>0 ; i -= 1 * Time.deltaTime)
        {
            transform.Translate(Vs * 1 / Peso * Time.deltaTime * i);
        }
    }



}
