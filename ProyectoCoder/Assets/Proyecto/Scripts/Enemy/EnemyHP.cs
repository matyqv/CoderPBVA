using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Range(1, 60)]
   [SerializeField] private float HP;
    [SerializeField] private Animator Anim;
    [SerializeField] private Material Mat;
    [SerializeField] private SkinnedMeshRenderer Mesh;
    [SerializeField] private Shader Shad;
    [SerializeField] private Enemy EnemyMov;

    public float HP1 { get => HP; set => HP = value; }

    // Start is called before the first frame update
    void Start()
    {
    //    HP = HPtotal;
        EnemyMov = GetComponent<Enemy>();
        Material NewMat=new Material(Shad);     
        NewMat.CopyPropertiesFromMaterial(Mat);
        Mesh.materials[1] = NewMat;
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
            HP1 -= Daño;
            EnemyMov.RecibeImpulsoAtaque(V,1.5f);
            if (HP1 <= 0)
            {
                EnemyMov.Vive = false;
                EnemyMov.DropEXp();
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
