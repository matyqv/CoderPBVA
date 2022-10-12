using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float speed;
    public Transform Skin;
    public Bujula Brujula;
    private int X , Z;

    public Vector3 V;
    private float magnitud;
    public Animator Anim;
   [SerializeField] private bool vive=true;
   [SerializeField] private bool GravedadOn=true;
    public CharacterController CC;
    private float gravedad;
    [SerializeField] private int Ruido;

    public int Ruido1 { get => Ruido; set => Ruido = value; }
    public float Gravedad1 { get => gravedad; set => gravedad = value; }
    public int X1 { get => X; set => X = value; }
    public int Z1 { get => Z; set => Z = value; }
    public bool Vive { get => vive; set => vive = value; }
    public bool GravedadOn1 { get => GravedadOn; set => GravedadOn = value; }

    public KeyCode But_Up;
    public KeyCode But_Dw;
    public KeyCode But_R;
    public KeyCode But_L;

    public GameObject CalizExperiencia;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerHp.OnDead += muerte;
    }

    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
        CC=GetComponent<CharacterController>();
        CirculoAlquimia.ActivarMeditacion += MeditacionAnim;
        PlayerStats.RomperMeditacion+= MeditacionAnimTerminar;

    }

    // Update is called once per frame
    void Update()
    {
        if(Vive)
        {
            But_Up = GameManager.Up1;
            But_Dw = GameManager.Down1;
            But_R = GameManager.Right1;
            But_L = GameManager.Left1;

            if (Input.GetKey(But_L)) { X1 = -1; }
            else if (Input.GetKey(But_R)) { X1 = 1; }
            else { X1 = 0; }

            if (Input.GetKey(But_Up)) { Z1 = 1; }
            else if (Input.GetKey(But_Dw)) { Z1 = -1; }
            else { Z1 = 0; }

            if (X1 == 0 && Z1 == 0)
            {
                Anim.SetInteger("Move", 0);
                Ruido1 = 0;
            }

            else
            {
                if (!Anim.GetCurrentAnimatorStateInfo(0).IsTag("AT"))
                {
                    Rot(new Vector3(X1, 0, Z1));
                    Anim.SetInteger("Move", 1);
                }
            }

            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {
                Mov(Brujula.transform.forward, 1f);
            }
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
            {
                Roll();
            }

            Gravedad();

          
            if (CC.isGrounded)
            {
                Gravedad1 = 15f;
                Anim.SetBool("EnPiso", true);
            }
            else
            {               
                Gravedad1 += 0.5f;
                Invoke("Caer",15 * Time.deltaTime);
            }
        }

    }

    public void Rot(Vector3 V)
    {
        Brujula.transform.LookAt(Brujula.transform.position+V);
        Skin.rotation = Quaternion.Lerp(Skin.rotation, Brujula.transform.rotation, speed*1.5f * Time.deltaTime);      
    }

    public void Roll()
    {
        Mov(Brujula.transform.forward, 1.6f);
        Ruido1 = 1;
    }

    public void Mov(Vector3 V,float S)
    {
         Vector3 Gravedad = Vector3.down * 9.8f;

            CC.Move((V* speed)* Time.deltaTime*S);
            Ruido1 = 2;
    }

    public void Gravedad()
    {
        if (GravedadOn1)
        {
            Vector3 Gravedad = Vector3.down * Gravedad1;
            CC.Move(Gravedad * Time.deltaTime);
            Skin.transform.localPosition = new Vector3(0, -0.55f, 0);
        }
    }

    public void muerte()
    {
        Vive = false;
        Anim.SetTrigger("Die");
        GameObject Caliz=Instantiate(CalizExperiencia, transform.position, Quaternion.identity);
        Caliz.GetComponent<OrbeExperiencia>().Experiencia = Mathf.RoundToInt(GameManager.exp);
        Caliz.GetComponent<OrbeExperiencia>().DDL();
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).length > 0.8f)
            {
                Anim.enabled = false;
            }
        }
    }
    public void Caer()
    {
        if (!CC.isGrounded)
        {
            Anim.SetBool("EnPiso", false);
            Mov(Brujula.transform.forward, 0.5f);
        }
    }
    public void MeditacionAnim()
    {
        Anim.SetBool("Med", true);
        Anim.SetBool("Die", true);
        Debug.Log("Recibe CirculoAlquimia.ActivarMeditacion desde " + name);
    }
    public void MeditacionAnimTerminar()
    {
        Anim.SetBool("Die", false);
        Anim.SetBool("Med", false);
        Debug.Log("Recibe PlayerStats.RomperMeditacion desde " + name);
    }
    public void OnDisable()
    {
        PlayerHp.OnDead -= muerte;
        PlayerStats.RomperMeditacion -= MeditacionAnimTerminar;
        CirculoAlquimia.ActivarMeditacion -= MeditacionAnim;
    }
}
