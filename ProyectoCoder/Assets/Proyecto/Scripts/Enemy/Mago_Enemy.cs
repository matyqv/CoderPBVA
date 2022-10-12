using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago_Enemy : Enemy
{
    public GameObject FireAtack;

    // Start is called before the first frame update
    void Start()
    {

        Anim = Skin.GetComponent<Animator>();
        CC = GetComponent<CharacterController>();

        if (WP_Cantidades != null)
        {
            for (int i = 0; i < WP_Cantidades.transform.childCount; i++)
            {
                WP.Add(WP_Cantidades.transform.GetChild(i).transform);
            }
            ZombiType = Zombie.Guardia;
        }
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
                //    Debug.Log(ZombiType);
                    break;

                case Zombie.Guardia:
                    Guardia();
                //    Debug.Log(ZombiType);
                    break;

                case Zombie.Perseguir:
                    Perseguir();
                 //   Debug.Log(ZombiType);
                    break;

                case Zombie.Mirar:
                    Mirar();
                 //   Debug.Log(ZombiType);
                    break;
            }
        }

        else { Muerto(); }

        Gravedad();

        AnimatorStateInfo StatInfo = Anim.GetCurrentAnimatorStateInfo(0);
        if (StatInfo.IsTag("AT"))
        {
            RedVelocidadLerp = 3.5f;
        }
        else if (!StatInfo.IsTag("AT")) { RedVelocidadLerp = 1; }
    }

    public void InvocarFuego()
    { }

    public void Dezaparecer()
    { }

    public void aparecer()
    { }
}
