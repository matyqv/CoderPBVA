using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float speed;
    public Transform Skin;
    public Bujula Brujula;
    public int X , Z;

    public Vector3 V;
    public float magnitud;
    public Animator Anim;
    public bool vive;
    public CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
        Anim = Skin.GetComponent<Animator>();
        CC=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vive)
        {
            if (Input.GetKey(KeyCode.A)) { X = -1; }
            else if (Input.GetKey(KeyCode.D)) { X = 1; }
            else { X = 0; }

            if (Input.GetKey(KeyCode.W)) { Z = 1; }
            else if (Input.GetKey(KeyCode.S)) { Z = -1; }
            else { Z = 0; }

            if (X == 0 && Z == 0)
            {
                Anim.SetInteger("Move", 0);
            }

            else
            {
                if (!Anim.GetCurrentAnimatorStateInfo(0).IsTag("AT"))
                {
                    Rot(new Vector3(X, 0, Z));
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

            Gravedad(1);
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
    }

    public void Mov(Vector3 V,float S)
    {
         Vector3 Gravedad = Vector3.down * 9.8f;

            CC.Move((Brujula.transform.forward* speed)* Time.deltaTime*S);
    }

    public void Gravedad(float S)
    {
        Vector3 Gravedad = Vector3.down * 25f;
        CC.Move(Gravedad * Time.deltaTime * S);
    }

    public void muerte()
    {
        vive = false;
        Anim.SetTrigger("Die");
    }
}
