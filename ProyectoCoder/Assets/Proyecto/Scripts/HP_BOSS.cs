using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_BOSS : MonoBehaviour
{

    [SerializeField] float HPMAX;
    [SerializeField] float HP;

    [SerializeField] RectTransform RT_HP;
    [SerializeField] Boss_Basic bb;
    [SerializeField] Animator Anim;
    public float HP1 { get => HP; set => HP = value; }

    // Start is called before the first frame update
    void Start()
    {
        bb = GetComponent<Boss_Basic>();
        Anim = GetComponentInChildren<Animator>();
        RevisarRecttransform();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void RevisarRecttransform()
    {
        float HP_Actual = HP1 / HPMAX;

        Debug.Log(HP_Actual + " Barra");

        RT_HP.localPosition = new Vector3(-350 + (350 * HP_Actual), 0, 0);
        RT_HP.sizeDelta = new Vector2(700 * HP_Actual, 20);
    }

   public void RestarVida(float Damage)
    {
        // Referenciar animacion  
        Anim.SetTrigger("Gethit");
        HP1 -= Damage;
        RevisarRecttransform();


        if (HP1 <= 0)
        {
            bb.DeclararMuerto();
        }
    }
}
