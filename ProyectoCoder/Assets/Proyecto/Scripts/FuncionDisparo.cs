using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionDisparo : MonoBehaviour
{
    [SerializeField]private Transform WP_Disparo;
    [SerializeField] private ParticleSystem Shoot;
    [Range(0, 30)]
    [SerializeField] private float DistanciaDetectar;
    [SerializeField] private AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnDrawGizmos()
    {
        float MaxDist = DistanciaDetectar;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(WP_Disparo.transform.position, transform.lossyScale /3, WP_Disparo.forward, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(WP_Disparo.transform.position, WP_Disparo.forward * hit.distance);
            Gizmos.DrawWireCube(WP_Disparo.transform.position + WP_Disparo.forward * hit.distance, transform.lossyScale/3);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(WP_Disparo.transform.position, WP_Disparo.forward * MaxDist);
        }
    }

    public void Disparar()
    {
        Shoot.Play();
        AS.Play();

        float MaxDist = DistanciaDetectar;
        RaycastHit hit;
        bool isHit = Physics.BoxCast(WP_Disparo.transform.position, transform.lossyScale /3, WP_Disparo.forward, out hit, Quaternion.identity, MaxDist);
        if (isHit)
        {
            if (hit.transform.CompareTag("Player"))
            {
                PlayerHp PJHP = hit.transform.GetComponent<PlayerHp>();
                PJHP.RestarVida(1, WP_Disparo.forward);
            }
        }
        else
        {
        }
        transform.GetComponentInParent<Pistolero_Enemy>().LerpChange(1);
    }

    public void Lerp0()
    {
        transform.GetComponentInParent<Pistolero_Enemy>().LerpChange(1000);
    }
}
