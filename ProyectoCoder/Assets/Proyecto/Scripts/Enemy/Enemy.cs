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

    }

    void Guardia()
    {
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 15*Time.deltaTime);
        zombiType = Zombie.Perseguir;
    }
    void Mirar()
    {
        Brujula.LookAt(target);
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 40 * Time.deltaTime);
    }
    void Reposo()
    {
        Anim.SetInteger("Move", 0);         
    }
    void Perseguir()
    {
        Vector3 Target = new Vector3(target.position.x, transform.position.y, target.position.z); 
        Brujula.LookAt(Target);
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 150 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position , Target);
        float distance_atack = Vector3.Distance(target.position , transform.position);

        if (distance > DistanciaAtaque && !Anim.GetCurrentAnimatorStateInfo(0).IsName("GetHit"))
        {
            Anim.SetInteger("Move", 1);
            NoAtacar();
        }
        else
        {
            if (!Anim.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            {
                if (distance_atack < DistanciaAtaque)
                {
                    Atacar();
                }
                else
                { Anim.SetInteger("Move", 0); }
            }
        }

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Movimiento(Skin.forward, 1);
        }
    }



    //Variables Simples______________________________________________________
    public void Gravedad()
    {
        CC.Move(Vector3.down*35 * Time.deltaTime);
    }

    void Atacar()
    { Anim.SetBool("Atk", true); }
    void NoAtacar()
    { Anim.SetBool("Atk", false); }
    public void Movimiento(Vector3 V, float S)
    {
        CC.Move(V * Speed * Time.deltaTime * S);
    }
    void Muerto()
    {
        NoAtacar();
        Anim.SetTrigger("Die");
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<CapsuleCollider>());
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("KO"))
        {
            Destroy(this.gameObject);
        }
    }
    void VolverAlReposo()
    { zombiType = Zombie.Reposo; }
    public void AsignarTarget(Transform T)
    {
        if (target == null)
        {
             target = T;
        }
    }

}
