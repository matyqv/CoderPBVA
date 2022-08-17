using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Range(1, 60)]
    public float HP;
    public Animator Anim;
    public Material Mat;
    public SkinnedMeshRenderer Mesh;
    public Shader Shad;
    public Enemy EnemyMov;
    // Start is called before the first frame update
    void Start()
    {
    //    HP = HPtotal;
        EnemyMov = GetComponent<Enemy>();
        Material NewMat=new Material(Shad);     
        NewMat.CopyPropertiesFromMaterial(Mat);
        Mesh.material = NewMat;
        Anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestarVida(float Daño,Vector3 V)
    {
        if (EnemyMov.Vive)
        {
            Time.timeScale = 0.05f;
            Invoke("TimeIs1", 0.1f*Time.deltaTime);
            Anim.SetTrigger("Hit");
            HP -= Daño;
            EnemyMov.GetComponent<Rigidbody>().AddForce(V*3,ForceMode.Impulse);
          //  EnemyMov.Movimiento(V, Daño * 15);
            if (HP <= 0)
            {
                EnemyMov.Vive = false;
            }
        }
    }

    void TimeIs1()
    {
        Time.timeScale = 1;
    }


    public float  MostrarVida(float HP)
    {
        return HP;
    }
}
