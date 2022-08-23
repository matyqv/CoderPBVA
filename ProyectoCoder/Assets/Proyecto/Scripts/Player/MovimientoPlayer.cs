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
    public CharacterController CC;
    private float gravedad;
    [SerializeField] private int Ruido;

    public int Ruido1 { get => Ruido; set => Ruido = value; }
    public float Gravedad1 { get => gravedad; set => gravedad = value; }
    public int X1 { get => X; set => X = value; }
    public int Z1 { get => Z; set => Z = value; }
    public bool Vive { get => vive; set => vive = value; }

    // Start is called before the first frame update
    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
        CC=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vive)
        {
            if (Input.GetKey(KeyCode.A)) { X1 = -1; }
            else if (Input.GetKey(KeyCode.D)) { X1 = 1; }
            else { X1 = 0; }

            if (Input.GetKey(KeyCode.W)) { Z1 = 1; }
            else if (Input.GetKey(KeyCode.S)) { Z1 = -1; }
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
        Skin.rotation = Quaternion.Lerp(Skin.rotation, Brujula.transform.rotation, 15f * Time.deltaTime);      
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
        Vector3 Gravedad = Vector3.down * Gravedad1;
        CC.Move(Gravedad * Time.deltaTime);
    }

    public void muerte()
    {
        Vive = false;
        Anim.SetTrigger("Die");
    }
    public void Caer()
    {
        if (!CC.isGrounded)
        {
            Anim.SetBool("EnPiso", false);
            Mov(Brujula.transform.forward, 0.5f);
        }
    }
}
