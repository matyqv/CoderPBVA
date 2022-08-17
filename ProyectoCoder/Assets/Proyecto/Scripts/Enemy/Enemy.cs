using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Brujula;
    public Transform Skin;
    public Transform target;

    public float speed;
    public bool Vive;
     Animator Anim;

    [Range(0, 20)]
    public float DistanciaAtaque;

    public enum Zombie
    {
        Nulo,
        Mirar,
        Perseguir,
        Herido,
    }
    public Zombie zombiType;
    // Start is called before the first frame update
    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetY0 = new Vector3(target.position.x, transform.position.y, target.position.z);
        Brujula.LookAt(TargetY0);
        if (Vive)
        {
            switch (zombiType)
            {
                case Zombie.Mirar:
                    Mirar();
                    break;

                case Zombie.Perseguir:
                    Perseguir();
                    break;

                case Zombie.Herido:
                    Herido();
                    break;
            }

        }
        else { Muerto(); }
    }
    void Mirar()
    {
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 15*Time.deltaTime);
    }

    void Perseguir()
    {
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 150 * Time.deltaTime);
        float distance = Vector3.Distance(target.position , transform.position);

        if (distance > DistanciaAtaque && !Anim.GetCurrentAnimatorStateInfo(0).IsName("GetHit"))
        {
            Anim.SetInteger("Move", 1);
            NoAtacar();
        }
        else
        {
            if (!Anim.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            {
               Atacar();
            }
        }

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Movimiento(Skin.forward, 1);
        }
    }
    void Herido()
    {
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, 15 * Time.deltaTime);
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance > 2.5f)
        {
            transform.Translate(Skin.forward * (speed/2) * Time.deltaTime);
            Anim.SetInteger("Move", 2);
        }
        else { Anim.SetInteger("Move", 0); }
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
    void Atacar()
    { Anim.SetBool("Atk",true); }
    void NoAtacar()
    { Anim.SetBool("Atk", false); }
    public void Movimiento(Vector3 V, float S)
    {
        transform.Translate(V * speed * Time.deltaTime* S);
    }
}
