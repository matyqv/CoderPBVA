using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistolero_Enemy : Enemy
{
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
            switch (ZombiType)
            {
                case Zombie.Reposo:
                    Reposo();
                    Debug.Log(ZombiType);
                    break;

                case Zombie.Guardia:
                    Guardia();
                    Debug.Log(ZombiType);
                    break;

                case Zombie.Perseguir:
                    Perseguir();
                    Debug.Log(ZombiType);
                    break;

                case Zombie.Mirar:
                    Mirar();
                    Debug.Log(ZombiType);
                    break;
            }
        }

        else { Muerto(); }

        Gravedad();

        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);
    }

    public void LerpChange(int X)
    {
        RedVelocidadLerp = X;
    }
}
