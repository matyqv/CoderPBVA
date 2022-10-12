using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject Bala;

    [SerializeField] float Speed;
    [SerializeField] float Damage;


    // Start is called before the first frame update
    private void Awake()
    {
        AtaqueEspada.ShotCharge += Carga;
        AtaqueEspada.Disparar += Disparo;
    }
    void Start()
    {
        Damage = 0f;
        Speed = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Carga(float A)
    {
        Speed = 35 + (20 * A);
        Damage = 0 +(3*A);
    }

    void Disparo()
    {

        if (Damage > 0.6f)
        {
            GameObject Shoot = Instantiate(Bala, transform.position, transform.rotation);
            Shoot.GetComponent<Bala>().Speed1 = Speed;
            Shoot.GetComponent<Bala>().Damage1 = Damage;
            Shoot.GetComponent<Bala>().MovingOut1 = true;
            
        }

        Damage = 0f;
        Speed = 35f;
    }

    private void OnDisable()
    {
        AtaqueEspada.ShotCharge -= Carga;
        AtaqueEspada.Disparar -= Disparo;
    }
}
