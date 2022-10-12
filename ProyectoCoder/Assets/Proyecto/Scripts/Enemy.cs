using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Stats Data")]
    [SerializeField] protected Zombie_Data ZD;

    [Header("Objetos Dinamicos Funcionales")]
    [SerializeField] protected Transform target;
    [SerializeField] protected List<Transform> WP;

    [SerializeField] private Transform targetVisual;
   protected int WP_Dir;
    [SerializeField] protected GameObject WP_Cantidades;


    [Range(3, 120)]
    [SerializeField] private int Exp;

    [Header("Objetos Fijos Funcionales")]
    [SerializeField] protected Transform Brujula;
    [SerializeField] protected Transform Skin;
    [SerializeField] protected CharacterController CC;
    [SerializeField] protected Animator Anim;
    [SerializeField] protected DetectarPlayer Detector;
    [SerializeField] protected GameObject Experiencia;
    [SerializeField] protected float RedVelocidadLerp;
    [SerializeField] protected bool vive = true;

    

    public enum Zombie
    {
        Reposo,
        Mirar,
        Guardia,
        Perseguir,
        Herido,
    }

    [SerializeField] private Zombie zombiType;

    public bool Vive { get => vive; set => vive = value; }
    public Transform Target1 { get => target; set => target = value; }
    public Zombie ZombiType { get => zombiType; set => zombiType = value; }
    public Transform TargetVisual { get => targetVisual; set => targetVisual = value; }



    // Start is called before the first frame update
    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {      

    
    }

   protected void Guardia()
   {

        Vector3 WP_Corrector=new Vector3 (WP[WP_Dir].position.x, transform.position.y, WP[WP_Dir].position.z);
        Brujula.LookAt(WP_Corrector);
        RotacionLerp(15);

        Anim.SetInteger("Move", 1);
        Movimiento(Skin.forward, 1);
        
        float Dist = Vector3.Distance(Skin.transform.position, WP_Corrector);

        if (Dist < 1f)
        {
            if (WP_Dir - 1 < WP.Count)
            {
                WP_Dir++;
            }
            if (WP_Dir == WP.Count)
            {
                WP_Dir=0;
            }

        }
   }

    protected void Mirar()
    {
        if (Target1 != null)
        {
            Vector3 AUX_TARGET = new Vector3(Target1.position.x, transform.position.y, Target1.position.z);

            Brujula.LookAt(AUX_TARGET);
            RotacionLerp(40);
            Anim.SetInteger("Move", 0);
            if (TargetVisual != null)
            {
                Perseguir();
            }
        }
        
    }

    protected void Reposo()
    {
        Anim.SetInteger("Move", 0);
    }
    protected void Perseguir()
    {
        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);

        Vector3 ___Target = new Vector3(TargetVisual.position.x, transform.position.y, TargetVisual.position.z);
        Brujula.LookAt(___Target);
        RotacionLerp(40);
        float distance = Vector3.Distance(transform.position, ___Target);
        float distance_atack = Vector3.Distance(this.TargetVisual.position, transform.position);

        if (distance > ZD.DistanciaAtaque1&& !StatInfo.IsName("GetHit"))
        {
            Anim.SetInteger("Move", 1);
            NoAtacar();
        }
        else
        {
            if (!StatInfo.IsTag("Hit"))
            {
                if (distance_atack < ZD.DistanciaAtaque1)
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
    protected void Gravedad()
    {
        Skin.transform.localPosition=new Vector3(0, 0, 0);
        CC.Move(Vector3.down * 35 * Time.deltaTime);
    }

    protected void Atacar()
    { Anim.SetBool("Atk", true); }
    protected void NoAtacar()
    { Anim.SetBool("Atk", false); }

    protected void Movimiento(Vector3 V, float S)
    {
        CC.Move(V * ZD.Speed/ZD.Peso1 * Time.deltaTime * S);
    }

    protected void Muerto()
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

    protected void VolverAlReposo()
    { zombiType = Zombie.Reposo; }

    protected void RotacionLerp(float V_Rotacion)
    {
        float r = V_Rotacion / RedVelocidadLerp;
        Skin.transform.rotation = Quaternion.Lerp(Skin.rotation, Brujula.rotation, r * Time.deltaTime);
    }

    public void DropEXp()
    {
        Experiencia.GetComponent<OrbeExperiencia>().Experiencia = Exp;
        Instantiate(Experiencia, transform.position, Quaternion.identity);

        int Probabilidad = Random.Range(1, 100);

        if (Probabilidad > 70)
        {

            GameObject Pota = ObjetosADropear.Pocion;
            Instantiate(Pota, transform.position, Quaternion.identity);

        }
    }

    public void AsignarTargetSonoro(Transform T)
    {
        if (Target1 == null)
        {
             Target1 = T;
        }
    }
    public void AsignarTargetVisual(Transform T)
    {
        if (TargetVisual == null)
        {
            TargetVisual = T;
            zombiType = Zombie.Perseguir;
        }
    }
    // RecibeImpacto
    public IEnumerator RecibeImpulsoAtaque(Vector3 Vs, float Ss)
    {
    //    ZombiType = Zombie.Reposo;
        for (float i=Ss ; i>0 ; i -= 1 * Time.deltaTime)
        {
            transform.Translate(Vs * 1 / ZD.Peso1 * Time.deltaTime * i);
            yield return new WaitForEndOfFrame();
        }
     //   ZombiType = Zombie.Mirar;
    }

}
