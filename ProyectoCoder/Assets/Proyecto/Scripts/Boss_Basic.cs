using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Basic : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected int RutinaAtk;

    [SerializeField] protected GameObject Proyectil1;
    [SerializeField] protected GameObject Proyectil2;

    [SerializeField] protected CharacterController CC;

    [SerializeField] protected Transform Target;
    [SerializeField] protected Transform Brujula;
    [SerializeField] protected Transform Skin;

    [SerializeField] protected float seMueve;
    [SerializeField] protected Animator Anim;
    [SerializeField] protected bool IsLive=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeclararMuerto()
    {
        IsLive = false;
    }
}
